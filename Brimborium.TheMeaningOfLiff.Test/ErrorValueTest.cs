namespace Brimborium.TheMeaningOfLiff;

#pragma warning disable xUnit2004 // Do not use equality check to test for boolean conditions

public class ErrorValueTest {
    [Fact]
    public void ErrorValueTest01() {
        Meaning meaning=MeaningPool.Get("Test", "ErrorValueTest");
        ErrorValue sut;
        try {
            throw new InvalidOperationException("Hugo");
        } catch (Exception error) {
            sut = ErrorValue.CreateFromCatchedException(error, meaning, 1);
        }
        Assert.NotNull(sut.Exception);
        Assert.Equal("Hugo", sut.Exception.Message);
        Assert.NotNull(sut.ExceptionDispatchInfo);
        Assert.NotNull(sut.Meaning);
        Assert.StrictEqual(meaning, sut.Meaning);
        Assert.Equal(false, sut.IsLogged);
        Assert.Throws<InvalidOperationException>(()=>sut.Throw());
        Assert.Throws<InvalidOperationException>(()=>sut.ThrowNotReturn<int>());
    }
}
