namespace Brimborium.TheMeaningOfLiff;

public static partial class Datum {
    public static ValueErrorDatum<T> TryCatch<T, A>(this A arg, Func<A, ValueErrorDatum<T>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return new ValueErrorDatum<T>(ValueErrorDatumMode.Error, default,  ErrorDatum.CreateFromCatchedException(error));
        }
    }
}
