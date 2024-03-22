namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalDatumValueDatumFailureDatumDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalDatumValueDatumFailureDatumMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueDatumFailureDatumDatum<V, F> valueDatumFailureDatumDatum){
        if (this.Mode == OptionalDatumValueDatumFailureDatumMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            valueDatumFailureDatumDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueDatumFailureDatumDatum = new ValueDatumFailureDatumDatum<V, F>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumFailureDatumMode.Value => ValueDatumFailureDatumMode.Value,
                    OptionalDatumValueDatumFailureDatumMode.Failure => ValueDatumFailureDatumMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == OptionalDatumValueDatumFailureDatumMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out OptionalDatumFailureDatumDatum<F> optionalDatumFailureDatumDatum){
        if (this.Mode == OptionalDatumValueDatumFailureDatumMode.Value) {
            valueDatum = this.ValueDatum;
            optionalDatumFailureDatumDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalDatumFailureDatumDatum = new OptionalDatumFailureDatumDatum<F>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumFailureDatumMode.NoValue => OptionalDatumFailureDatumMode.NoValue,
                    OptionalDatumValueDatumFailureDatumMode.Failure => OptionalDatumFailureDatumMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.FailureDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == OptionalDatumValueDatumFailureDatumMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalDatumValueDatumDatum<V> optionalDatumValueDatumDatum){
        if (this.Mode == OptionalDatumValueDatumFailureDatumMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalDatumValueDatumDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalDatumValueDatumDatum = new OptionalDatumValueDatumDatum<V>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumFailureDatumMode.NoValue => OptionalDatumValueDatumMode.NoValue,
                    OptionalDatumValueDatumFailureDatumMode.Value => OptionalDatumValueDatumMode.Value,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum
                );
            return false;
        }
    }

}
