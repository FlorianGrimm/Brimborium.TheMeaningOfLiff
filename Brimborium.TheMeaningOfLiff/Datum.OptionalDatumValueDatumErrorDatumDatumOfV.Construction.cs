namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalDatumValueDatumErrorDatumDatum<V> AsOptionalDatumValueDatumErrorDatumDatum<V>(
        this NoDatum optional
    ) {
        return new OptionalDatumValueDatumErrorDatumDatum<V>(
            OptionalDatumValueDatumErrorDatumMode.NoValue,
            optional,
            default,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumErrorDatumDatum<V> AsOptionalDatumValueDatumErrorDatumDatum<V>(
        this ValueDatum<V> value
    ) {
        return new OptionalDatumValueDatumErrorDatumDatum<V>(
            OptionalDatumValueDatumErrorDatumMode.Value,
            default,
            value,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumErrorDatumDatum<V> AsOptionalDatumValueDatumErrorDatumDatum<V>(
        this ErrorDatum error
    ) {
        return new OptionalDatumValueDatumErrorDatumDatum<V>(
            OptionalDatumValueDatumErrorDatumMode.Error,
            default,
            default,
            error
        );
    }

    // generated 4 TryCatch
    public static OptionalDatumValueDatumErrorDatumDatum<V> TryCatch<V>(this Func<OptionalDatumValueDatumErrorDatumDatum<V>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumErrorDatumDatum<V>();
        }
    }

    public static OptionalDatumValueDatumErrorDatumDatum<V> TryCatch<V, A>(this A arg, Func<A, OptionalDatumValueDatumErrorDatumDatum<V>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumErrorDatumDatum<V>();
        }
    }

    public static async Task<OptionalDatumValueDatumErrorDatumDatum<V>> TryCatch<V>(this Task<OptionalDatumValueDatumErrorDatumDatum<V>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumErrorDatumDatum<V>();
        }
    }


}
