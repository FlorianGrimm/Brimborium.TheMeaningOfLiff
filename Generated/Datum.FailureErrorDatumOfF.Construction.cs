namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static FailureErrorDatum<F> AsFailureErrorDatum<F>(
        this FailureDatum<F> failure
    ) {
        return new FailureErrorDatum<F>(
           FailureErrorMode.Failure,
           failure,
           default 
        );
    }
    public static FailureErrorDatum<F> AsFailureErrorDatum<F>(
        this ErrorDatum error
    ) {
        return new FailureErrorDatum<F>(
           FailureErrorMode.Error,
           default ,
           error
        );
    }
}
