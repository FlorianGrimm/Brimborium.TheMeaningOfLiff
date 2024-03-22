namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueFailureDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == ValueFailureMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out FailureDatum<F> failureDatum){
        if (this.Mode == ValueFailureMode.Value) {
            valueDatum = this.ValueDatum;
            failureDatum = default;
            return true;
        } else {
            valueDatum = default;
            failureDatum = this.FailureDatum;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == ValueFailureMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out ValueDatum<V> valueDatum){
        if (this.Mode == ValueFailureMode.Failure) {
            failureDatum = this.FailureDatum;
            valueDatum = default;
            return true;
        } else {
            failureDatum = default;
            valueDatum = this.ValueDatum;
            return false;
        }
    }

}
// generated 2 Downgrade
