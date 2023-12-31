namespace Brimborium.TheMeaningOfLiff;

public class OptionalDatumErrorOfTTest {
    [Fact]
    public void DatumErrorOfTCtor01() {
        var sut = new OptionalDatumError<int>();
        Assert.Equal(OptionalDatumErrorMode.NoValue, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCtor02() {
        var sut = new OptionalDatumError<int>(new NoDatum());
        Assert.Equal(OptionalDatumErrorMode.NoValue, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCtor03() {
        var meaning = MeaningPool.Get("Test", "OptionalDatumErrorOfTTest");
        ErrorValue errorValue = new(new Exception("Hugo"), default, meaning, 1);
        var sut = new OptionalDatumError<int>(errorValue);
        Assert.Equal(OptionalDatumErrorMode.Error, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCtor04() {
        var meaning = MeaningPool.Get("Test", "OptionalDatumErrorOfTTest");
        var sut = new OptionalDatumError<int>(42, meaning, 1);
        Assert.Equal(OptionalDatumErrorMode.Success, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCastNoDatum() {
        var meaning = MeaningPool.Get("Test", "OptionalDatumErrorOfTTest");
        var noDatum = new NoDatum( meaning, 1);
        OptionalDatumError<int> sut = noDatum;
        Assert.Equal(OptionalDatumErrorMode.NoValue, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCastDatum() {
        var meaning = MeaningPool.Get("Test", "OptionalDatumErrorOfTTest");
        var datum = new Datum<int>(42, meaning, 1);
        OptionalDatumError<int> sut = datum;
        Assert.Equal(OptionalDatumErrorMode.Success, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCastErrorValue() {
        var meaning = MeaningPool.Get("Test", "OptionalDatumErrorOfTTest");
        var errorValue = new ErrorValue(new Exception("Hugo"), default, meaning, 1);
        OptionalDatumError<int> sut = errorValue;
        Assert.Equal(OptionalDatumErrorMode.Error, sut.Mode);
    }

}
