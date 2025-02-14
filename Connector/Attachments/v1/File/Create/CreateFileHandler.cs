using Connector.Client;
using ESR.Hosting.Action;
using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xchange.Connector.SDK.Action;
using Xchange.Connector.SDK.CacheWriter;
using Xchange.Connector.SDK.Client.AppNetwork;

namespace Connector.Attachments.v1.File.Create;

public class CreateFileHandler : IActionHandler<CreateFileAction>
{
    private readonly ILogger<CreateFileHandler> _logger;
    private readonly ApiClient _apiClient;

    public CreateFileHandler(
        ILogger<CreateFileHandler> logger,
        ApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }
    
    public async Task<ActionHandlerOutcome> HandleQueuedActionAsync(
        ActionInstance actionInstance, 
        CancellationToken cancellationToken)
    {
        var input = JsonSerializer.Deserialize<CreateFileActionInput>(actionInstance.InputJson);
        if (input == null)
        {
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = "400",
                Errors = new[] { new Xchange.Connector.SDK.Action.Error
                {
                    Source = new[] { "CreateFileHandler" },
                    Text = "Invalid input data"
                }}
            });
        }

        try
        {
            var response = await _apiClient.CreateFile(
                input.FileData,
                input.FileName,
                input.BusinessUnitId,
                input.JobId,
                cancellationToken);

            if (!response.IsSuccessful)
            {
                return ActionHandlerOutcome.Failed(new StandardActionFailure
                {
                    Code = response.StatusCode.ToString(),
                    Errors = new[] { new Xchange.Connector.SDK.Action.Error
                    {
                        Source = new[] { "CreateFileHandler" },
                        Text = $"Failed to create file. Status code: {response.StatusCode}"
                    }}
                });
            }

            // Get the full file details for cache sync
            var fileDetails = await _apiClient.GetFileMetadata(response.Data, cancellationToken);
            if (fileDetails.Data != null)
            {
                var operations = new List<SyncOperation>();
                var keyResolver = new DefaultDataObjectKey();
                var key = keyResolver.BuildKeyResolver()(fileDetails.Data);
                operations.Add(SyncOperation.CreateSyncOperation(
                    UpdateOperation.Upsert.ToString(), 
                    key.UrlPart, 
                    key.PropertyNames, 
                    fileDetails.Data));

                var resultList = new List<CacheSyncCollection>
                {
                    new() { 
                        DataObjectType = typeof(FileDataObject), 
                        CacheChanges = operations.ToArray() 
                    }
                };

                return ActionHandlerOutcome.Successful(new CreateFileActionOutput { Id = response.Data }, resultList);
            }

            return ActionHandlerOutcome.Successful(new CreateFileActionOutput { Id = response.Data });
        }
        catch (HttpRequestException exception)
        {
            _logger.LogError(exception, "Error creating file");
            return ActionHandlerOutcome.Failed(new StandardActionFailure
            {
                Code = exception.StatusCode?.ToString() ?? "500",
                Errors = new[] { new Xchange.Connector.SDK.Action.Error
                {
                    Source = new[] { "CreateFileHandler", exception.Source ?? "Unknown" },
                    Text = exception.Message
                }}
            });
        }
    }
}
