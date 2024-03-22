namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalDatumFailureDatumDatum<F> AsOptionalDatumFailureDatumDatum<F>(
        this NoDatum optional
    ) {
        return new OptionalDatumFailureDatumDatum<F>(
            OptionalDatumFailureDatumMode.NoValue,
            optional,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumFailureDatumDatum<F> AsOptionalDatumFailureDatumDatum<F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalDatumFailureDatumDatum<F>(
            OptionalDatumFailureDatumMode.Failure,
            default,
            failure
        );
    }
}
