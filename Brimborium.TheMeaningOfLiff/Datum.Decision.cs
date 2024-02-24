namespace Brimborium.TheMeaningOfLiff {
    public static partial class Datum {

        [LoggerMessage(
            EventId = 588211920,
            EventName = "Decision",
            Level = LogLevel.Debug,
            Message = "Decision {meaning} {decision}"
            )]
        public static partial void LogDecision(this ILogger logger, string meaning, bool decision);

        public static class LogGeneric<T> {
            private static readonly global::System.Action<
                global::Microsoft.Extensions.Logging.ILogger,
                string, bool, T,
                global::System.Exception?
                > __LogDecisionCallback =

            global::Microsoft.Extensions.Logging.LoggerMessage.Define<
                string, bool, T
                >(global::Microsoft.Extensions.Logging.LogLevel.Debug,
                new global::Microsoft.Extensions.Logging.EventId(588211921, "Decision"),
                "Decision {meaning} {decision} {value}",
                new global::Microsoft.Extensions.Logging.LogDefineOptions() {
                    SkipEnabledCheck = true
                });

            public static void LogDecisionValue(
                ILogger logger,
                string meaning,
                bool decision,
                T value) {
                if (logger.IsEnabled(LogLevel.Debug)) {
                    __LogDecisionCallback(logger, meaning, decision, value, null);
                }
            }
        }
    }
}
