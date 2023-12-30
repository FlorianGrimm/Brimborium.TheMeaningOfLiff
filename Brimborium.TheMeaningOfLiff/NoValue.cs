
namespace Brimborium.TheMeaningOfLiff;

public record struct NoDatum(
    Meaning? Meaning = default,
    long LogicalTimestamp = 0) {

    public override string ToString() => string.Empty;

    public OptionalDatum<T> ToOptional<T>() => new OptionalDatum<T>(OptionalDatumMode.NoValue, this, default);

    public Datum<T> WithValue<T>(T value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new Datum<T>(
            value,
            meaning ?? this.Meaning,
            logicalTimestamp > 0 ? logicalTimestamp : this.LogicalTimestamp);
}
