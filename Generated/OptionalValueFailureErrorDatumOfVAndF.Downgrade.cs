namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueFailureErrorDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalValueFailureErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueFailureErrorDatum<V, F> valueFailureErrorDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == OptionalValueFailureErrorMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out OptionalFailureErrorDatum<F> optionalFailureErrorDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == OptionalValueFailureErrorMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalValueErrorDatum<V> optionalValueErrorDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == OptionalValueFailureErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalValueFailureDatum<V, F> optionalValueFailureDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

}
// generated 2 Downgrade
