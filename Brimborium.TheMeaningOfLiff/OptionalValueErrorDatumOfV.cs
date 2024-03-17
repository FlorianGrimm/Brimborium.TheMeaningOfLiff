
namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueErrorDatumMode { NoValue, Success, Error }

[DebuggerNonUserCode]
[method: JsonConstructor]
public partial record struct OptionalValueErrorDatum<V>(
    OptionalValueErrorDatumMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] ValueDatum<V> ValueDatum,
    [property: AllowNull][AllowNull] ErrorDatum ErrorDatum
    )
    : IDatum<V>
    , IOptionalValueWithError<V, OptionalValueDatum<V>>
    , ILogicalTimestamp {

    public OptionalValueErrorDatum()
        : this(OptionalValueErrorDatumMode.NoValue, new NoDatum(), default, default) { }

    public OptionalValueErrorDatum(V value, string? meaning = default, long logicalTimestamp = 0)
        : this(OptionalValueErrorDatumMode.Success, default, new ValueDatum<V>(value, meaning, logicalTimestamp), default) {
    }

    public OptionalValueErrorDatum(NoDatum value) : this(OptionalValueErrorDatumMode.NoValue, value, default, default) { }

    public OptionalValueErrorDatum(ValueDatum<V> value) : this(OptionalValueErrorDatumMode.Success, default, value, default) { }

    public OptionalValueErrorDatum(ErrorDatum errorValue) : this(OptionalValueErrorDatumMode.Error, default, default, errorValue) { }

    //T IValue<T>.Value => this.Value;
    readonly V IDatum<V>.Value => this.Mode switch {
        OptionalValueErrorDatumMode.NoValue => throw new NoValueAccessingException(),
        OptionalValueErrorDatumMode.Success => this.ValueDatum.Value,
        OptionalValueErrorDatumMode.Error => this.ErrorDatum.ThrowNotReturn<V>(),
        _ => default!
    };

    public readonly string? Meaning => (this.Mode) switch {
        OptionalValueErrorDatumMode.NoValue => this.NoValue.Meaning,
        OptionalValueErrorDatumMode.Success => this.ValueDatum.Meaning,
        OptionalValueErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };

    public readonly long LogicalTimestamp => (this.Mode) switch {
        OptionalValueErrorDatumMode.NoValue => this.NoValue.LogicalTimestamp,
        OptionalValueErrorDatumMode.Success => this.ValueDatum.LogicalTimestamp,
        OptionalValueErrorDatumMode.Error => this.ErrorDatum.LogicalTimestamp,
        _ => 0
    };

    // TODO: better?    OptionalErrorValue
    public readonly void Deconstruct(out OptionalValueErrorDatumMode mode, out V? value, out OptionalErrorDatum error, out long logicalTimestamp) {
        switch (this.Mode) {
            case OptionalValueErrorDatumMode.Success:
                mode = OptionalValueErrorDatumMode.Success;
                value = this.ValueDatum.Value;
                error = default;
                logicalTimestamp = this.LogicalTimestamp;
                return;
            case OptionalValueErrorDatumMode.Error:
                mode = OptionalValueErrorDatumMode.Error;
                value = default;
                error = this.ErrorDatum;
                logicalTimestamp = this.ErrorDatum.LogicalTimestamp;
                return;
            default:
                mode = OptionalValueErrorDatumMode.NoValue;
                value = default;
                error = default;
                logicalTimestamp = this.LogicalTimestamp;
                return;
        }
    }

    public readonly bool TryGetNoValue() {
        if (this.Mode == OptionalValueErrorDatumMode.NoValue) {
            return true;
        } else if (this.Mode == OptionalValueErrorDatumMode.Success) {
            return false;
        } else if (this.Mode == OptionalValueErrorDatumMode.Error) {
            return false;
        } else {
            return true;
        }
    }

    public readonly bool TryGetNoValue([MaybeNullWhen(false)] out NoDatum value) {
        if (this.Mode == OptionalValueErrorDatumMode.NoValue) {
            value = this.NoValue!;
            return false;
        } else {
            value = default;
            return true;
        }
    }

    public readonly bool TryGetNoValue(
        [MaybeNullWhen(false)] out NoDatum noDatum,
        [MaybeNullWhen(true)] out ValueErrorDatum<V> elseDatum
        ) {
        if (this.Mode == OptionalValueErrorDatumMode.NoValue) {
            noDatum = this.NoValue!;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueErrorDatumMode.Success){
            noDatum = default;
            elseDatum = new ValueErrorDatum<V>(ValueErrorDatumMode.Success, this.ValueDatum, default);
            return false;
        } else if (this.Mode == OptionalValueErrorDatumMode.Error) {
            noDatum = default;
            elseDatum = new ValueErrorDatum<V>(ValueErrorDatumMode.Error, default, this.ErrorDatum);
            return false;
        } else {
            noDatum = default;
            elseDatum = new ValueErrorDatum<V>(ValueErrorDatumMode.Error, default, new ErrorDatum(UninitializedException.Instance, this.Meaning, this.LogicalTimestamp, false));
            return false;
        }
    }

    public readonly bool TryGetValue([MaybeNullWhen(false)] out V value) {
        if (this.Mode == OptionalValueErrorDatumMode.Success) {
            value = this.ValueDatum.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public readonly bool TryGetValue(
         [MaybeNullWhen(false)] out ValueDatum<V> datum,
         [MaybeNullWhen(true)] out OptionalErrorDatum elseDatum) {
        if (this.Mode == OptionalValueErrorDatumMode.Success) {
            datum = this.ValueDatum;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueErrorDatumMode.Error) {
            datum = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorDatumMode.Error, default!, this.ErrorDatum);
            return false;
        } else {
            datum = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorDatumMode.Error, this.NoValue, default!);
            return false;
        }
    }

    public readonly bool TryGetError([MaybeNullWhen(false)] out ErrorDatum error) {
        if (this.Mode == OptionalValueErrorDatumMode.Error) {
            System.Diagnostics.Debug.Assert(this.ErrorDatum.Exception is not null);
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public readonly bool TryGetError(
        [MaybeNullWhen(false)] out ErrorDatum errorDatum,
        [MaybeNullWhen(true)] out OptionalValueDatum<V> elseDatum) {
        if (this.Mode == OptionalValueErrorDatumMode.Error) {
            errorDatum = this.ErrorDatum;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueErrorDatumMode.Success) {
            errorDatum = default;
            elseDatum = new OptionalValueDatum<V>(OptionalValueDatumMode.Success, default, this.ValueDatum);
            return false;
        } else {
            errorDatum = default;
            elseDatum = new OptionalValueDatum<V>(OptionalValueDatumMode.NoValue, this.NoValue, default);
            return false;
        }
    }

    public bool TryGet(
        [MaybeNullWhen(false)] out V value,
        [MaybeNullWhen(true)] out OptionalErrorDatum elseDatum) {
        if (this.Mode == OptionalValueErrorDatumMode.Success) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueErrorDatumMode.Error) {
            value = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorDatumMode.Error, default!, this.ErrorDatum);
            return false;
        } else {
            value = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorDatumMode.NoValue, this.NoValue, default!);
            return false;
        }
    }

    public bool UpdateValueOrFailure(
        ref V value,
        [MaybeNullWhen(true)] out OptionalErrorDatum elseDatum) {
        if (this.Mode == OptionalValueErrorDatumMode.Success) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueErrorDatumMode.Error) {
            elseDatum = new OptionalErrorDatum(OptionalErrorDatumMode.Error, default!, this.ErrorDatum);
            return false;
        } else {
            elseDatum = default;
            return true;
        }
    }

    public readonly OptionalValueErrorDatum<V> WithNoValue() => new OptionalValueErrorDatum<V>();

    public readonly OptionalValueErrorDatum<V> WithValue(V value) => new OptionalValueErrorDatum<V>(value);

    public readonly OptionalValueErrorDatum<V> WithError(ErrorDatum error) => new OptionalValueErrorDatum<V>(error);

    //
    public OptionalValueErrorDatum<R> AsOptionalOf<R>(
        string? meaning = default,
        long logicalTimestamp = 0) {
        if (this.TryGetValue(out var value)) {
            if (value is R valueR) {
                return new OptionalValueDatum<R>(OptionalValueDatumMode.Success, default, new ValueDatum<R>(valueR, meaning, logicalTimestamp));
            } else {
                return new NoDatum(meaning, logicalTimestamp);
            }
        } else if (this.TryGetNoValue(out var noDatum)) {
            return noDatum;
        } else if (this.TryGetError(out var errorValue)) {
            return errorValue;
        } else {
            return new OptionalValueErrorDatum<R>(new InvalidEnumArgumentException($"Invalid enum {this.Mode}."));
        }
    }
}


