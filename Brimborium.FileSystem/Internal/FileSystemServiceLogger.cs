using Microsoft.Extensions.Logging;

using Brimborium.TheMeaningOfLiff;

namespace Brimborium.FileSystem.Internal;
public static partial class FileSystemServiceLogger {
    [LoggerMessage(
        EventId = 1,
        EventName = "WriteAllTextAsync",
        Level = LogLevel.Trace,
        Message = "{Result} via {listFlowCondition}")]
    public static partial void TraceWriteAllTextAsyncResult(
        this ILogger logger,
        OptionalDatumError<bool> result,
        FlowCondition[] listFlowCondition
        );

    [LoggerMessage(
        EventId = 2,
        EventName = "WriteAllTextAsyncFailed",
        Level = LogLevel.Warning,
        Message = "{Result} via {listFlowCondition}")]
    public static partial void WarningWriteAllTextAsyncResult(
        this ILogger logger,
        OptionalDatumError<bool> result,
        FlowCondition[] listFlowCondition
        );
}
