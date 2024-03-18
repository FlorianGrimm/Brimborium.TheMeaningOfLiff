namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueFailureErrorDatumMode { NoValue, Success, Error, Failure }

[DebuggerNonUserCode]
[method: JsonConstructor]
public readonly partial record struct OptionalValueFailureErrorDatum<V, F>(
    OptionalValueFailureErrorDatumMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] ValueDatum<V> ValueDatum,
    [property: AllowNull][AllowNull] FailureDatum<F> FailureDatum,
    [property: AllowNull][AllowNull] ErrorDatum ErrorDatum
    ) {

    public bool TryGetNoDatum(out NoDatum noDatum, out ValueFailureErrorDatum<V,F> elseDatum) {
        throw new NotImplementedException();
    }

    public bool TryGetValueDatum(out ValueDatum<F> failureDatum, out OptionalFailureErrorDatum<F> elseDatum) { 
        throw new NotImplementedException();
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalValueErrorDatum<V> elseDatum) {
        if (this.Mode == OptionalValueFailureErrorDatumMode.Failure) {
            failureDatum = this.FailureDatum;
            elseDatum = default;
            return true;
        } else { 
            failureDatum = default;
            elseDatum = (this.Mode) switch {
                OptionalValueFailureErrorDatumMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.NoValue, this.NoValue, default ,default),
                OptionalValueFailureErrorDatumMode.Success => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Success, default, this.ValueDatum, default),
                OptionalValueFailureErrorDatumMode.Error => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Error, default, default, this.ErrorDatum),
                _ => throw new UninitializedException()
            };
            return false;
        }
    }
    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalValueFailureDatum<V, F> elseDatum) { 
        throw new UninitializedException();
    }
}

public enum ValueFailureErrorDatumMode { Success, Error, Failure }
public readonly partial record struct ValueFailureErrorDatum<V, F>(
    ValueFailureErrorDatumMode Mode,
    [property: AllowNull][AllowNull] ValueDatum<V> ValueDatum,
    [property: AllowNull][AllowNull] FailureDatum<F> FailureDatum,
    [property: AllowNull][AllowNull] ErrorDatum ErrorDatum) {
    public bool TryGetValueDatum(out ValueDatum<F> failureDatum, out OptionalFailureErrorDatum<F> elseDatum) {
        throw new NotImplementedException();
    }
    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalValueErrorDatum<V> elseDatum) {
        throw new UninitializedException();
    }
    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalValueFailureDatum<V, F> elseDatum) {
        throw new UninitializedException();
    }
}

public enum OptionalFailureErrorDatumMode { NoValue, Error, Failure }
public readonly partial record struct OptionalFailureErrorDatum<F>(
    OptionalFailureErrorDatumMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] FailureDatum<F> FailureDatum,
    [property: AllowNull][AllowNull] ErrorDatum ErrorDatum
    ) {

    //public bool TryGetNoDatum<V>(out NoDatum noDatum, out ValueFailureErrorDatum<V, F> elseDatum) {
    //    throw new NotImplementedException();
    //}
    //public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalValueErrorDatum<V> elseDatum) {
    //    throw new UninitializedException();
    //}
    //public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalValueFailureDatum<V, F> elseDatum) {
    //    throw new UninitializedException();
    //}
}

public enum OptionalValueFailureDatumMode { NoValue, Success, Failure }
public readonly partial record struct OptionalValueFailureDatum<V, F>(
    OptionalValueFailureDatumMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] ValueDatum<V> ValueDatum,
    [property: AllowNull][AllowNull] FailureDatum<F> FailureDatum
    ) {

    public bool TryGetNoDatum(out NoDatum noDatum, out ValueFailureErrorDatum<V, F> elseDatum) {
        throw new NotImplementedException();
    }

    public bool TryGetValueDatum(out ValueDatum<F> failureDatum, out OptionalFailureErrorDatum<F> elseDatum) {
        throw new NotImplementedException();
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalValueErrorDatum<V> elseDatum) {
        throw new UninitializedException();
    }
}