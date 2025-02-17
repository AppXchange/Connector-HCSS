using ESR.Hosting.CacheWriter;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Xchange.Connector.SDK.CacheWriter;
using System.Threading.Tasks;

namespace Connector.HeavyJob.v1.QuantityAdjustment;

public class QuantityAdjustmentDataReader : TypedAsyncDataReaderBase<QuantityAdjustmentDataObject>
{
    private readonly ILogger<QuantityAdjustmentDataReader> _logger;

    public QuantityAdjustmentDataReader(
        ILogger<QuantityAdjustmentDataReader> logger)
    {
        _logger = logger;
    }

    public override async IAsyncEnumerable<QuantityAdjustmentDataObject> GetTypedDataAsync(
        DataObjectCacheWriteArguments? dataObjectRunArguments,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        yield break;
    }
}