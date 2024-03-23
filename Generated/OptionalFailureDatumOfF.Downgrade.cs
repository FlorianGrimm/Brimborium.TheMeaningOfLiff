namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalFailureDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optional){
        if (this.Mode == OptionalFailureMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            if (this.Mode == OptionalFailureMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optionalDatum, [MaybeNullWhen(true)] out FailureDatum<F> failureDatum){
        if (this.Mode == OptionalFailureMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            failureDatum = default;
            return true;
        } else {
            optionalDatum = default;
            failureDatum = this.FailureDatum;
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failure){
        if (this.Mode == OptionalFailureMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            if (this.Mode == OptionalFailureMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failureDatum, [MaybeNullWhen(true)] out NoDatum optionalDatum){
        if (this.Mode == OptionalFailureMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalDatum = this.OptionalDatum;
            return false;
        }
    }

}
// generated 2 Downgrade
