namespace Brimborium.TheMeaningOfLiff {
    [DebuggerNonUserCode]
    public static partial class MeaningLoggerExtension {
        [LoggerMessage(
            Level = LogLevel.Debug,
            Message = "precondition true {datum}"
            )]
        public static partial void LogTruePrecondition(this ILogger logger, ValueDatum<bool> datum);

        [LoggerMessage(
        Level = LogLevel.Debug,
        Message = "precondition false {datum}"
        )]
        public static partial void LogFalsePrecondition(this ILogger logger, ValueDatum<bool> datum);

        public static void LogPrecondition(this ILogger logger, ValueDatum<bool> datum) {
            if (logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Debug)) {
                if (datum.Value) {
                    logger.LogTruePrecondition(datum);
                } else {
                    logger.LogFalsePrecondition(datum);
                }
            }
        }


        [LoggerMessage(
            Level = LogLevel.Debug,
            Message = "true condition {datum}"
            )]
        public static partial void LogTrueCondition(this ILogger logger, ValueDatum<bool> datum);

        [LoggerMessage(
            Level = LogLevel.Debug,
            Message = "false condition {datum}"
            )]
        public static partial void LogFalseCondition(this ILogger logger, ValueDatum<bool> datum);

        public static void LogCondition(this ILogger logger, ValueDatum<bool> datum) {
            if (!logger.IsEnabled(LogLevel.Debug)) {
                return;
            }
            if (datum.Value) {
                logger.LogTrueCondition(datum);
            } else {
                logger.LogFalseCondition(datum);
            }
        }

        [LoggerMessage(
            Level = LogLevel.Debug,
            Message = "flowcondition {meaning}"
            )]
        public static partial void LogFlowControl(this ILogger logger, string meaning);

        public static void LogFlowControl(this ILogger logger, IWithMeaning datum) {
            if (!logger.IsEnabled(LogLevel.Debug)) { return; }
            var meaning = datum.Meaning;
            if (!string.IsNullOrEmpty(meaning)) {
                logger.LogFlowControl(meaning!);
            }
        }

        /*
        private static readonly global::System.Action<global::Microsoft.Extensions.Logging.ILogger, global::Brimborium.TheMeaningOfLiff.Datum<T>, global::System.Exception?> __LogOptionalDatumCallback =
                global::Microsoft.Extensions.Logging.LoggerMessage.Define<global::Brimborium.TheMeaningOfLiff.Datum<T>>(global::Microsoft.Extensions.Logging.LogLevel.Debug, new global::Microsoft.Extensions.Logging.EventId(883052218, nameof(LogTrueCondition)), "OptionalDatum {datum}", new global::Microsoft.Extensions.Logging.LogDefineOptions() { SkipEnabledCheck = true });
        
        public static partial void LogOptionalDatum<T>(this global::Microsoft.Extensions.Logging.ILogger logger, global::Brimborium.TheMeaningOfLiff.Datum<T> datum) {
            if (logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Debug)) {
                __LogOptionalDatumCallback(logger, datum, null);
            }
        }
        */
    }
}
