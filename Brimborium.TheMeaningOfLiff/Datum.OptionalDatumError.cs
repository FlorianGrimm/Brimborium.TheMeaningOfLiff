namespace Brimborium.TheMeaningOfLiff;

/// <summary>
/// Extensions for <see cref="OptionalDatumError{T}"/>
/// </summary>
public static partial class Datum {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <returns></returns>
    public static OptionalDatumError<T> ToOptionalResult<T>(this T that)
        => new OptionalDatumError<T>(that);

    public static OptionalDatumError<T> If<T>(this OptionalDatumError<T> that, Func<T, bool> predicate) {
        if (that.TryGetValue(out var v)) {
            if (predicate(v)) {
                return that;
            }
        } else if (that.TryGetError(out var error)) {
            return new OptionalDatumError<T>(error);
        }
        return new OptionalDatumError<T>();
    }

    public static OptionalDatumError<T> If<T, A>(this OptionalDatumError<T> that, A args, Func<T, A, bool> predicate) {
        if (that.TryGetValue(out var v)) {
            if (predicate(v, args)) {
                return that;
            }
        } else if (that.TryGetError(out var error)) {
            return new OptionalDatumError<T>(error);
        }
        return new OptionalDatumError<T>();
    }

    public static OptionalDatumError<R> Map<T, R>(this OptionalDatumError<T> that, Func<T, OptionalDatumError<R>> predicate) {
        if (that.TryGetValue(out var v)) {
            return predicate(v);
        } else if (that.TryGetError(out var error)) {
            return new OptionalDatumError<R>(error);
        } else {
            return new OptionalDatumError<R>();
        }
    }

    public static OptionalDatumError<R> Map<T, A, R>(this OptionalDatumError<T> that, A args, Func<T, A, OptionalDatumError<R>> predicate) {
        if (that.TryGetValue(out var v)) {
            return predicate(v, args);
        } else if (that.TryGetError(out var error)) {
            return new OptionalDatumError<R>(error);
        } else {
            return new OptionalDatumError<R>();
        }
    }

    public static OptionalDatumError<T> OrDefault<T, A>(this OptionalDatumError<T> that, A args, Func<A, OptionalDatumError<T>> fnDefaultValue) {
        if (that.TryGetValue(out var _)) {
            return that;
        } else if (that.TryGetError(out var error)) {
            return new OptionalDatumError<T>(error);
        } else {
            return fnDefaultValue(args);
        }
    }

    public static OptionalDatumError<T> OrDefault<T>(this OptionalDatumError<T> that, OptionalDatumError<T> defaultValue) {
        if (that.TryGetValue(out var _)) {
            return that;
        } else if (that.TryGetError(out var error)) {
            return new OptionalDatumError<T>(error);
        } else {
            return defaultValue;
        }
    }


    public static OptionalDatumError<R> Try<T, A, R>(this OptionalDatumError<T> that, A args, Func<T, A, OptionalDatumError<R>> action) {
        try {
            if (that.TryGetValue(out var v)) {
                return action(v, args);
            } else if (that.TryGetError(out var error)) {
                return new OptionalDatumError<R>(error);
            } else {
                return new OptionalDatumError<R>();
            }
        } catch (Exception ex) {
            return new OptionalDatumError<R>(ErrorValue.CreateFromCatchedException(ex));
        }
    }

    public static OptionalDatumError<T> Catch<T>(this OptionalDatumError<T> that, Func<ErrorValue, OptionalDatumError<T>> fnDefaultValue) {
        if (that.TryGetError(out var error)) {
            return fnDefaultValue(error);
        } else {
            return that;
        }
    }

    public static OptionalDatumError<T> Catch<T, A>(this OptionalDatumError<T> value, A args, Func<ErrorValue, A, OptionalDatumError<T>> fnDefaultValue) {
        if (value.TryGetError(out var error)) {
            return fnDefaultValue(error, args);
        } else {
            return value;
        }
    }

    public static OptionalDatumError<R> Chain<T, R>(
        this OptionalDatumError<T> that,
        OptionalDatumError<R> defaultValue = default,
        Func<T, OptionalDatumError<R>, OptionalDatumError<R>>? onSuccess = default,
        Func<OptionalDatumError<R>, OptionalDatumError<R>>? onNoValue = default,
        Func<ErrorValue, OptionalDatumError<R>, OptionalDatumError<R>>? onError = default
    ) {
        if (that.TryGetError(out var error, out var opt)) {
            if (onError is null) {
                return new OptionalDatumError<R>(error);
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

    public static OptionalDatumError<R> Chain<T, A, R>(
        this OptionalDatumError<T> that,
        A args,
        OptionalDatumError<R> defaultValue = default,
        Func<T, A, OptionalDatumError<R>, OptionalDatumError<R>>? onSuccess = default,
        Func<A, OptionalDatumError<R>, OptionalDatumError<R>>? onNoValue = default,
        Func<ErrorValue, A, OptionalDatumError<R>, OptionalDatumError<R>>? onError = default
    ) {
        if (that.TryGetError(out var error)) {
            if (onError is null) {
                return new OptionalDatumError<R>(error);
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
}