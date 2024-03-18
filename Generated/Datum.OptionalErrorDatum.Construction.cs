namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalErrorDatum AsOptionalErrorDatum(
        this NoDatum optional
    ) {
        return new OptionalErrorDatum(
           OptionalErrorMode.NoValue,
           optional,
           default
        );
    }

    // generated 4 Construction
    public static OptionalErrorDatum AsOptionalErrorDatum(
        this ErrorDatum error
    ) {
        return new OptionalErrorDatum(
           OptionalErrorMode.Error,
           default,
           error
        );
    }
}
