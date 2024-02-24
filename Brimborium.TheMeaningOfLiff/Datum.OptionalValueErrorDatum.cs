namespace Brimborium.TheMeaningOfLiff;

/// <summary>
/// Extensions for <see cref="OptionalValueErrorDatum{T}"/>
/// </summary>
public static partial class Datum {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <returns></returns>
    public static OptionalValueErrorDatum<T> ToOptionalResult<T>(this T that)
        => new OptionalValueErrorDatum<T>(that);

    public static OptionalValueErrorDatum<T> If<T>(this OptionalValueErrorDatum<T> that, Func<T, bool> predicate, NoDatum elseDatum = default) {
        if (that.TryGetValue(out var t)) {
            if (predicate(t)) {
                return that;
            } else {
                return elseDatum;
            }
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<T>(error);
        } else if (that.TryGetNoValue(out var f)) {
            return f;
        }
        return new OptionalValueErrorDatum<T>();
    }

    public static async Task<OptionalValueErrorDatum<T>> IfAsync<T>(this Task<OptionalValueErrorDatum<T>> thatTask, Func<T, bool> predicate, NoDatum elseDatum = default) {
        try {
            var that = await thatTask;
            if (that.TryGetValue(out var t)) {
                if (predicate(t)) {
                    return that;
                } else {
                    return elseDatum;
                }
            } else if (that.TryGetError(out var error)) {
                return new OptionalValueErrorDatum<T>(error);
            } else if (that.TryGetNoValue(out var f)) {
                return f;
            }
        } catch (System.Exception error){
            return ErrorDatum.CreateFromCatchedException(error);
        }
        return new OptionalValueErrorDatum<T>();
    }

    public static OptionalValueErrorDatum<T> If<T, A>(this OptionalValueErrorDatum<T> that, A args, Func<T, A, bool> predicate, NoDatum elseDatum = default) {
        if (that.TryGetValue(out var v)) {
            if (predicate(v, args)) {
                return that;
            } else {
                return elseDatum;
            }
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<T>(error);
        } else if (that.TryGetNoValue(out var f)) {
            return f;
        }
        return new OptionalValueErrorDatum<T>();
    }

    public static OptionalValueDatum<R> IfMap<T, R>(this OptionalValueDatum<T> that, Func<T, bool> predicate, Func<T, OptionalValueDatum<R>> map, NoDatum elseDatum = default) {
        if (that.TryGetValue(out var t, out var f)) {
            if (predicate(t)) {
                return map(t);
            } else {
                return elseDatum;
            }
        } else {
            return f;
        }
    }

    public static OptionalValueErrorDatum<R> IfMap<T, R>(this OptionalValueErrorDatum<T> that,  Func<T, bool> predicate, Func<T, OptionalValueErrorDatum<R>> map, NoDatum elseDatum = default) {
        if (that.TryGetValue(out var v)) {
            if (predicate(v)) {
                return map(v);
            } else {
                return elseDatum;
            }
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<R>(error);
        } else if (that.TryGetNoValue(out var f)) {
            return f;
        }
        return new OptionalValueErrorDatum<R>();
    }

    public static OptionalValueErrorDatum<R> IfMap<T, A, R>(this OptionalValueErrorDatum<T> that, A args, Func<T, A, bool> predicate, Func<T, A, OptionalValueErrorDatum<R>> map, NoDatum elseDatum = default) {
        if (that.TryGetValue(out var v)) {
            if (predicate(v, args)) {
                return map(v, args);
            } else {
                return elseDatum;
            }
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<R>(error);
        } else if (that.TryGetNoValue(out var f)) {
            return f;
        }
        return new OptionalValueErrorDatum<R>();
    }



    public static OptionalValueErrorDatum<R> Map<T, R>(this OptionalValueErrorDatum<T> that, Func<T, OptionalValueErrorDatum<R>> fnMap) {
        if (that.TryGetValue(out var v)) {
            return fnMap(v);
        } else if (that.TryGetNoValue(out var noDatum)) {
            return noDatum;
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<R>(error);
        } else {
            return new OptionalValueErrorDatum<R>();
        }
    }

    public static OptionalValueErrorDatum<R> Map<T, A, R>(this OptionalValueErrorDatum<T> that, A args, Func<T, A, OptionalValueErrorDatum<R>> fnMap) {
        if (that.TryGetValue(out var v)) {
            return fnMap(v, args);
        } else if (that.TryGetNoValue(out var noDatum)) {
            return noDatum;
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<R>(error);
        } else {
            return new OptionalValueErrorDatum<R>();
        }
    }

