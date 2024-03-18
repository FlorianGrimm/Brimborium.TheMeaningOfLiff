namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueFailureErrorDatum<V, F>{
    public bool TryGetValue(out ValueDatum<V> value){
        if (this.Mode == ValueFailureErrorMode.Value) {
            value = this.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> valueDatum, out FailureErrorDatum<F> failureErrorDatum){
        if (this.Mode == ValueFailureErrorMode.Value) {
            valueDatum = this.Value;
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
                this.Failure,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failure){
        if (this.Mode == ValueFailureErrorMode.Failure) {
            failure = this.Failure;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failureDatum, out ValueErrorDatum<V> valueErrorDatum){
        if (this.Mode == ValueFailureErrorMode.Failure) {
            failureDatum = this.Failure;
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
                this.Value,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum error){
        if (this.Mode == ValueFailureErrorMode.Error) {
            error = this.Error;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum errorDatum, out ValueFailureDatum<V, F> valueFailureDatum){
        if (this.Mode == ValueFailureErrorMode.Error) {
            errorDatum = this.Error;
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
                this.Value,
                this.Failure
                );
            return false;
        }
    }

}
