namespace Bench;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using Brimborium.TheMeaningOfLiff;

public class Program {
    public static void Main(string[] args) {
        var summary = BenchmarkRunner.Run<Program>();
    }

    static int _a = 1;
    [Benchmark]
    public void A() {
        for (int i = 0; i < 1000; i++) {
            if (TryGetA(2, out var a1)) { _a = a1; }
            if (TryGetA(-2, out var a2)) { _a = a2; }
        }
    }

    //[MethodImpl(MethodImplOptions.NoInlining|MethodImplOptions.NoOptimization)]
    private static bool TryGetA(int value, [MaybeNullWhen(false)] out int a) {
        if (value > 0) {
            a = value;
            return true;
        } else {
            a = default;
            return false;
        }
    }


    private static int _b = 1;
    [Benchmark]
    public void B() {
        for (int i = 0; i < 1000; i++) {
            if (TryGetB(2).TryGetValue(out var b1)) { _b = b1; }
            if (TryGetB(-2).TryGetValue(out var b2)) { _b = b2; }
        }
    }

    //[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private static OptionalValueDatum<int> TryGetB(int value) {
        if (value > 0) {
            return value.AsOptionalValueDatum();
        } else {
            return Datum.NoDatum();
        }
    }
}