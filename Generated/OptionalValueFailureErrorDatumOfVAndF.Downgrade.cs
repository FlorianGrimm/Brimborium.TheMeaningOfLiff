namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct OptionalValueFailureErrorDatum<V, F>{
    public bool TryGetOptional(out NoDatum optional){
        if (this.Mode == OptionalValueFailureErrorMode.NoValue) {
            optional = this.Optional;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptional(out NoDatum optionalDatum, out ValueFailureErrorDatum<V, F> valueFailureErrorDatum){
        if (this.Mode == OptionalValueFailureErrorMode.NoValue) {
            optionalDatum = this.Optional;
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
                this.Value,
                this.Failure,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> value){
        if (this.Mode == OptionalValueFailureErrorMode.Value) {
            value = this.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> valueDatum, out OptionalFailureErrorDatum<F> optionalFailureErrorDatum){
        if (this.Mode == OptionalValueFailureErrorMode.Value) {
            valueDatum = this.Value;
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
                this.Optional,
                this.Failure,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatumOfF<F> failure){
        if (this.Mode == OptionalValueFailureErrorMode.Failure) {
            failure = this.Failure;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatumOfF<F> failureDatum, out OptionalValueErrorDatum<V> optionalValueErrorDatum){
        if (this.Mode == OptionalValueFailureErrorMode.Failure) {
            failureDatum = this.Failure;
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
                this.Optional,
                this.Value,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum error){
        if (this.Mode == OptionalValueFailureErrorMode.Error) {
            error = this.Error;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum errorDatum, out OptionalValueFailureDatum<V, F> optionalValueFailureDatum){
        if (this.Mode == OptionalValueFailureErrorMode.Error) {
            errorDatum = this.Error;
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
                this.Optional,
                this.Value,
                this.Failure
                );
            return false;
        }
    }

}
