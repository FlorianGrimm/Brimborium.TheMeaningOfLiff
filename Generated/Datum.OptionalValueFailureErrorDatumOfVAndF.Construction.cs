namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this NoDatum optional
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.NoValue,
           optional,
           default,
           default,
           default
        );
    }

    // generated 4 Construction
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.Value,
           default,
           value,
           default,
           default
        );
    }

    // generated 4 Construction
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.Failure,
           default,
           default,
           failure,
           default
        );
    }

    // generated 4 Construction
    public static OptionalValueFailureErrorDatum<V, F> AsOptionalValueFailureErrorDatum<V, F>(
        this ErrorDatum error
    ) {
        return new OptionalValueFailureErrorDatum<V, F>(
           OptionalValueFailureErrorMode.Error,
           default,
           default,
           default,
           error
        );
    }

    // generated 4 TryCatch
    public static OptionalValueFailureErrorDatum<V, F> TryCatch<V, F>(this Func<OptionalValueFailureErrorDatum<V, F>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueFailureErrorDatum<V, F>();
        }
    }

    public static OptionalValueFailureErrorDatum<V, F> TryCatch<V, F, A>(this A arg, Func<A, OptionalValueFailureErrorDatum<V, F>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueFailureErrorDatum<V, F>();
        }
    }

    public static async Task<OptionalValueFailureErrorDatum<V, F>> TryCatch<V, F>(this Task<OptionalValueFailureErrorDatum<V, F>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueFailureErrorDatum<V, F>();
        }
    }


}