    public static async Task<OptionalValueErrorDatum<R>> MapAsync<T, R>(this OptionalValueDatum<T> value, Func<T, Task<OptionalValueErrorDatum<R>>> fnMapAsync) {
        if (value.TryGetValue(out var vt, out var vf)) {
            try {
                var result = await fnMapAsync(vt);
                return result;
            } catch (System.Exception error) {
                return ErrorDatum.CreateFromCatchedException(error);
            }
        } else {
            return vf;
        }
    }

    public static async Task<OptionalValueErrorDatum<R>> MapAsync<T, R>(this OptionalValueErrorDatum<T> that, Func<T, Task<OptionalValueErrorDatum<R>>> fnMap) {
        if (that.TryGetValue(out var v)) {
            try {
                return await fnMap(v);
            } catch (Exception error) {
                return ErrorDatum.CreateFromCatchedException(error);
            }
        } else if (that.TryGetNoValue(out var noDatum)) {
            return noDatum;
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<R>(error);
        } else {
            return new OptionalValueErrorDatum<R>();
        }
    }

    public static async Task<OptionalValueErrorDatum<R>> MapAsync<T, A, R>(this OptionalValueErrorDatum<T> that, A args, Func<T, A, Task<OptionalValueErrorDatum<R>>> fnMap) {
        if (that.TryGetValue(out var v)) {
            try {
                return await fnMap(v, args);
            } catch (Exception error) {
                return ErrorDatum.CreateFromCatchedException(error);
            }
        } else if (that.TryGetNoValue(out var noDatum)) {
            return noDatum;
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<R>(error);
        } else {
            return new OptionalValueErrorDatum<R>();
        }
    }

    public static OptionalValueErrorDatum<T> OrDefault<T, A>(this OptionalValueErrorDatum<T> that, A args, Func<A, OptionalValueErrorDatum<T>> fnDefaultValue) {
        if (that.TryGetValue(out var _)) {
            return that;
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<T>(error);
        } else {
            return fnDefaultValue(args);
        }
    }

    public static OptionalValueErrorDatum<T> OrDefault<T>(this OptionalValueErrorDatum<T> that, OptionalValueErrorDatum<T> defaultValue) {
        if (that.TryGetValue(out var _)) {
            return that;
        } else if (that.TryGetError(out var error)) {
            return new OptionalValueErrorDatum<T>(error);
        } else {
            return defaultValue;
        }
    }


    public static OptionalValueErrorDatum<R> Try<T, A, R>(this OptionalValueErrorDatum<T> that, A args, Func<T, A, OptionalValueErrorDatum<R>> action) {
        try {
            if (that.TryGetValue(out var v)) {
                return action(v, args);
            } else if (that.TryGetError(out var error)) {
                return new OptionalValueErrorDatum<R>(error);
            } else {
                return new OptionalValueErrorDatum<R>();
            }
        } catch (Exception ex) {
            return new OptionalValueErrorDatum<R>(ErrorDatum.CreateFromCatchedException(ex));
        }
    }

    public static OptionalValueErrorDatum<T> Catch<T>(this OptionalValueErrorDatum<T> that, Func<ErrorDatum, OptionalValueErrorDatum<T>> fnDefaultValue) {
        if (that.TryGetError(out var error)) {
            return fnDefaultValue(error);
        } else {
            return that;
        }
    }

    public static OptionalValueErrorDatum<T> Catch<T, A>(this OptionalValueErrorDatum<T> value, A args, Func<ErrorDatum, A, OptionalValueErrorDatum<T>> fnDefaultValue) {
        if (value.TryGetError(out var error)) {
            return fnDefaultValue(error, args);
        } else {
            return value;
        }
    }

    public static OptionalValueErrorDatum<R> Chain<T, R>(
        this OptionalValueErrorDatum<T> that,
        OptionalValueErrorDatum<R> defaultValue = default,
        Func<T, OptionalValueErrorDatum<R>, OptionalValueErrorDatum<R>>? onSuccess = default,
        Func<OptionalValueErrorDatum<R>, OptionalValueErrorDatum<R>>? onNoValue = default,
        Func<ErrorDatum, OptionalValueErrorDatum<R>, OptionalValueErrorDatum<R>>? onError = default
    ) {
        if (that.TryGetError(out var error, out var opt)) {
            if (onError is null) {
                return new OptionalValueErrorDatum<R>(error);
            } else {
                return onError(error, defaultValue);
            }
        }
        if (opt.TryGetValue(out var value)) {
            if (onSuccess is null) {
                return defaultValue;
            } else {
                return onSuccess(value, defaultValue);
            }
        }
        {
            if (onNoValue is null) {
                return defaultValue;
            } else {
                return onNoValue(defaultValue);
            }
        }
    }

