namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static ValueDatumErrorDatumDatum<V> AsValueDatumErrorDatumDatum<V>(
        this ValueDatum<V> value
    ) {
        return new ValueDatumErrorDatumDatum<V>(
            ValueDatumErrorDatumMode.Value,
            value,
            default
        );
    }

    // generated 4 Construction
    public static ValueDatumErrorDatumDatum<V> AsValueDatumErrorDatumDatum<V>(
        this ErrorDatum error
    ) {
        return new ValueDatumErrorDatumDatum<V>(
            ValueDatumErrorDatumMode.Error,
            default,
            error
        );
    }

    // generated 4 TryCatch
    public static ValueDatumErrorDatumDatum<V> TryCatch<V>(this Func<ValueDatumErrorDatumDatum<V>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumErrorDatumDatum<V>();
        }
    }

    public static ValueDatumErrorDatumDatum<V> TryCatch<V, A>(this A arg, Func<A, ValueDatumErrorDatumDatum<V>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumErrorDatumDatum<V>();
        }
    }

    public static async Task<ValueDatumErrorDatumDatum<V>> TryCatch<V>(this Task<ValueDatumErrorDatumDatum<V>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueDatumErrorDatumDatum<V>();
        }
    }


}
