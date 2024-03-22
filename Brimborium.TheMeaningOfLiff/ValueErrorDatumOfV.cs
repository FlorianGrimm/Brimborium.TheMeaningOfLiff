namespace Brimborium.TheMeaningOfLiff;

public enum ValueErrorDatumMode {
    NoValue,
    Success,
    Error
}

[DebuggerNonUserCode]
public static class ValueErrorDatum {
    public static ValueErrorDatum<V> Create<V>(V value, string? meaning = default, long logicalTimestamp = 0)
        => new ValueErrorDatum<V>(ValueErrorDatumMode.Success, new ValueDatum<V>(value, meaning, logicalTimestamp), default);

    //public static ValueErrorDatum<T> CreateNotNull<T>([AllowNull] T value, string? meaning = default, long logicalTimestamp = 0)
    //    where T : class {
    //    if (value is null) {
    //        return new ValueErrorDatum<T>( new ErrorDatum(new ArgumentNullException(nameof(value)), default, meaning, logicalTimestamp));
    //    } else {
    //        return new ValueErrorDatum<T>(value, meaning, logicalTimestamp);
    //    }
    //}
}

[DebuggerNonUserCode]
[method: JsonConstructor]
public readonly partial record struct ValueErrorDatum<T>(
    ValueErrorDatumMode Mode,
    [property: AllowNull][AllowNull] ValueDatum<T> ValueDatum,
    [property: AllowNull][AllowNull] ErrorDatum ErrorDatum
    )
    : IDatumWithError<T, ValueDatum<T>>
    , IWithMeaning
    , ILogicalTimestamp {
    public ValueErrorDatum(ValueDatum<T> valueDatum)
        : this(ValueErrorDatumMode.Success, valueDatum, default) {
    }

    public ValueErrorDatum(ErrorDatum errorDatum)
        : this(ValueErrorDatumMode.Error, default, errorDatum) {
    }

    public readonly string? Meaning
        => this.Mode switch {
            ValueErrorDatumMode.Success => this.ValueDatum.Meaning,
            ValueErrorDatumMode.Error => this.ErrorDatum.Meaning,
            _ => default
        };

    public readonly long LogicalTimestamp
        => this.Mode switch {
            ValueErrorDatumMode.Success => this.ValueDatum.LogicalTimestamp,
            ValueErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
            _ => 0
        };

    public readonly bool TryGetValue(
    [MaybeNullWhen(false)] out ValueDatum<T> valueDatum) {
        if (this.Mode == ValueErrorDatumMode.Success) {
            valueDatum = this.ValueDatum;
            return true;
        } else {
            valueDatum = default;
            return false;
        }
    }

    /// <summary>
    /// Tries to get the value or error value.
    /// </summary>
    /// <param name="valueDatum">When this method returns, contains the value if the operation was successful; otherwise, the default value of <see cref="ValueDatum{T}"/>.</param>
    /// <param name="errorDatum">When this method returns, contains the error value if the operation was unsuccessful; otherwise, the default value of <see cref="TheMeaningOfLiff.ErrorDatum"/>.</param>
    /// <returns><c>true</c> if the operation was successful; otherwise, <c>false</c>.</returns>
    public readonly bool TryGetValue(
        [MaybeNullWhen(false)] out ValueDatum<T> valueDatum,
        [MaybeNullWhen(true)] out ErrorDatum errorDatum) {
        if (this.Mode == ValueErrorDatumMode.Success) {
            valueDatum = this.ValueDatum;
            errorDatum = default;
            return true;
        } else if (this.Mode == ValueErrorDatumMode.Error) {
            valueDatum = default;
            errorDatum = this.ErrorDatum;
            return false;
        } else {
            valueDatum = default;
            errorDatum = new ErrorDatum(new UninitializedException(), default, this.Meaning, this.LogicalTimestamp, false);
            return false;
        }
    }

    /// <summary>
    /// Tries to get the value.
    /// </summary>
    /// <param name="value">The value if this is successful; otherwise, the default value of <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the result is successful and the value is retrieved; otherwise, <c>false</c>.</returns>
    public readonly bool TryGet([MaybeNullWhen(false)] out T value) {
        if (this.Mode == ValueErrorDatumMode.Success) {
            value = this.ValueDatum.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public readonly bool TryGet(
        [MaybeNullWhen(false)] out T value,
        [MaybeNullWhen(true)] out ErrorDatum errorDatum) {
        if (this.Mode == ValueErrorDatumMode.Success) {
            value = this.ValueDatum.Value;
            errorDatum = default;
            return true;
        } else {
            value = default;
            errorDatum = this.ErrorDatum;
            return false;
        }
    }


    /// <summary>
    /// Tries to get the error value if the mode is set to Error.
    /// </summary>
    /// <param name="error">The error value if the mode is set to Error; otherwise, the default value.</param>
    /// <returns>True if the mode is set to Error and the error value is successfully retrieved; otherwise, false.</returns>
    public readonly bool TryGetError([MaybeNullWhen(false)] out ErrorDatum error) {
        if (this.Mode == ValueErrorDatumMode.Error) {
            error = this.ErrorDatum;
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
        [MaybeNullWhen(false)] out ErrorDatum error,
        [MaybeNullWhen(true)] out ValueDatum<T> value) {
        if (this.Mode == ValueErrorDatumMode.Error) {
            error = this.ErrorDatum;
            value = default;
            return true;
        } else if (this.Mode == ValueErrorDatumMode.NoValue) {
            error = new ErrorDatum(new UninitializedException(), default, this.Meaning, this.LogicalTimestamp, false);
            value = default;
            return true;
        } else {
            error = default;
            value = this.ValueDatum;
            return false;
        }
    }

    public bool GetErrorOrValue([MaybeNullWhen(false)] out ErrorDatum error, [MaybeNullWhen(true)] out ValueDatum<T> value) {
        if (this.Mode == ValueErrorDatumMode.Success) {
            error = default;
            value = this.ValueDatum;
            return false;
        } else if (this.Mode == ValueErrorDatumMode.Error) {
            error = this.ErrorDatum;
            value = default;
            return true;
        } else {
            error = new ErrorDatum(new UninitializedException(), default, this.Meaning, this.LogicalTimestamp, false);
            value = default;
            return true;
        }
    }
}
