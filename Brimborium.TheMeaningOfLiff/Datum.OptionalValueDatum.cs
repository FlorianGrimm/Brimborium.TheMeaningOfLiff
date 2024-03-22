namespace Brimborium.TheMeaningOfLiff;

#if TODO
public static partial class Datum {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static OptionalValueDatum<T> AsOptionalValueDatum<T>(
        this T value,
        string? meaning = default,
        long logicalTimestamp = 0) {
        return new OptionalValueDatum<T>(OptionalValueMode.Value, default, new ValueDatum<T>(value, meaning, logicalTimestamp));
    }

    public static OptionalValueDatum<R> AsOptionalOfType<T, R>(
        this T that,
        string? meaning = default,
        long logicalTimestamp = 0) {
        if (that is R valueR) {
            return new OptionalValueDatum<R>(OptionalValueMode.Value, default, new ValueDatum<R>(valueR, meaning, logicalTimestamp));
        } else {
            return new NoDatum(meaning, logicalTimestamp);
        }
    }

    public static OptionalValueDatum<T> AsOptionalNotNull<T>(
        [AllowNull] this T? value,
        string? meaningNotNull = default,
        string? meaningNull = default,
        long logicalTimestamp = 0)
        where T : class {
        if (value is null) {
            return new OptionalValueDatum<T>(OptionalValueMode.NoValue, new NoDatum(meaningNull, logicalTimestamp), default);
        } else {
            return new OptionalValueDatum<T>(OptionalValueMode.Value, default, new ValueDatum<T>(value, meaningNotNull, logicalTimestamp));
        }
    }

    public static OptionalValueDatum<T> WithValueNotNull<T>(
        this OptionalValueDatum<T> that,
        T? value,
        string? meaning = default,
        long logicalTimestamp = 0)
        where T : class {
        if (value is null) {
            return new OptionalValueDatum<T>(
                OptionalValueMode.NoValue,
                new NoDatum(meaning ?? that.Meaning, LogicalTimestampUtility.Next(that.LogicalTimestamp, logicalTimestamp)),
                default);
        } else {
            return new OptionalValueDatum<T>(
                OptionalValueMode.Value,
                default,
                new ValueDatum<T>(value, meaning ?? that.Meaning, LogicalTimestampUtility.Next(that.LogicalTimestamp, logicalTimestamp)));
        }
    }

    public static T? GetValueOrDefault<T>(
        this OptionalValueDatum<T> that,
        T? defaultValue = default)
        where T : class
    => that.Mode switch {
        OptionalValueMode.NoValue => defaultValue,
        OptionalValueMode.Value => that.Value.Value,
        _ => defaultValue
    };

    public static ValueDatum<R> MapDatum<T, R>(this OptionalValueDatum<T> value, Func<T, ValueDatum<R>> fnMap, ValueDatum<R> defaultValue) {
        if (value.TryGetValue(out var v)) {
            return fnMap(v);
        } else {
            return defaultValue;
        }
    }

    public static ValueDatum<R> MapDatum<T, A, R>(this OptionalValueDatum<T> value, A args, Func<T, A, ValueDatum<R>> fnMap, ValueDatum<R> defaultValue) {
        if (value.TryGetValue(out var v)) {
            return fnMap(v, args);
        } else {
            return defaultValue;
        }
    }


    public static OptionalValueDatum<T> If<T>(this OptionalValueDatum<T> value, Func<T, bool> predicate, NoDatum elseDatum = default) {
        if (value.TryGetValue(out var t, out var f)) {
            if (predicate(t)) {
                return value;
            } else {
                return elseDatum;
            }
        } else {
            return f;
        }
    }

    public static OptionalValueDatum<T> If<T, A>(this OptionalValueDatum<T> value, A args, Func<T, A, bool> predicate, NoDatum elseDatum = default) {
        if (value.TryGetValue(out var t, out var f)) {
            if (predicate(t, args)) {
                return value;
            } else {
                return elseDatum;
            }
        } else {
            return f;
        }
    }

