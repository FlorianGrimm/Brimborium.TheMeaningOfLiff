namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static FailureErrorDatum<F> AsFailureErrorDatum<F>(
        this FailureDatum<F> failure
    ) {
        return new FailureErrorDatum<F>(
           FailureErrorMode.Failure,
           failure,
           default
        );
    }

    // generated 4 Construction
    public static FailureErrorDatum<F> AsFailureErrorDatum<F>(
        this ErrorDatum error
    ) {
        return new FailureErrorDatum<F>(
           FailureErrorMode.Error,
           default,
           error
        );
    }
}
