namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static ValueDatumFailureDatumErrorDatumDatum<V, F> AsValueDatumFailureDatumErrorDatumDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new ValueDatumFailureDatumErrorDatumDatum<V, F>(
            ValueDatumFailureDatumErrorDatumMode.Value,
            value,
            default,
            default
        );
    }

    // generated 4 Construction
    public static ValueDatumFailureDatumErrorDatumDatum<V, F> AsValueDatumFailureDatumErrorDatumDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new ValueDatumFailureDatumErrorDatumDatum<V, F>(
            ValueDatumFailureDatumErrorDatumMode.Failure,
            default,
            failure,
            default
        );
    }

    // generated 4 Construction
    public static ValueDatumFailureDatumErrorDatumDatum<V, F> AsValueDatumFailureDatumErrorDatumDatum<V, F>(
        this ErrorDatum error
    ) {
        return new ValueDatumFailureDatumErrorDatumDatum<V, F>(
            ValueDatumFailureDatumErrorDatumMode.Error,
            default,
            default,
            error
        );
    }

    // generated 4 TryCatch
    public static ValueDatumFailureDatumErrorDatumDatum<V, F> TryCatch<V, F>(this Func<ValueDatumFailureDatumErrorDatumDatum<V, F>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumFailureDatumErrorDatumDatum<V, F>();
        }
    }

    public static ValueDatumFailureDatumErrorDatumDatum<V, F> TryCatch<V, F, A>(this A arg, Func<A, ValueDatumFailureDatumErrorDatumDatum<V, F>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumFailureDatumErrorDatumDatum<V, F>();
        }
    }

    public static async Task<ValueDatumFailureDatumErrorDatumDatum<V, F>> TryCatch<V, F>(this Task<ValueDatumFailureDatumErrorDatumDatum<V, F>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumFailureDatumErrorDatumDatum<V, F>();
        }
    }


}
