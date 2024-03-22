namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalDatumErrorDatumDatum AsOptionalDatumErrorDatumDatum(
        this NoDatum optional
    ) {
        return new OptionalDatumErrorDatumDatum(
            OptionalDatumErrorDatumMode.NoValue,
            optional,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumErrorDatumDatum AsOptionalDatumErrorDatumDatum(
        this ErrorDatum error
    ) {
        return new OptionalDatumErrorDatumDatum(
            OptionalDatumErrorDatumMode.Error,
            default,
            error
        );
    }
}
