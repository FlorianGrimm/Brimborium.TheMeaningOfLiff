namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {
// generated 4 Construction

    public static ValueDatum<V> AsValueDatum<V>(
        this V Value,
        System.String? Meaning = default,
        System.Int64 LogicalTimestamp = default
    ) {
        return new ValueDatum<V>(Value, Meaning, LogicalTimestamp);
    }
}
