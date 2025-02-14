using Connector.Client;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Net.Http;

namespace Connector.Equipment360.v1.Invoice;

public class InvoiceDataReader : TypedAsyncDataReaderBase<InvoiceDataObject>
{
    private readonly ILogger<InvoiceDataReader> _logger;
    private readonly ApiClient _apiClient;

    public InvoiceDataReader(
        ILogger<InvoiceDataReader> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public override async IAsyncEnumerable<InvoiceDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        ApiResponse<IEnumerable<InvoiceDataObject>> response;
        try
        {
            response = await _apiClient.GetInvoices(cancellationToken);

            if (!response.IsSuccessful)
            {
                _logger.LogError("Failed to retrieve invoices. Status code: {StatusCode}", response.StatusCode);
                throw new Exception($"Failed to retrieve invoices. API StatusCode: {response.StatusCode}");
            }
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Exception while retrieving invoices");
            throw;
        }

        if (response.Data == null)
            yield break;

        foreach (var invoice in response.Data)
        {
            yield return invoice;
        }
    }
}