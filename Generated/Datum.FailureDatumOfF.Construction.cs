namespace Brimborium.TheMeaningOfLiff;

// generated 4

public static partial class Datum {
// generated 4 Construction

    public static FailureDatum<F> AsFailureDatum<F>(
        this F Value,
        System.String? Meaning = default,
        System.Int64 LogicalTimestamp = default
    ) {
        return new FailureDatum<F>(Value, Meaning, LogicalTimestamp);
    }
}
