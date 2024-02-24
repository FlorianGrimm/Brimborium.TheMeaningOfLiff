namespace Brimborium.TheMeaningOfLiff;

internal static class UninitializedExceptionInstance {
    internal static class Singleton {
        internal static ErrorDatum _Uninitialized = CreateUninitialized();
    }
    public static ErrorDatum GetUninitialized() => Singleton._Uninitialized;

    public static ErrorDatum CreateUninitialized() {
        var error = UninitializedException.Instance;
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(error);
        return new ErrorDatum(error, exceptionDispatchInfo, default, 0, false);
    }
}

#if UnitTest
public class UninitializedExceptionInstanceTests {
    [Fact]
    public void SingletonTest() {
        var a = UninitializedExceptionInstance.GetUninitialized();
        var b = UninitializedExceptionInstance.GetUninitialized();
        Assert.NotNull(a.Exception);
        Assert.True(ReferenceEquals(a.Exception, b.Exception));
    }
}
#endif
