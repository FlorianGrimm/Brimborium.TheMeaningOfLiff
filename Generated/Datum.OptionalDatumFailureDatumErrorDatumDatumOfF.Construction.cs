namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalDatumFailureDatumErrorDatumDatum<F> AsOptionalDatumFailureDatumErrorDatumDatum<F>(
        this NoDatum optional
    ) {
        return new OptionalDatumFailureDatumErrorDatumDatum<F>(
            OptionalDatumFailureDatumErrorDatumMode.NoValue,
            optional,
            default,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumFailureDatumErrorDatumDatum<F> AsOptionalDatumFailureDatumErrorDatumDatum<F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalDatumFailureDatumErrorDatumDatum<F>(
            OptionalDatumFailureDatumErrorDatumMode.Failure,
            default,
            failure,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumFailureDatumErrorDatumDatum<F> AsOptionalDatumFailureDatumErrorDatumDatum<F>(
        this ErrorDatum error
    ) {
        return new OptionalDatumFailureDatumErrorDatumDatum<F>(
            OptionalDatumFailureDatumErrorDatumMode.Error,
            default,
            default,
            error
        );
    }
}
