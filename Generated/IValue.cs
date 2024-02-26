namespace Brimborium.TheMeaningOfLiff;

public interface IDatum<T> {
    T Value { get; }

    //void Deconstruct(out T Value);
    //bool Equals(SuccessValue<T> other);

    // SuccessValue<T> WithValue(T Value);
    // Result<T> WithError(Exception that);
}

public interface ISuccessDatum<T> : IDatum<T> {
}

public interface IOptionalDatum<T> {
    /* unsure about IValue */

    bool TryGetValue([MaybeNullWhen(false)] out T value);

    /*
    public bool TryGetValue([MaybeNullWhen(false)] out T value) {
        value = this.Value;
        return true;
    }
    */
}

public interface IWithError {
    bool TryGetError([MaybeNullWhen(false)] out ErrorDatum error);
}

public interface IDatumWithError<T, R> : IWithError
    where R : struct, IDatum<T> {

    // bool TryGetError([MaybeNullWhen(false)] out ErrorValue error);

    bool TryGetError(
            [MaybeNullWhen(false)] out ErrorDatum error,
            [MaybeNullWhen(true)] out R value);
}

public interface IOptionalValueWithError<T, R> : IWithError
    where R : struct, IOptionalDatum<T> {

    // bool TryGetError([MaybeNullWhen(false)] out ErrorValue error);

    bool TryGetError(
            [MaybeNullWhen(false)] out ErrorDatum error,
            [MaybeNullWhen(true)] out R value);
}

public interface ILogicalTimestamp {
    long LogicalTimestamp { get; }
}