using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;

namespace Connector.Safety.v1.Meetings;

public class MeetingsDataReader : TypedAsyncDataReaderBase<MeetingsDataObject>
{
    private readonly ILogger<MeetingsDataReader> _logger;
    private readonly ApiClient _apiClient;
    private int _skip = 0;
    private const int _take = 1000;

    public MeetingsDataReader(
        ILogger<MeetingsDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<MeetingsDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        do
        {
            var response = await _apiClient.GetMeetings(
                skip: _skip,
                take: _take,
                cancellationToken: cancellationToken);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to retrieve meetings. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve meetings. API StatusCode: {response.StatusCode}");
            }

            if (response.Data.Meetings.Length == 0)
            {
                break;
            }

            foreach (var meeting in response.Data.Meetings)
            {
                yield return meeting;
            }

            _skip += _take;

        } while (true);
    }
}