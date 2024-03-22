namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueFailureDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalValueFailureMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueFailureDatum<V, F> valueFailureDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == OptionalValueFailureMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out OptionalFailureDatum<F> optionalFailureDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.FailureDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == OptionalValueFailureMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalValueDatum<V> optionalValueDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum
                );
            return false;
        }
    }

}
// generated 2 Downgrade
