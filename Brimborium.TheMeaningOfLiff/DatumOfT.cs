namespace Brimborium.TheMeaningOfLiff;

public readonly record struct Datum<T>(
    T Value,
    Meaning? Meaning = default,
    long LogicalTimestamp = 0)
    : IDatum<T>
    , ISuccessDatum<T>
    , IWithMeaning
    , ILogicalTimestamp {
    public readonly Datum<T> WithValue(T value, Meaning? meaning = default, long logicalTimestamp = 0) => new Datum<T>(value, meaning, logicalTimestamp);

    public readonly DatumError<T> WithError(Exception that, Meaning? meaning = default, long logicalTimestamp = 0) => new DatumError<T>(new ErrorValue(that, default, meaning, logicalTimestamp));

    public readonly bool TryGetValue([MaybeNullWhen(false)] out T value) {
        value = this.Value;
        return true;
    }

    public static implicit operator Datum<T>(T that) => new Datum<T>(that, default, 0);

    public static implicit operator T(Datum<T> that) => that.Value;
}
