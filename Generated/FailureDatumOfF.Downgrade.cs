namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct FailureDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

}
// generated 2 Downgrade
