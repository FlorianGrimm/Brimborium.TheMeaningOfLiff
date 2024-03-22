namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static OptionalValueDatum<V> NotNull<V>(
        ValueDatum<V?> that,
        NoDatum elseDatum = default
        )
        where V : class {
        return that.Value switch {
            null => elseDatum,
            _ => new OptionalValueDatum<V>(that.Value, that.Meaning, that.LogicalTimestamp)
        };
    }
}
