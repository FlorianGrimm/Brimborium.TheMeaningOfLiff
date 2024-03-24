namespace Brimborium.TheMeaningOfLiff;

public interface ITransformation<I, O>
    //where I : struct, IDatum
    //where O : struct, IDatum 
    {
    O Then(I arg);
}


public interface ITransformationAsync<I, O> {
    ValueTask<O> ExecuteAsync(I arg);
}

public class DoBlaBla
    : ITransformation<OptionalValueDatum<string>, OptionalValueDatum<int>> {
    public OptionalValueDatum<int> Then(OptionalValueDatum<string> arg) {
        return arg.Then(
            defaultValue: new NoDatum().AsOptionalValueDatum<int>(),
            funcOptionalDatum: (arg, dv) => dv,
            funcValueDatum: (arg, dv) => int.TryParse(arg.Value, out var result) ? dv.WithValue(result) : dv
            );
    }
}
public readonly partial record struct OptionalValueDatum<V> {
    public OV Then<OV>(ITransformation<OptionalValueDatum<V>, OV> transformation)
        where OV : struct, IDatum {
        return transformation.Then(this);
    }
}
public partial record struct TransformationDelegateOptionalValueDatum<V, TResult>(
    TResult DefaultValue,
    Func<NoDatum, TResult, TResult>? funcOptionalDatum,
    Func<ValueDatum<V>, TResult, TResult>? funcValueDatum
    ) : ITransformation<OptionalValueDatum<V>, TResult>
    where TResult : struct, IDatum {
    public TResult Then(OptionalValueDatum<V> arg) {
        if (arg.Mode == OptionalValueMode.NoValue) {
            if (funcOptionalDatum is null) {
                return this.DefaultValue;
            } else {
                return this.funcOptionalDatum(arg.OptionalDatum, this.DefaultValue);
            }
        } else if (arg.Mode == OptionalValueMode.Value) {
            if (funcValueDatum is null) {
                return this.DefaultValue;
            } else {
                return this.funcValueDatum(arg.ValueDatum, this.DefaultValue);
            }
        } else if (arg.Mode == OptionalValueMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException();
        }
    }
}

public partial record class TransformationOptionalValueDatum<V, O>(
    O DefaultValue
    ) 
    //where O : struct, IDatum 
    {

    public O Execute(OptionalValueDatum<V> arg) {
        if (arg.Mode == OptionalValueMode.NoValue) {
            return this.ExecuteOptionalDatum(arg.OptionalDatum);
        } else if (arg.Mode == OptionalValueMode.Value) {
            return this.ExecuteValueDatum(arg.ValueDatum);
        } else if (arg.Mode == OptionalValueMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException();
        }
    }

    public virtual O ExecuteOptionalDatum(NoDatum arg) {
        return this.DefaultValue;
    }

    public virtual O ExecuteValueDatum(ValueDatum<V> arg) {
        return this.DefaultValue;
    }
}


//public interface IHack<V> { 
//}
//public interface IHack<V,F> {
//}



//public readonly partial record struct NoDatum :IHack {
//}
//public readonly partial record struct ValueDatum<V> : IHack {
//}
//public readonly partial record struct ValueErrorDatum<V> : IHack {
//}
//public readonly partial record struct ValueFailureDatum<V, F> : IHack {
//}