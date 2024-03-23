namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueFailureDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optional){
        if (this.Mode == OptionalValueFailureMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueFailureMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optionalDatum, [MaybeNullWhen(true)] out ValueFailureDatum<V, F> valueFailureDatum){
        if (this.Mode == OptionalValueFailureMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            valueFailureDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueFailureDatum = new ValueFailureDatum<V, F>(
                ((this.Mode) switch {
                    OptionalValueFailureMode.Value => ValueFailureMode.Value,
                    OptionalValueFailureMode.Failure => ValueFailureMode.Failure,
                    OptionalValueFailureMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> value){
        if (this.Mode == OptionalValueFailureMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueFailureMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> valueDatum, [MaybeNullWhen(true)] out OptionalFailureDatum<F> optionalFailureDatum){
        if (this.Mode == OptionalValueFailureMode.Value) {
            valueDatum = this.ValueDatum;
            optionalFailureDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalFailureDatum = new OptionalFailureDatum<F>(
                ((this.Mode) switch {
                    OptionalValueFailureMode.NoValue => OptionalFailureMode.NoValue,
                    OptionalValueFailureMode.Failure => OptionalFailureMode.Failure,
                    OptionalValueFailureMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.FailureDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failure){
        if (this.Mode == OptionalValueFailureMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueFailureMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failureDatum, [MaybeNullWhen(true)] out OptionalValueDatum<V> optionalValueDatum){
        if (this.Mode == OptionalValueFailureMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalValueDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalValueDatum = new OptionalValueDatum<V>(
                ((this.Mode) switch {
                    OptionalValueFailureMode.NoValue => OptionalValueMode.NoValue,
                    OptionalValueFailureMode.Value => OptionalValueMode.Value,
                    OptionalValueFailureMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.ValueDatum
                );
            return false;
        }
    }

    public bool TryGetValue([MaybeNullWhen(false)] out V value, [MaybeNullWhen(true)] out OptionalFailureDatum<F> elseDatum) {
        if (this.Mode == OptionalValueFailureMode.Value) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueFailureMode.NoValue) {
            value = default;
            elseDatum = new OptionalFailureDatum<F>(OptionalFailureMode.NoValue, this.OptionalDatum, default);
            return false;
        } else if (this.Mode == OptionalValueFailureMode.Failure) {
            value = default;
            elseDatum = new OptionalFailureDatum<F>(OptionalFailureMode.Failure, default, this.FailureDatum);
            return false;
        } else if (this.Mode == OptionalValueFailureMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException($"Mode:{this.Mode}");
        }
    }
}
// generated 2 Downgrade
