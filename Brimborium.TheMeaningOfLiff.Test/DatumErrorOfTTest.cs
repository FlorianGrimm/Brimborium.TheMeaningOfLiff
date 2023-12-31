namespace Brimborium.TheMeaningOfLiff;

public class DatumErrorOfTTest {
    [Fact]
    public void DatumErrorOfTCtor01() {
        var sut = new DatumError<int>();
        Assert.Equal(DatumErrorMode.NotInit, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCtor02() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        ErrorValue errorValue = new(new Exception("Hugo"), default, meaning, 1);
        var sut = new DatumError<int>(errorValue);
        Assert.Equal(DatumErrorMode.Error, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCtor03() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        var sut = new DatumError<int>(42, meaning, 1);
        Assert.Equal(DatumErrorMode.Success, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCastDatum() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        var datum = new Datum<int>(42, meaning, 1);
        DatumError<int> sut = datum;
        Assert.Equal(DatumErrorMode.Success, sut.Mode);
    }

    [Fact]
    public void DatumErrorOfTCastErrorValue() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        var errorValue = new ErrorValue(new Exception("Hugo"), default, meaning, 1);
        DatumError<int> sut = errorValue;
        Assert.Equal(DatumErrorMode.Error, sut.Mode);
    }
}
