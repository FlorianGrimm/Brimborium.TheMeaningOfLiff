namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new ValueFailureErrorDatum<V, F>(
            ValueFailureErrorMode.Value,
            value,
            default,
            default
        );
    }

    // generated 4 Construction
    public static ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new ValueFailureErrorDatum<V, F>(
            ValueFailureErrorMode.Failure,
            default,
            failure,
            default
        );
    }

    // generated 4 Construction
    public static ValueFailureErrorDatum<V, F> AsValueFailureErrorDatum<V, F>(
        this ErrorDatum error
    ) {
        return new ValueFailureErrorDatum<V, F>(
            ValueFailureErrorMode.Error,
            default,
            default,
            error
        );
    }

    // generated 4 TryCatch
    public static ValueFailureErrorDatum<V, F> TryCatch<V, F>(this Func<ValueFailureErrorDatum<V, F>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<V, F>();
        }
    }

    public static ValueFailureErrorDatum<V, F> TryCatch<V, F, A>(this A arg, Func<A, ValueFailureErrorDatum<V, F>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<V, F>();
        }
    }

    public static async Task<ValueFailureErrorDatum<V, F>> TryCatch<V, F>(this Task<ValueFailureErrorDatum<V, F>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueFailureErrorDatum<V, F>();
        }
    }


}
