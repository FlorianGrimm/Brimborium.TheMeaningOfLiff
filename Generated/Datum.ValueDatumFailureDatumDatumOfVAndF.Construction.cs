namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static ValueDatumFailureDatumDatum<V, F> AsValueDatumFailureDatumDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new ValueDatumFailureDatumDatum<V, F>(
            ValueDatumFailureDatumMode.Value,
            value,
            default
        );
    }

    // generated 4 Construction
    public static ValueDatumFailureDatumDatum<V, F> AsValueDatumFailureDatumDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new ValueDatumFailureDatumDatum<V, F>(
            ValueDatumFailureDatumMode.Failure,
            default,
            failure
        );
    }
}
