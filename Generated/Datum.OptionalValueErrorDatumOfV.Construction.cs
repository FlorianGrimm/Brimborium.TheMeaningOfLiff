namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>(
        this NoDatum optional
    ) {
        return new OptionalValueErrorDatum<V>(
           OptionalValueErrorMode.NoValue,
           optional,
           default,
           default
        );
    }

    // generated 4 Construction
    public static OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>(
        this ValueDatum<V> value
    ) {
        return new OptionalValueErrorDatum<V>(
           OptionalValueErrorMode.Value,
           default,
           value,
           default
        );
    }

    // generated 4 Construction
    public static OptionalValueErrorDatum<V> AsOptionalValueErrorDatum<V>(
        this ErrorDatum error
    ) {
        return new OptionalValueErrorDatum<V>(
           OptionalValueErrorMode.Error,
           default,
           default,
           error
        );
    }

    // generated 4 TryCatch
    public static OptionalValueErrorDatum<V> TryCatch<V>(this Func<OptionalValueErrorDatum<V>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueErrorDatum<V>();
        }
    }

    public static OptionalValueErrorDatum<V> TryCatch<V, A>(this A arg, Func<A, OptionalValueErrorDatum<V>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueErrorDatum<V>();
        }
    }

    public static async Task<OptionalValueErrorDatum<V>> TryCatch<V>(this Task<OptionalValueErrorDatum<V>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalValueErrorDatum<V>();
        }
    }


}