#if UnitTest
public partial class OptionalValueErrorDatumOfTTest {
    [Fact]
    public void OptionalValueErrorDatumOfTCtor01() {
        var sut = new OptionalValueErrorDatum<int>();
        Assert.Equal(OptionalValueErrorDatumMode.NoValue, sut.Mode);
        Assert.Null(sut.Meaning);
        Assert.Equal(0L, sut.LogicalTimestamp);
        {
            Assert.False(sut.TryGet(out var value, out var optionalErrorDatum));
            Assert.Equal(0, value);
            Assert.True(optionalErrorDatum.TryGetNoDatum(out var noDatum, out var errorDatum));
            //Assert.IsType<UninitializedException>(error.Exception);
        }
    }

    [Fact]
    public void OptionalValueErrorDatumOfTCtor02() {
        var meaning = "TheMeaningOfLiff";
        ErrorDatum errorValue = new(new Exception("Hugo"), default, meaning, 1);
        var sut = new OptionalValueErrorDatum<int>(errorValue);
        Assert.Equal(OptionalValueErrorDatumMode.Error, sut.Mode);
        Assert.Same(meaning, sut.Meaning);
        Assert.Equal(1L, sut.LogicalTimestamp);
        {
            Assert.False(sut.TryGet(out var value, out var optionalErrorDatum));
            Assert.Equal(0, value);
            Assert.False(optionalErrorDatum.TryGetNoDatum(out var noDatum, out var errorDatum));
            //Assert.NotNull(error.Exception);
        }
    }

