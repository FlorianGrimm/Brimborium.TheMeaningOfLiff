namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueErrorDatum<V>{
    public bool TryGetValue(out ValueDatum<V> value){
        if (this.Mode == ValueErrorMode.Value) {
            value = this.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> valueDatum, out ErrorDatum errorDatum){
        if (this.Mode == ValueErrorMode.Value) {
            valueDatum = this.Value;
            errorDatum = default;
            return true;
        } else {
            valueDatum = default;
            errorDatum = this.Error;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum error){
        if (this.Mode == ValueErrorMode.Error) {
            error = this.Error;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum errorDatum, out ValueDatum<V> valueDatum){
        if (this.Mode == ValueErrorMode.Error) {
            errorDatum = this.Error;
            valueDatum = default;
            return true;
        } else {
            errorDatum = default;
            valueDatum = this.Value;
            return false;
        }
    }

}
