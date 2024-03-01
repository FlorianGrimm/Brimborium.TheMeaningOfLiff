namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V, F>(
        this NoDatum optional
    ) {
        return new OptionalValueFailureDatum<V, F>(
           OptionalValueFailureMode.NoValue,
           optional,
           default ,
           default 
        );
    }
    public static OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new OptionalValueFailureDatum<V, F>(
           OptionalValueFailureMode.Value,
           default ,
           value,
           default 
        );
    }
    public static OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalValueFailureDatum<V, F>(
           OptionalValueFailureMode.Failure,
           default ,
           default ,
           failure
        );
    }
}
