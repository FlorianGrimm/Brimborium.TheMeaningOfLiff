namespace Brimborium.TheMeaningOfLiff;

public static partial class DatumExtension {
    public static NoDatum NoValue => new NoDatum();

    public static Datum<T> AsSuccessValue<T>(this T that)
        => new Datum<T>(that, default, 0);

    public static ErrorValue AsErrorValue(this Exception that)
        => new ErrorValue(that, default, default, 0, false);

    public static DatumError<T> AsResult<T>(this T that)
        => new DatumError<T>(DatumErrorMode.Success, new Datum<T>(that), default);

    public static DatumError<T> AsResult<T>(this Datum<T> that)
        => new DatumError<T>(DatumErrorMode.Success, that.Value, default);

    public static DatumError<T> AsResult<T>(this OptionalDatumError<T> that) {
        if (that.TryGetValue(out var successValue)) {
            return new DatumError<T>(successValue);
        } else if (that.TryGetError(out var errorValue)) {
            return new DatumError<T>(errorValue);
        }
        return new DatumError<T>(new UninitializedException());
    }

    public static DatumError<T> AsResult<T>(this Exception that)
        => new DatumError<T>(that);

    public static DatumError<T> AsResult<T>(this ErrorValue that)
        => new DatumError<T>(that);


    public static OptionalDatumError<T> AsOptionalResult<T>(this NoDatum that)
        => new OptionalDatumError<T>();

    public static OptionalDatumError<T> AsOptionalResult<T>(this T that)
        => new OptionalDatumError<T>(that);

    public static OptionalDatumError<T> AsOptionalResult<T>(this Datum<T> that)
        => new OptionalDatumError<T>(that.Value);

    public static OptionalDatumError<T> AsOptionalResult<T>(this Exception that)
        => new OptionalDatumError<T>(that);

    public static OptionalDatumError<T> AsOptionalResult<T>(this ErrorValue value)
        => new OptionalDatumError<T>(value);

    public static OptionalDatumError<T> AsOptionalResult<T>(this DatumError<T> that) {
        if (that.TryGetValue(out var successValue)) {
            return new OptionalDatumError<T>(successValue);
        } else if (that.TryGetError(out var errorValue)) {
            return new OptionalDatumError<T>(errorValue);
        } else {
            return new OptionalDatumError<T>(new InvalidEnumArgumentException($"Invalid enum {that.Mode}."));
        }
    }

    public static DatumError<T> TryCatch<T, A>(this A arg, Func<A, DatumError<T>> fn) {
        try {
            return fn(arg);
        } catch (Exception error) {
            return new DatumError<T>(error);
        }
    }
}