    public static OptionalValueDatum<T> AsOptionalDatumNotNull<T>(this T? value, NoDatum elseDatum = default) where T : class {
        if (value is not null) {
            return new OptionalValueDatum<T>(OptionalValueMode.Value, default, value);
        } else {
            return elseDatum;
        }
    }

    public static OptionalValueDatum<R> AsOptionalDatumNotNull<T, R>(this T? value, Func<T, OptionalValueDatum<R>> fnMap, NoDatum elseDatum = default) where T : class {
        if (value is not null) {
            return fnMap(value);
        } else {
            return elseDatum;
        }
    }

    public static OptionalValueDatum<T> NotNull<T>(this OptionalValueDatum<T?> datum, NoDatum elseDatum = default) where T : class {
        if (datum.TryGetValue(out var value, out var noDatum)) {
            if (value.Value is not null) {
#warning HERE
                return new OptionalValueDatum<T>(OptionalValueMode.Value, default, new ValueDatum<T>(value.Value, value.Meaning, value.LogicalTimestamp));
            } else {
                return elseDatum;
            }
        } else {
            return noDatum;
        }
    }

    //public static OptionalValueDatum<R> MapOptionalDatum<T, R>(this OptionalValueDatum<T> value, Func<T, OptionalValueDatum<R>> fnMap) {
    //    if (value.TryGetValue(out var vt, out var vf)) {
    //        return fnMap(vt);
    //    } else {
    //        return vf;
    //    }
    //}


    //public static OptionalValueDatum<R> Map<T, A, R>(this OptionalValueDatum<T> value, A args, Func<T, A, OptionalValueDatum<R>> fnMap) {
    //    if (value.TryGetValue(out var vt, out var vf)) {
    //        return fnMap(vt, args);
    //    } else {
    //        return vf;
    //    }
    //}

    //public static OptionalValueDatum<R> Map<T, A, R>(this OptionalValueDatum<T> value, OptionalValueDatum<A> args, Func<T, A, OptionalValueDatum<R>> fnMap) {
    //    if (value.TryGetValue(out var vt, out var vf)) {
    //        if (args.TryGetValue(out var at, out var af)) {
    //            return fnMap(vt, at);
    //        } else {
    //            return af;
    //        }
    //    } else {
    //        return vf;
    //    }
    //}

    //public static async Task<OptionalValueDatum<T>> LogAndIgnoreAsync<T>(this Task<OptionalValueErrorDatum<T>> thatTask, ILogger logger, NoDatum elseDatum = default) {
    //    try {
    //        var that = await thatTask.ConfigureAwait(false);
    //        switch (that.Mode) {
    //            case OptionalValueErrorDatumMode.NoValue: {
    //                    return new OptionalValueDatum<T>(OptionalValueMode.NoValue, that.NoValue, default);
    //                }
    //            case OptionalValueErrorDatumMode.Success:
    //                return new OptionalValueDatum<T>(OptionalValueMode.Success, default, that.ValueDatum);

    //            case OptionalValueErrorDatumMode.Error:
    //                logger.LogDebug("LogAndIgnoreAsync {errorValue}", that.ErrorDatum);
    //                return elseDatum;

    //            default:
    //                return elseDatum;
    //        }
    //    } catch (System.Exception error) {
    //        //var errorDatum = ErrorDatum.CreateFromCatchedException(error);
    //        logger.LogDebug(error, "LogAndIgnoreAsync");
    //        return elseDatum;
    //    }
    //}

    //public static OptionalValueDatum<T> OrDefaultOptionalDatum<T, A>(this OptionalValueDatum<T> value, A args, Func<A, OptionalValueDatum<T>> fnDefaultValue) {
    //    if (value.TryGetValue(out var _)) {
    //        return value;
    //    } else {
    //        return fnDefaultValue(args);
    //    }
    //}

