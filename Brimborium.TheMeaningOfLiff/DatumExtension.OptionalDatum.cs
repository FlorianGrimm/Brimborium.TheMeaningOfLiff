namespace Brimborium.TheMeaningOfLiff;

public static partial class DatumExtension {
    public static OptionalDatum<T> AsOptional<T>(
        this T value, 
        Meaning? meaning = default,
        long logicalTimestamp = 0) {
        return new OptionalDatum<T>(OptionalDatumMode.Success, default, new Datum<T>(value, meaning, logicalTimestamp));
    }

    public static OptionalDatum<T> If<T>(this OptionalDatum<T> value, Func<T, bool> predicate) {
        if (value.TryGetValue(out var v) && predicate(v)) {
            return value;
        } else {
            return new OptionalDatum<T>();
        }
    }

    public static OptionalDatum<T> If<T, A>(this OptionalDatum<T> value, A args, Func<T, A, bool> predicate) {
        if (value.TryGetValue(out var v) && predicate(v, args)) {
            return value;
        } else {
            return new OptionalDatum<T>();
        }
    }

    public static OptionalDatum<R> Map<T, A, R>(this OptionalDatum<T> value, A args, Func<T, A, OptionalDatum<R>> predicate) {
        if (value.TryGetValue(out var v)) {
            return predicate(v, args);
        } else {
            return new NoDatum();
        }
    }

    public static OptionalDatum<T> OrDefault<T, A>(this OptionalDatum<T> value, A args, Func<A, OptionalDatum<T>> fnDefaultValue) {
        if (value.TryGetValue(out var _)) {
            return value;
        } else {
            return fnDefaultValue(args);
        }
    }

    public static OptionalDatum<T> OrDefault<T>(this OptionalDatum<T> value, OptionalDatum<T> defaultValue) {
        if (value.TryGetValue(out var _)) {
            return value;
        } else {
            return defaultValue;
        }
    }
}