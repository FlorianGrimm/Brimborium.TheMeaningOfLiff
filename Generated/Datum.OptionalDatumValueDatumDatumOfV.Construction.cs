namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {

    // generated 4 Construction
    public static OptionalDatumValueDatumDatum<V> AsOptionalDatumValueDatumDatum<V>(
        this NoDatum optional
    ) {
        return new OptionalDatumValueDatumDatum<V>(
            OptionalDatumValueDatumMode.NoValue,
            optional,
            default
        );
    }

    // generated 4 Construction
    public static OptionalDatumValueDatumDatum<V> AsOptionalDatumValueDatumDatum<V>(
        this ValueDatum<V> value
    ) {
        return new OptionalDatumValueDatumDatum<V>(
            OptionalDatumValueDatumMode.Value,
            default,
            value
        );
    }
}
