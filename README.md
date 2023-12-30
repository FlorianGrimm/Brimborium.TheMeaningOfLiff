# Brimborium.TheMeaningOfLiff

Meaning(n): Blathering Optional Value Error structs

Douglas Adams and John Lloyd book "Meaning of Liff" give humour meanings a name.

## The dream

o A developer and a administator understand your logs.
o You can reason about your current issue.
o Before you hit your debugger you look at your logs.
o You can validate your end to end / integration tests based on the logs.

## The goals

The logs are piped through Open Telemetry.
A monitoring tool like JaegerUI / Aspire can run rules to find the issue or validate your tests.
The logs are enhanced so that you can reason about the values over different abstraction layers / components.
The code structure supports logging and is not too much extra code.
