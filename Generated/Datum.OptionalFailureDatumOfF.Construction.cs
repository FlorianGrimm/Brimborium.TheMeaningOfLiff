namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static OptionalFailureDatum<F> AsOptionalFailureDatum<F>(
        this NoDatum optional
    ) {
        return new OptionalFailureDatum<F>(
           OptionalFailureMode.NoValue,
           optional,
           default 
        );
    }
    public static OptionalFailureDatum<F> AsOptionalFailureDatum<F>(
        this FailureDatumOfF<F> failure
    ) {
        return new OptionalFailureDatum<F>(
           OptionalFailureMode.Failure,
           default ,
           failure
        );
    }
}
