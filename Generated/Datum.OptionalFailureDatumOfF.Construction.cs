namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalFailureDatum<F> AsOptionalFailureDatum<F>(
        this NoDatum optional
    ) {
        return new OptionalFailureDatum<F>(
            OptionalFailureMode.NoValue,
            optional,
            default
        );
    }

    // generated 4 Construction
    public static OptionalFailureDatum<F> AsOptionalFailureDatum<F>(
        this FailureDatum<F> failure
    ) {
        return new OptionalFailureDatum<F>(
            OptionalFailureMode.Failure,
            default,
            failure
        );
    }
}

// generated 4
