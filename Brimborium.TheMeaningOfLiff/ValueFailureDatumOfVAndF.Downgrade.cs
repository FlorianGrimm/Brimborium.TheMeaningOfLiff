namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueFailureDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> value){
        if (this.Mode == ValueFailureMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            if (this.Mode == ValueFailureMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> valueDatum, [MaybeNullWhen(true)] out FailureDatum<F> failureDatum){
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

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failure){
        if (this.Mode == ValueFailureMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            if (this.Mode == ValueFailureMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failureDatum, [MaybeNullWhen(true)] out ValueDatum<V> valueDatum){
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

    public bool TryGetValue([MaybeNullWhen(false)] out V value, [MaybeNullWhen(true)] out FailureDatum<F> elseDatum) {
        if (this.Mode == ValueFailureMode.Value) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == ValueFailureMode.Failure) {
            value = default;
            elseDatum = this.FailureDatum;
            return false;
        } else if (this.Mode == ValueFailureMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException($"Mode:{this.Mode}");
        }
    }
}
// generated 2 Downgrade
