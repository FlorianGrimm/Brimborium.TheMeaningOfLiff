namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct ValueDatum<V> {
    // iznogood

    public static explicit operator ValueDatum<V>(V that) => new ValueDatum<V>(that, default, 0);

    public static explicit operator V(ValueDatum<V> that) => that.Value;


    public OptionalValueDatum<R> AsOptionalOfType<R>(
        string? meaning = default,
        long logicalTimestamp = 0) {
        if (this.Value is R valueR) {
            return new OptionalValueDatum<R>(OptionalValueDatumMode.Success, default, new ValueDatum<R>(valueR, meaning ?? this.Meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp)));
        } else {
            return new NoDatum(meaning, LogicalTimestampUtility.Next(this.LogicalTimestamp, logicalTimestamp));
        }
    }


}