    //public static OptionalValueDatum<T> OrDefaultOptionalDatum<T>(this OptionalValueDatum<T> value, OptionalValueDatum<T> defaultValue) {
    //    if (value.TryGetValue(out var _)) {
    //        return value;
    //    } else {
    //        return defaultValue;
    //    }
    //}

    //public static bool DecisionOnTrue(this OptionalValueDatum<bool> datum, ILogger logger, [CallerMemberName] string? callerMemberName = default) {
    //    if (datum.TryGetValue(out var result, out var noDatum)) {
    //        logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, result);
    //        return result;
    //    } else {
    //        logger.LogDecision(noDatum.Meaning ?? callerMemberName ?? string.Empty, false);
    //        return false;
    //    }
    //}

    //public static bool DecisionOnValueDatum<T>(this OptionalValueDatum<T> datum, ILogger logger, [CallerMemberName] string? callerMemberName = default)
    //    where T : notnull {
    //    if (datum.TryGetValue(out var value, out var noDatum)) {
    //        logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, true);
    //        return true;
    //    } else {
    //        logger.LogDecision(noDatum.Meaning ?? callerMemberName ?? string.Empty, false);
    //        return false;
    //    }
    //}

    //public static bool DecisionOnCondition<T>(this OptionalValueDatum<T> datum, Func<T, bool> accept, ILogger logger, [CallerMemberName] string? callerMemberName = default)
    //    where T : notnull {
    //    if (datum.TryGetValue(out var value, out var noDatum)) {
    //        bool result = accept(value);
    //        logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, result);
    //        return result;
    //    } else {
    //        logger.LogDecision(noDatum.Meaning ?? callerMemberName ?? string.Empty, false);
    //        return false;
    //    }
    //}

    //public static bool DecisionEquals<T>(this OptionalValueDatum<T> datum, T accepted, ILogger logger, [CallerMemberName] string? callerMemberName = default)
    //    where T : notnull {
    //    if (datum.TryGetValue(out var value, out var noDatum)) {
    //        bool result = accepted.Equals(value);
    //        logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, result);
    //        return result;
    //    } else {
    //        logger.LogDecision(noDatum.Meaning ?? callerMemberName ?? string.Empty, false);
    //        return false;
    //    }
    //}

    //public static bool DecisionOnValueDatumTryGet<T>(
    //    this OptionalValueDatum<T> datum,
    //    ILogger logger,
    //    [MaybeNullWhen(false)] out T value,
    //    [MaybeNullWhen(true)] out NoDatum elseDatum,
    //    [CallerMemberName] string? callerMemberName = default) {
    //    if (datum.Mode == OptionalValueMode.Success) {
    //        value = datum.ValueDatum.Value;
    //        elseDatum = default;
    //        logger.LogDecision(datum.ValueDatum.Meaning ?? callerMemberName ?? string.Empty, true);
    //        return true;
    //    } else {
    //        value = default;
    //        elseDatum = datum.NoValue;
    //        logger.LogDecision(datum.NoValue.Meaning ?? callerMemberName ?? string.Empty, false);
    //        return false;
    //    }
    //}
}

#endif
#if UnitTest
public partial class DatumTest {
    [Fact]
    public void AsOptionalOfTypeTest() {
        //var noValue = Datum.NoValue("a");
        //Assert.Equal("a", noValue.Meaning);

        //AsOptionalOfType
        var valueDatum = Datum.AsValueDatum<A>(new B("b"));
        var optValueDatum = valueDatum.AsOptionalOfType<B>();
        var optValueDatum2 = optValueDatum.AsOptionalOfType<B>();

        //var errorDatum = Datum.AsErrorDatum(new Exception(), default, "c");
        //Assert.IsType<Exception>(errorDatum.Exception);
        //Assert.Equal("c", errorDatum.Meaning);
    }
}
#endif
