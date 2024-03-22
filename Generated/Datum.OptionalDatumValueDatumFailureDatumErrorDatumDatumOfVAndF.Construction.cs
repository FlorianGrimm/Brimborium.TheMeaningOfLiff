namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
        this NoDatum optional
    ) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
            OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue,
            optional,
            default,
            default,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
            OptionalDatumValueDatumFailureDatumErrorDatumMode.Value,
            default,
            value,
            default,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
            OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure,
            default,
            default,
            failure,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
        this ErrorDatum error
    ) {
        return new OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>(
            OptionalDatumValueDatumFailureDatumErrorDatumMode.Error,
            default,
            default,
            default,
            error
        );
    }

    // generated 4 TryCatch
    public static OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> TryCatch<V, F>(this Func<OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>> fn) {
        try {
            return fn();
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>();
        }
    }

    public static OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F> TryCatch<V, F, A>(this A arg, Func<A, OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>();
        }
    }

    public static async Task<OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>> TryCatch<V, F>(this Task<OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>> value) {
        try {
            return await value;
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsOptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>();
        }
    }


}
