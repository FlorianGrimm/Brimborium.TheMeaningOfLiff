using System.Net.WebSockets;

namespace Brimborium.TheMeaningOfLiff;

public class DatumErrorOfTTest {
    [Fact]
    public void DatumErrorOfTCtor01() {
        var sut = new DatumError<int>();
        Assert.Equal(DatumErrorMode.NotInit, sut.Mode);
        Assert.Null(sut.Meaning);
        Assert.Equal(0L, sut.LogicalTimestamp);
        {
            Assert.False(sut.TryGet(out var value, out var error));
            Assert.Equal(0, value.Value);
            Assert.IsType<UninitializedException>(error.Exception);
        }
    }

    [Fact]
    public void DatumErrorOfTCtor02() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        ErrorValue errorValue = new(new Exception("Hugo"), default, meaning, 1);
        var sut = new DatumError<int>(errorValue);
        Assert.Equal(DatumErrorMode.Error, sut.Mode);
        Assert.Same(meaning, sut.Meaning);
        Assert.Equal(1L, sut.LogicalTimestamp);
        {
            Assert.False(sut.TryGet(out var value, out var error));
            Assert.Equal(0, value.Value);
            Assert.NotNull(error.Exception);
        }
    }

    [Fact]
    public void DatumErrorOfTCtor03() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        var sut = new DatumError<int>(42, meaning, 2);
        Assert.Equal(DatumErrorMode.Success, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(2L, sut.LogicalTimestamp);
        {
            Assert.True(sut.TryGet(out var value, out var error));
            Assert.Equal(42, value.Value);
            Assert.Null(error.Exception);
        }
    }

    [Fact]
    public void DatumErrorOfTCtor04() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        var sut = new DatumError<int>(DatumErrorMode.Success,
            new Datum<int>(42, meaning, 3),
            default);
        Assert.Equal(DatumErrorMode.Success, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(3L, sut.LogicalTimestamp);
        {
            Assert.True(sut.TryGet(out var value, out var error));
            Assert.Equal(42, value.Value);
            Assert.Null(error.Exception);
        }
    }

    [Fact]
    public void DatumErrorOfTCastDatum() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        var datum = new Datum<int>(42, meaning, 4);
        DatumError<int> sut = datum;
        Assert.Equal(DatumErrorMode.Success, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(4L, sut.LogicalTimestamp);
        {
            Assert.True(sut.TryGet(out var value, out var error));
            Assert.Equal(42, value.Value);
            Assert.Null(error.Exception);
        }
    }

    [Fact]
    public void DatumErrorOfTCastErrorValue() {
        var meaning = MeaningPool.Get("Test", "DatumErrorOfTTest");
        var errorValue = new ErrorValue(new Exception("Hugo"), default, meaning, 5);
        DatumError<int> sut = errorValue;
        Assert.Equal(DatumErrorMode.Error, sut.Mode);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(5L, sut.LogicalTimestamp);
    }
}
