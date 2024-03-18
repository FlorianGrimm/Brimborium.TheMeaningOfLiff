namespace Brimborium.TheMeaningOfLiff;

// generated 4 Construction

public static partial class Datum {
    public static OptionalErrorDatum AsOptionalErrorDatum(
        this NoDatum optional
    ) {
        return new OptionalErrorDatum(
           OptionalErrorMode.NoValue,
           optional,
           default 
        );
    }
    public static OptionalErrorDatum AsOptionalErrorDatum(
        this ErrorDatum error
    ) {
        return new OptionalErrorDatum(
           OptionalErrorMode.Error,
           default ,
           error
        );
    }
}
