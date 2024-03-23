namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V, F>(
        this NoDatum optional
    ) {
        return new OptionalValueFailureDatum<V, F>(
            OptionalValueFailureMode.NoValue,
            optional,
            default,
            default
        );
    }

    // generated 4 Construction
    public static OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V, F>(
        this ValueDatum<V> value
    ) {
        return new OptionalValueFailureDatum<V, F>(
            OptionalValueFailureMode.Value,
            default,
            value,
            default
        );
    }

    // generated 4 Construction
    public static OptionalValueFailureDatum<V, F> AsOptionalValueFailureDatum<V, F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalValueFailureDatum<V, F>(
            OptionalValueFailureMode.Failure,
            default,
            default,
            failure
        );
    }
}

// generated 4
