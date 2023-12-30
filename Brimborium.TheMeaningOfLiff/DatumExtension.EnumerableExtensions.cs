namespace Brimborium.TheMeaningOfLiff;

public static partial class DatumExtension
{
    public static IEnumerable<R> SelectWhere<T,R>(this IEnumerable<T> source, Func<T, OptionalDatum<R>> predicateTransform) {
        foreach (var item in source) {
            var optR = predicateTransform(item);
            if (optR.TryGetValue(out var r)){
                yield return r;
            }
        }
    }

    
    public static IEnumerable<R> SelectWhere<T, A, R>(this IEnumerable<T> source, A args, Func<T, A, OptionalDatum<R>> predicateTransform) {
        foreach (var item in source) {
            var optR = predicateTransform(item, args);
            if (optR.TryGetValue(out var r)){
                yield return r;
            }
        }
    }

    public static IEnumerable<R> SelectWhereMany<T,R>(this IEnumerable<T> source, Func<T, OptionalDatum<IEnumerable<R>>> predicateTransform) {
        foreach (var item in source) {
            var optR = predicateTransform(item);
            if (optR.TryGetValue(out var r)){
                foreach(var itemInner in r){
                    yield return itemInner;
                }
            }
        }
    }
}
