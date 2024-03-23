namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static ValueErrorDatum<V> AsValueErrorDatum<V>(
        this ValueDatum<V> value
    ) {
        return new ValueErrorDatum<V>(
            ValueErrorMode.Value,
            value,
            default
        );
    }

    // generated 4 Construction
    public static ValueErrorDatum<V> AsValueErrorDatum<V>(
        this ErrorDatum error
    ) {
        return new ValueErrorDatum<V>(
            ValueErrorMode.Error,
            default,
            error
        );
    }

    // generated 4 TryCatch
    public static ValueErrorDatum<V> TryCatch<V>(this Func<ValueErrorDatum<V>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueErrorDatum<V>();
        }
    }

    public static ValueErrorDatum<V> TryCatch<V, A>(this A arg, Func<A, ValueErrorDatum<V>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueErrorDatum<V>();
        }
    }

    public static async Task<ValueErrorDatum<V>> TryCatch<V>(this Task<ValueErrorDatum<V>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsValueErrorDatum<V>();
        }
    }


}

// generated 4