    [Fact]
    public void OptionalValueErrorDatumOfTCtor03() {
        var meaning = "TheMeaningOfLiff";
        var sut = new OptionalValueErrorDatum<int>(42, meaning, 2);
        Assert.Equal(OptionalValueErrorDatumMode.Success, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(2L, sut.LogicalTimestamp);
        {
            Assert.True(sut.TryGet(out var value, out var optionalErrorDatum));
            Assert.Equal(42, value);
            Assert.True(optionalErrorDatum.TryGetNoDatum(out var noDatum, out var errorDatum));
            //Assert.Null(error.Exception);
        }
    }

    [Fact]
    public void OptionalValueErrorDatumOfTCtor04() {
        var meaning = "TheMeaningOfLiff";
        var sut = new OptionalValueErrorDatum<int>(
            OptionalValueErrorDatumMode.Success,
            default,
            new ValueDatum<int>(42, meaning, 3),
            default);
        Assert.Equal(OptionalValueErrorDatumMode.Success, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(3L, sut.LogicalTimestamp);
        {
            Assert.True(sut.TryGet(out var value, out var optionalErrorDatum));
            Assert.Equal(42, value);
            Assert.True(optionalErrorDatum.TryGetNoDatum(out var noDatum, out var errorDatum));
            //Assert.Null(error.Exception);
        }
    }

    [Fact]
    public void OptionalValueErrorDatumOfTCastValueDatum() {
        var meaning = "TheMeaningOfLiff";
        var valueDatum = new ValueDatum<int>(42, meaning, 4);
        OptionalValueErrorDatum<int> sut = valueDatum;
        Assert.Equal(OptionalValueErrorDatumMode.Success, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(4L, sut.LogicalTimestamp);
        {
            Assert.True(sut.TryGet(out var value, out var optionalErrorDatum));
            Assert.Equal(42, value);
            Assert.True(optionalErrorDatum.TryGetNoDatum(out var noDatum, out var errorDatum));
            //Assert.Null(error.Exception);
        }
    }

    [Fact]
    public void OptionalValueErrorDatumOfTCastErrorDatum() {
        var meaning = "TheMeaningOfLiff";
        var errorDatum = new ErrorDatum(new Exception("Hugo"), default, meaning, 5);
        OptionalValueErrorDatum<int> sut = errorDatum;
        Assert.Equal(OptionalValueErrorDatumMode.Error, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(5L, sut.LogicalTimestamp);
    }

    [Fact]
    public void OptionalValueErrorDatumOfTCastOptionalValueDatum() {
        var meaning = "TheMeaningOfLiff";
        var optionalValueDatum = new OptionalValueDatum<int>(OptionalValueDatumMode.Success, default, new ValueDatum<int>(42, meaning));
        OptionalValueErrorDatum<int> sut = optionalValueDatum;
        Assert.Equal(OptionalValueErrorDatumMode.Success, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
    }
}

#endif