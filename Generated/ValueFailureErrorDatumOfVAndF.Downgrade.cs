namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueFailureErrorDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == ValueFailureErrorMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out FailureErrorDatum<F> failureErrorDatum){
        if (this.Mode == ValueFailureErrorMode.Value) {
            valueDatum = this.ValueDatum;
            failureErrorDatum = default;
            return true;
        } else {
            valueDatum = default;
            failureErrorDatum = new FailureErrorDatum<F>(
                ((this.Mode) switch {
                    ValueFailureErrorMode.Failure => FailureErrorMode.Failure,
                    ValueFailureErrorMode.Error => FailureErrorMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == ValueFailureErrorMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out ValueErrorDatum<V> valueErrorDatum){
        if (this.Mode == ValueFailureErrorMode.Failure) {
            failureDatum = this.FailureDatum;
            valueErrorDatum = default;
            return true;
        } else {
            failureDatum = default;
            valueErrorDatum = new ValueErrorDatum<V>(
                ((this.Mode) switch {
                    ValueFailureErrorMode.Value => ValueErrorMode.Value,
                    ValueFailureErrorMode.Error => ValueErrorMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == ValueFailureErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out ValueFailureDatum<V, F> valueFailureDatum){
        if (this.Mode == ValueFailureErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            valueFailureDatum = default;
            return true;
        } else {
            errorDatum = default;
            valueFailureDatum = new ValueFailureDatum<V, F>(
                ((this.Mode) switch {
                    ValueFailureErrorMode.Value => ValueFailureMode.Value,
                    ValueFailureErrorMode.Failure => ValueFailureMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

}
// generated 2 Downgrade
