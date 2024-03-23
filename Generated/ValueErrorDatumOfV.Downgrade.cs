namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueErrorDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> value){
        if (this.Mode == ValueErrorMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            if (this.Mode == ValueErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> valueDatum, [MaybeNullWhen(true)] out ErrorDatum errorDatum){
        if (this.Mode == ValueErrorMode.Value) {
            valueDatum = this.ValueDatum;
            errorDatum = default;
            return true;
        } else {
            valueDatum = default;
            errorDatum = this.ErrorDatum;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum error){
        if (this.Mode == ValueErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            if (this.Mode == ValueErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum errorDatum, [MaybeNullWhen(true)] out ValueDatum<V> valueDatum){
        if (this.Mode == ValueErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            valueDatum = default;
            return true;
        } else {
            errorDatum = default;
            valueDatum = this.ValueDatum;
            return false;
        }
    }

    public bool TryGetValue([MaybeNullWhen(false)] out V value, [MaybeNullWhen(true)] out ErrorDatum elseDatum) {
        if (this.Mode == ValueErrorMode.Value) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == ValueErrorMode.Error) {
            value = default;
            elseDatum = this.ErrorDatum;
            return false;
        } else if (this.Mode == ValueErrorMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException($"Mode:{this.Mode}");
        }
    }
}
// generated 2 Downgrade
