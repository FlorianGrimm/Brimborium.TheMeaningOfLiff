namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct ValueDatumFailureDatumErrorDatumDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == ValueDatumFailureDatumErrorDatumMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out FailureDatumErrorDatumDatum<F> failureDatumErrorDatumDatum){
        if (this.Mode == ValueDatumFailureDatumErrorDatumMode.Value) {
            valueDatum = this.ValueDatum;
            failureDatumErrorDatumDatum = default;
            return true;
        } else {
            valueDatum = default;
            failureDatumErrorDatumDatum = new FailureDatumErrorDatumDatum<F>(
                ((this.Mode) switch {
                    ValueDatumFailureDatumErrorDatumMode.Failure => FailureDatumErrorDatumMode.Failure,
                    ValueDatumFailureDatumErrorDatumMode.Error => FailureDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == ValueDatumFailureDatumErrorDatumMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out ValueDatumErrorDatumDatum<V> valueDatumErrorDatumDatum){
        if (this.Mode == ValueDatumFailureDatumErrorDatumMode.Failure) {
            failureDatum = this.FailureDatum;
            valueDatumErrorDatumDatum = default;
            return true;
        } else {
            failureDatum = default;
            valueDatumErrorDatumDatum = new ValueDatumErrorDatumDatum<V>(
                ((this.Mode) switch {
                    ValueDatumFailureDatumErrorDatumMode.Value => ValueDatumErrorDatumMode.Value,
                    ValueDatumFailureDatumErrorDatumMode.Error => ValueDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == ValueDatumFailureDatumErrorDatumMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out ValueDatumFailureDatumDatum<V, F> valueDatumFailureDatumDatum){
        if (this.Mode == ValueDatumFailureDatumErrorDatumMode.Error) {
            errorDatum = this.ErrorDatum;
            valueDatumFailureDatumDatum = default;
            return true;
        } else {
            errorDatum = default;
            valueDatumFailureDatumDatum = new ValueDatumFailureDatumDatum<V, F>(
                ((this.Mode) switch {
                    ValueDatumFailureDatumErrorDatumMode.Value => ValueDatumFailureDatumMode.Value,
                    ValueDatumFailureDatumErrorDatumMode.Failure => ValueDatumFailureDatumMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

}
