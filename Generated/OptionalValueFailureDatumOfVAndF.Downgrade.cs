namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueFailureDatum<V, F>{
    public bool TryGetOptional(out NoDatum optional){
        if (this.Mode == OptionalValueFailureMode.NoValue) {
            optional = this.Optional;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptional(out NoDatum optionalDatum, out ValueFailureDatum<V, F> valueFailureDatum){
        if (this.Mode == OptionalValueFailureMode.NoValue) {
            optionalDatum = this.Optional;
            valueFailureDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueFailureDatum = new ValueFailureDatum<V, F>(
                ((this.Mode) switch {
                    OptionalValueFailureMode.Value => ValueFailureMode.Value,
                    OptionalValueFailureMode.Failure => ValueFailureMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.Value,
                this.Failure
                );
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> value){
        if (this.Mode == OptionalValueFailureMode.Value) {
            value = this.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> valueDatum, out OptionalFailureDatum<F> optionalFailureDatum){
        if (this.Mode == OptionalValueFailureMode.Value) {
            valueDatum = this.Value;
            optionalFailureDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalFailureDatum = new OptionalFailureDatum<F>(
                ((this.Mode) switch {
                    OptionalValueFailureMode.NoValue => OptionalFailureMode.NoValue,
                    OptionalValueFailureMode.Failure => OptionalFailureMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.Optional,
                this.Failure
                );
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failure){
        if (this.Mode == OptionalValueFailureMode.Failure) {
            failure = this.Failure;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failureDatum, out OptionalValueDatum<V> optionalValueDatum){
        if (this.Mode == OptionalValueFailureMode.Failure) {
            failureDatum = this.Failure;
            optionalValueDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalValueDatum = new OptionalValueDatum<V>(
                ((this.Mode) switch {
                    OptionalValueFailureMode.NoValue => OptionalValueMode.NoValue,
                    OptionalValueFailureMode.Value => OptionalValueMode.Value,
                    _ => throw new InvalidOperationException()
                }),
                this.Optional,
                this.Value
                );
            return false;
        }
    }

}
