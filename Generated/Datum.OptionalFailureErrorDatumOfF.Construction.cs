namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum<F>(
        this NoDatum optional
    ) {
        return new OptionalFailureErrorDatum<F>(
           OptionalFailureErrorMode.NoValue,
           optional,
           default ,
           default 
        );
    }
    public static OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum<F>(
        this FailureDatumOfF<F> failure
    ) {
        return new OptionalFailureErrorDatum<F>(
           OptionalFailureErrorMode.Failure,
           default ,
           failure,
           default 
        );
    }
    public static OptionalFailureErrorDatum<F> AsOptionalFailureErrorDatum<F>(
        this ErrorDatum error
    ) {
        return new OptionalFailureErrorDatum<F>(
           OptionalFailureErrorMode.Error,
           default ,
           default ,
           error
        );
    }
}
