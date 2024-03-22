namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalDatumValueDatumDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalDatumValueDatumMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueDatum<V> valueDatum){
        if (this.Mode == OptionalDatumValueDatumMode.NoValue) {
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
        if (this.Mode == OptionalDatumValueDatumMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalDatumValueDatumMode.Value) {
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
