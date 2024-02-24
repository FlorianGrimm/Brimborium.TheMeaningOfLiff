namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static IEnumerable<R> SelectWhere<T, R>(this IEnumerable<T> source, Func<T, OptionalValueDatum<R>> predicateTransform) {
        foreach (var item in source) {
            var optR = predicateTransform(item);
            if (optR.TryGetValue(out var r)) {
                yield return r;
            }
        }
    }


    public static IEnumerable<R> SelectWhere<T, A, R>(this IEnumerable<T> source, A args, Func<T, A, OptionalValueDatum<R>> predicateTransform) {
        foreach (var item in source) {
            var optR = predicateTransform(item, args);
            if (optR.TryGetValue(out var r)) {
                yield return r;
            }
        }
    }

    public static IEnumerable<R> SelectWhereMany<T, R>(this IEnumerable<T> source, Func<T, OptionalValueDatum<IEnumerable<R>>> predicateTransform) {
        foreach (var item in source) {
            var optR = predicateTransform(item);
            if (optR.TryGetValue(out var r)) {
                foreach (var itemInner in r) {
                    yield return itemInner;
                }
            }
        }
    }

    public static OptionalValueDatum<TValue> TryGetOptionalDatum<TKey, TValue>(
        this Dictionary<TKey, TValue> that,
        TKey key,
        string? meaning = default,
        long logicalTimestamp = 0)
        where TKey : notnull {
        if (that.TryGetValue(key, out var value)) {
            return new ValueDatum<TValue>(value, meaning, logicalTimestamp);
        } else {
            return new NoDatum(meaning, logicalTimestamp);
        }
    }
}
