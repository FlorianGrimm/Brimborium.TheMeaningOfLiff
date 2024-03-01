namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct OptionalValueDatum<V>{
    public bool TryGetOptional(out NoDatum optional){
        if (this.Mode == OptionalValueMode.NoValue) {
            optional = this.Optional;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptional(out NoDatum optionalDatum, out ValueDatum<V> valueDatum){
        if (this.Mode == OptionalValueMode.NoValue) {
            optionalDatum = this.Optional;
            valueDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueDatum = this.Value;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> value){
        if (this.Mode == OptionalValueMode.Value) {
            value = this.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> valueDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalValueMode.Value) {
            valueDatum = this.Value;
            optionalDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalDatum = this.Optional;
            return false;
        }
    }

}
