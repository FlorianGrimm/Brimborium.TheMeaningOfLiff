namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optional){
        if (this.Mode == OptionalValueMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optionalDatum, [MaybeNullWhen(true)] out ValueDatum<V> valueDatum){
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

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> value){
        if (this.Mode == OptionalValueMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> valueDatum, [MaybeNullWhen(true)] out NoDatum optionalDatum){
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

    public bool TryGetValue([MaybeNullWhen(false)] out V value, [MaybeNullWhen(true)] out NoDatum elseDatum) {
        if (this.Mode == OptionalValueMode.Value) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueMode.NoValue) {
            value = default;
            elseDatum = this.OptionalDatum;
            return false;
        } else if (this.Mode == OptionalValueMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException($"Mode:{this.Mode}");
        }
    }
}
// generated 2 Downgrade
