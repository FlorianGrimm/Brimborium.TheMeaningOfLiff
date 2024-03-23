namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueFailureErrorDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optional){
        if (this.Mode == OptionalValueFailureErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueFailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optionalDatum, [MaybeNullWhen(true)] out ValueFailureErrorDatum<V, F> valueFailureErrorDatum){
        if (this.Mode == OptionalValueFailureErrorMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            valueFailureErrorDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueFailureErrorDatum = new ValueFailureErrorDatum<V, F>(
                ((this.Mode) switch {
                    OptionalValueFailureErrorMode.Value => ValueFailureErrorMode.Value,
                    OptionalValueFailureErrorMode.Failure => ValueFailureErrorMode.Failure,
                    OptionalValueFailureErrorMode.Error => ValueFailureErrorMode.Error,
                    OptionalValueFailureErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.ValueDatum,
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> value){
        if (this.Mode == OptionalValueFailureErrorMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueFailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> valueDatum, [MaybeNullWhen(true)] out OptionalFailureErrorDatum<F> optionalFailureErrorDatum){
        if (this.Mode == OptionalValueFailureErrorMode.Value) {
            valueDatum = this.ValueDatum;
            optionalFailureErrorDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalFailureErrorDatum = new OptionalFailureErrorDatum<F>(
                ((this.Mode) switch {
                    OptionalValueFailureErrorMode.NoValue => OptionalFailureErrorMode.NoValue,
                    OptionalValueFailureErrorMode.Failure => OptionalFailureErrorMode.Failure,
                    OptionalValueFailureErrorMode.Error => OptionalFailureErrorMode.Error,
                    OptionalValueFailureErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failure){
        if (this.Mode == OptionalValueFailureErrorMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueFailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failureDatum, [MaybeNullWhen(true)] out OptionalValueErrorDatum<V> optionalValueErrorDatum){
        if (this.Mode == OptionalValueFailureErrorMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalValueErrorDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalValueErrorDatum = new OptionalValueErrorDatum<V>(
                ((this.Mode) switch {
                    OptionalValueFailureErrorMode.NoValue => OptionalValueErrorMode.NoValue,
                    OptionalValueFailureErrorMode.Value => OptionalValueErrorMode.Value,
                    OptionalValueFailureErrorMode.Error => OptionalValueErrorMode.Error,
                    OptionalValueFailureErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum error){
        if (this.Mode == OptionalValueFailureErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueFailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum errorDatum, [MaybeNullWhen(true)] out OptionalValueFailureDatum<V, F> optionalValueFailureDatum){
        if (this.Mode == OptionalValueFailureErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalValueFailureDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalValueFailureDatum = new OptionalValueFailureDatum<V, F>(
                ((this.Mode) switch {
                    OptionalValueFailureErrorMode.NoValue => OptionalValueFailureMode.NoValue,
                    OptionalValueFailureErrorMode.Value => OptionalValueFailureMode.Value,
                    OptionalValueFailureErrorMode.Failure => OptionalValueFailureMode.Failure,
                    OptionalValueFailureErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

    public bool TryGetValue([MaybeNullWhen(false)] out V value, [MaybeNullWhen(true)] out OptionalFailureErrorDatum<F> elseDatum) {
        if (this.Mode == OptionalValueFailureErrorMode.Value) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueFailureErrorMode.NoValue) {
            value = default;
            elseDatum = new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.NoValue, this.OptionalDatum, default, default);
            return false;
        } else if (this.Mode == OptionalValueFailureErrorMode.Failure) {
            value = default;
            elseDatum = new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Failure, default, this.FailureDatum, default);
            return false;
        } else if (this.Mode == OptionalValueFailureErrorMode.Error) {
            value = default;
            elseDatum = new OptionalFailureErrorDatum<F>(OptionalFailureErrorMode.Error, default, default, this.ErrorDatum);
            return false;
        } else if (this.Mode == OptionalValueFailureErrorMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException($"Mode:{this.Mode}");
        }
    }
}
// generated 2 Downgrade
