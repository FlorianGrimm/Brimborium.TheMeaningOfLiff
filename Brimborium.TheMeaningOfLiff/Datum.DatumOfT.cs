namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static OptionalValueDatum<T> NotNull<T>(
        ValueDatum<T?> that,
        NoDatum elseDatum = default
        )
        where T : class {
        return that.Value switch {
            null => elseDatum,
            _ => new OptionalValueDatum<T>(that.Value, that.Meaning, that.LogicalTimestamp)
        };
    }
}
