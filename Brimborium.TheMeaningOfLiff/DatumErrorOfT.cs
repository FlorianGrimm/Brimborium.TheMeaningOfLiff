using System.Security.Cryptography;

namespace Brimborium.TheMeaningOfLiff;

public enum DatumErrorMode {
    NotInit,
    Success,
    Error
}

public static class DatumError {
    public static DatumError<T> Create<T>(T value, Meaning? meaning = default, long logicalTimestamp = 0)
        => new DatumError<T>(value, meaning, logicalTimestamp);

    public static DatumError<T> CreateNotNull<T>([AllowNull]T value, Meaning? meaning = default, long logicalTimestamp = 0)
        where T : class {
        if (value is null) {
            return new DatumError<T>(new ErrorValue(new ArgumentNullException(nameof(value)), default, meaning, logicalTimestamp));
        } else { 
            return new DatumError<T>(value, meaning, logicalTimestamp);
        }
    }
}

[method: JsonConstructor]
public readonly record struct DatumError<T>(
    DatumErrorMode Mode,
    [property: AllowNull][AllowNull] Datum<T> Value,
    [property: AllowNull][AllowNull] ErrorValue ErrorValue
    )
    : IDatumWithError<T, Datum<T>>
    , IWithMeaning
    , ILogicalTimestamp {
    public DatumError(T value, Meaning? meaning = default, long logicalTimestamp = 0)
        : this(DatumErrorMode.Success, new Datum<T>(value, meaning, logicalTimestamp), default) {
    }

    public DatumError(ErrorValue errorValue)
        : this(DatumErrorMode.Error, default, errorValue) {
    }

    //public readonly Meaning? Meaning => this.Mode == DatumErrorMode.Success ? this.Value.Meaning : this.ErrorValue.Meaning;
    public readonly Meaning? Meaning
        => this.Mode switch {
            DatumErrorMode.Success => this.Value.Meaning,
            DatumErrorMode.Error => this.ErrorValue.Meaning,
            _ => default
        };

    public readonly long LogicalTimestamp 
        => this.Mode switch {
            DatumErrorMode.Success => this.Value.LogicalTimestamp,
            DatumErrorMode.Error => this.ErrorValue.LogicalTimestamp,
            _ => 0
        };

    /// <summary>
    /// Tries to get the value or error value.
    /// </summary>
    /// <param name="value">When this method returns, contains the value if the operation was successful; otherwise, the default value of <see cref="Datum{T}"/>.</param>
    /// <param name="errorValue">When this method returns, contains the error value if the operation was unsuccessful; otherwise, the default value of <see cref="ErrorValue"/>.</param>
    /// <returns><c>true</c> if the operation was successful; otherwise, <c>false</c>.</returns>
    public readonly bool TryGet(
        [MaybeNullWhen(false)] out Datum<T> value,
        [MaybeNullWhen(true)] out ErrorValue errorValue) {
        if (this.Mode == DatumErrorMode.Success) {
            value = this.Value;
            errorValue = default;
            return true;
        } else if (this.Mode == DatumErrorMode.Error) {
            value = default;
            errorValue = this.ErrorValue;
            return false;
        } else {
            value = default;
            errorValue = new ErrorValue(new UninitializedException(), default, this.Meaning, this.LogicalTimestamp, false);
            return false;
        }
    }

    /// <summary>
    /// Tries to get the value.
    /// </summary>
    /// <param name="value">The value if this is successful; otherwise, the default value of <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the result is successful and the value is retrieved; otherwise, <c>false</c>.</returns>
    public readonly bool TryGetValue([MaybeNullWhen(false)] out T value) {
        if (this.Mode == DatumErrorMode.Success) {
            value = this.Value.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Tries to get the error value if the mode is set to Error.
    /// </summary>
    /// <param name="error">The error value if the mode is set to Error; otherwise, the default value.</param>
    /// <returns>True if the mode is set to Error and the error value is successfully retrieved; otherwise, false.</returns>
    public readonly bool TryGetError([MaybeNullWhen(false)] out ErrorValue error) {
        if (this.Mode == DatumErrorMode.Error) {
            error = this.ErrorValue;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    /// <summary>
    /// Tries to get the error or value.
    /// </summary>
    /// <param name="error">The error value, if the mode is Error.</param>
    /// <param name="value">The value, if the mode is Success.</param>
    /// <returns>True if the mode is Error, false otherwise.</returns>
    public readonly bool TryGetError(
        [MaybeNullWhen(false)] out ErrorValue error,
        [MaybeNullWhen(true)] out Datum<T> value) {
        if (this.Mode == DatumErrorMode.Error) {
            error = this.ErrorValue;
            value = default;
            return true;
        } else if (this.Mode == DatumErrorMode.NotInit) {
            error = new ErrorValue(new UninitializedException(), default, this.Meaning, this.LogicalTimestamp, false);
            value = default;
            return true;
        } else {
            error = default;
            value = this.Value;
            return false;
        }
    }

    public bool GetErrorOrValue([MaybeNullWhen(false)] out ErrorValue error, [MaybeNullWhen(true)] out Datum<T> value) {
        if (this.Mode == DatumErrorMode.Success) {
            error = default;
            value = this.Value;
            return false;
        } else if (this.Mode == DatumErrorMode.Error) {
            error = this.ErrorValue;
            value = default;
            return true;
        } else {
            error = new ErrorValue(new UninitializedException(), default, this.Meaning, this.LogicalTimestamp, false);
            value = default;
            return true;
        }
    }


    public readonly DatumError<T> WithValue(T value, Meaning? meaning, long logicalTimestamp)
        => new DatumError<T>(value, meaning ?? this.Meaning, logicalTimestamp > 0 ? logicalTimestamp : this.LogicalTimestamp);

    public readonly DatumError<T> WithError(ErrorValue error, Meaning? meaning, long logicalTimestamp)
        => new DatumError<T>(error with { Meaning = meaning ?? error.Meaning, LogicalTimestamp = logicalTimestamp > 0 ? logicalTimestamp : this.LogicalTimestamp });

    /*
    public static implicit operator ResultRec<T>(T value) => new ResultRec<T>(value);
    public static implicit operator ResultRec<T>(Exception error) => new ResultRec<T>(new ErrorValue(error, default, default, 0, false));

    */
    public static implicit operator DatumError<T>(Datum<T> successValue) => new DatumError<T>(DatumErrorMode.Success, successValue, default);
    public static implicit operator DatumError<T>(ErrorValue errorValue) => new DatumError<T>(DatumErrorMode.Error, default!, errorValue);

}
