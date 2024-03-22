namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalDatumValueDatumFailureDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumDatum<V, F>(
        this NoDatum optional
    ) {
        return new OptionalDatumValueDatumFailureDatumDatum<V, F>(
            OptionalDatumValueDatumFailureDatumMode.NoValue,
            optional,
            default,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumFailureDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new OptionalDatumValueDatumFailureDatumDatum<V, F>(
            OptionalDatumValueDatumFailureDatumMode.Value,
            default,
            value,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumFailureDatumDatum<V, F> AsOptionalDatumValueDatumFailureDatumDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalDatumValueDatumFailureDatumDatum<V, F>(
            OptionalDatumValueDatumFailureDatumMode.Failure,
            default,
            default,
            failure
        );
    }
}
