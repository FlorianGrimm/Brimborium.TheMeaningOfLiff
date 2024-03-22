namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalValueMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueDatum<V> valueDatum){
        if (this.Mode == OptionalValueMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            valueDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueDatum = this.ValueDatum;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == OptionalValueMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalValueMode.Value) {
            valueDatum = this.ValueDatum;
            optionalDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalDatum = this.OptionalDatum;
            return false;
        }
    }

}
// generated 2 Downgrade
