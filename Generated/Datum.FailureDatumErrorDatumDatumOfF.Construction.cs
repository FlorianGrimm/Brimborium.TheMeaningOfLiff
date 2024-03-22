namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static FailureDatumErrorDatumDatum<F> AsFailureDatumErrorDatumDatum<F>(
        this FailureDatum<F> failure
    ) {
        return new FailureDatumErrorDatumDatum<F>(
            FailureDatumErrorDatumMode.Failure,
            failure,
            default
        );
    }

    // generated 4 Construction
    public static FailureDatumErrorDatumDatum<F> AsFailureDatumErrorDatumDatum<F>(
        this ErrorDatum error
    ) {
        return new FailureDatumErrorDatumDatum<F>(
            FailureDatumErrorDatumMode.Error,
            default,
            error
        );
    }
}
