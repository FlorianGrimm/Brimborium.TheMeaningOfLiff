using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brimborium.TheMeaningOfLiff;

[DebuggerNonUserCode]
[method: JsonConstructor]
public readonly partial record struct FailureDatum<F>(
    [property: Orleans.Id(0)] F Value,
    [property: Orleans.Id(1)] string? Meaning = default,
    [property: Orleans.Id(2)] long LogicalTimestamp = 0
    )
    : IDatum<F>
    , IWithMeaning
    , ILogicalTimestamp {
}

