namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueDatumErrorDatumDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == ValueDatumErrorDatumMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out ErrorDatum errorDatum){
        if (this.Mode == ValueDatumErrorDatumMode.Value) {
            valueDatum = this.ValueDatum;
            errorDatum = default;
            return true;
        } else {
            valueDatum = default;
            errorDatum = this.ErrorDatum;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == ValueDatumErrorDatumMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out ValueDatum<V> valueDatum){
        if (this.Mode == ValueDatumErrorDatumMode.Error) {
            errorDatum = this.ErrorDatum;
            valueDatum = default;
            return true;
        } else {
            errorDatum = default;
            valueDatum = this.ValueDatum;
            return false;
        }
    }

}
