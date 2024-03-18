namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueFailureDatum<V, F>{
    public bool TryGetValue(out ValueDatum<V> value){
        if (this.Mode == ValueFailureMode.Value) {
            value = this.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> valueDatum, out FailureDatum<F> failureDatum){
        if (this.Mode == ValueFailureMode.Value) {
            valueDatum = this.Value;
            failureDatum = default;
            return true;
        } else {
            valueDatum = default;
            failureDatum = this.Failure;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failure){
        if (this.Mode == ValueFailureMode.Failure) {
            failure = this.Failure;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failureDatum, out ValueDatum<V> valueDatum){
        if (this.Mode == ValueFailureMode.Failure) {
            failureDatum = this.Failure;
            valueDatum = default;
            return true;
        } else {
            failureDatum = default;
            valueDatum = this.Value;
            return false;
        }
    }

}