    public static OptionalValueErrorDatum<R> Chain<T, A, R>(
        this OptionalValueErrorDatum<T> that,
        A args,
        OptionalValueErrorDatum<R> defaultValue = default,
        Func<T, A, OptionalValueErrorDatum<R>, OptionalValueErrorDatum<R>>? onSuccess = default,
        Func<A, OptionalValueErrorDatum<R>, OptionalValueErrorDatum<R>>? onNoValue = default,
        Func<ErrorDatum, A, OptionalValueErrorDatum<R>, OptionalValueErrorDatum<R>>? onError = default
    ) {
        if (that.TryGetError(out var error)) {
            if (onError is null) {
                return new OptionalValueErrorDatum<R>(error);
            } else {
                return onError(error, args, defaultValue);
            }
        }
        if (that.TryGetValue(out var value)) {
            if (onSuccess is null) {
                return defaultValue;
            } else {
                return onSuccess(value, args, defaultValue);
            }
        }
        {
            if (onNoValue is null) {
                return defaultValue;
            } else {
                return onNoValue(args, defaultValue);
            }
        }
    }

    public static bool DecisionOnTrue(this OptionalValueErrorDatum<bool> datum, ILogger logger, [CallerMemberName] string? callerMemberName = default) {
        if (datum.TryGetValue(out var result)) {
            logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, result);
            return result;
        } else if (datum.TryGetError(out var errorValue)) {
            if (!errorValue.IsLogged) { logger.LogDebug(errorValue.Exception, null); }
            return false;
        } else {
            logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, false);
            return false;
        }
    }
    public static bool DecisionOnValueDatum<T>(this OptionalValueErrorDatum<T> datum, ILogger logger, [CallerMemberName] string? callerMemberName = default) {
        if (datum.TryGetValue(out var value)) {
            LogGeneric<T>.LogDecisionValue(logger, datum.Meaning ?? callerMemberName ?? string.Empty, true, value);
            return true;
        } else if (datum.TryGetError(out var errorValue)) {
            if (!errorValue.IsLogged) { logger.LogDebug(errorValue.Exception, null); }
            return false;
        } else {
            logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, false);
            return false;
        }
    }

    public static bool DecisionOnCondition<T>(this OptionalValueErrorDatum<T> datum, Func<T, bool> accept, ILogger logger, [CallerMemberName] string? callerMemberName = default)
        where T : notnull {
        if (datum.TryGetValue(out var value)) {
            bool result = accept(value);
            LogGeneric<T>.LogDecisionValue(logger, datum.Meaning ?? callerMemberName ?? string.Empty, result, value);
            return result;
        } else if (datum.TryGetError(out var errorValue)) {
            if (!errorValue.IsLogged) { logger.LogDebug(errorValue.Exception, null); }
            return false;
        } else {
            logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, false);
            return false;
        }
    }

    public static bool DecisionEquals<T>(this OptionalValueErrorDatum<T> datum, T accepted, ILogger logger, [CallerMemberName] string? callerMemberName = default)
        where T : notnull {
        if (datum.TryGetValue(out var value)) {
            bool result = accepted.Equals(value);
            logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, result);
            return result;
        } else if (datum.TryGetError(out var errorValue)) {
            if (!errorValue.IsLogged) { logger.LogDebug(errorValue.Exception, string.Empty); }
            return false;
        } else {
            logger.LogDecision(datum.Meaning ?? callerMemberName ?? string.Empty, false);
            return false;
        }
    }

    public static bool DecisionOnValueDatumTryGet<T>(
        this OptionalValueErrorDatum<T> datum,
        ILogger logger,
        [MaybeNullWhen(false)] out T value,
        [MaybeNullWhen(true)] out OptionalErrorDatum elseDatum,
        [CallerMemberName] string? callerMemberName = default) {
        if (datum.Mode == OptionalValueErrorDatumMode.Success) {
            value = datum.ValueDatum.Value;
            elseDatum = default;
            logger.LogDecision(datum.ValueDatum.Meaning ?? callerMemberName ?? string.Empty, true);
            return true;
        } else if (datum.Mode == OptionalValueErrorDatumMode.Error) {
            value = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorDatumMode.Error, default!, datum.ErrorDatum);
            logger.LogDecision(datum.ErrorDatum.Meaning ?? callerMemberName ?? string.Empty, false);
            return false;
        } else {
            value = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorDatumMode.Error, datum.NoValue, default!);
            logger.LogDecision(datum.NoValue.Meaning ?? callerMemberName ?? string.Empty, false);
            return false;
        }
    }
}