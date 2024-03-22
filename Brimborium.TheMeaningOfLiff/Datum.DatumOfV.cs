namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static OptionalValueDatum<V> NotNull<V>(
        ValueDatum<V?> that,
        NoDatum elseDatum = default
        )
        where V : class {
#warning HERE
        return that.Value switch {
            null => elseDatum,
            var value => new OptionalValueDatum<V>(OptionalValueMode.Value, default, new ValueDatum<V>(value, that.Meaning, that.LogicalTimestamp))
        };
    }
}
