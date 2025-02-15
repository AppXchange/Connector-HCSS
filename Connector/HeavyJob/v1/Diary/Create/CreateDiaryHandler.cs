using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.HeavyJob.v1.Diary.Create;

public class CreateDiaryHandler : IActionHandler<CreateDiaryAction>
{
    private readonly ILogger<CreateDiaryHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateDiaryHandler(
        ILogger<CreateDiaryHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(ActionInstance actionInstance, CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateDiaryActionInput>(actionInstance.InputJson)!;
        
        try
        {
            var response = await _apiClient.UpsertDiary(new DiaryDataObject
            {
                JobId = input.JobId,
                ForemanId = input.ForemanId,
                Date = input.Date,
                LockedById = input.LockedById,
                LockedDateTime = input.LockedDateTime,
                Revision = input.Revision,
                Tags = input.Tags,
                Note = input.Note,
                WorkingConditions = input.WorkingConditions
            }, cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[]
                    {
                        new Error
                        {
                            Source = new[] { nameof(CreateDiaryHandler) },
                            Text = $"Failed to create/update diary. Status code: {response.StatusCode}"
                        }
                    }
                });
            }

            return ActionHandlerOutcome.Successful(new CreateDiaryActionOutput 
            { 
                Id = response.Data!.Id 
            });
        }
        catch (ApiException exception)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode.ToString(),
                Errors = new[]
                {
                    new Error
                    {
                        Source = new[] { nameof(CreateDiaryHandler) },
                        Text = exception.Message
                    }
                }
            });
        }
    }
}
