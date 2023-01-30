# PrExt

This repo is a C# port of the algorithm proposed in the paper:

[A TECHNIQUE FOR EXACT COMPUTATION OF
PRECOLORING EXTENSION ON INTERVAL GRAPHS](https://imada.sdu.dk/~kslarsen/Papers/Resources/EL13j1/paper.pdf)

The original Python2 implementation as well as the sample data is available [here](https://imada.sdu.dk/~kslarsen/Archive/PrExtIntervalCampgrounds/).

The algorithm distributes colors from a fixed set to a set of intervals (some of which may be precolored, and should not be changed).   

This problem is also known as the "precoloring extension problem on interval graphs" and is NP-complete.

The algorithm has many applications such as optimally distributing lectures between classrooms, patients between hospital rooms, or bookings between restaurant tables.

This repo also provides simple tests and benchmarks on the sample data provided in the above paper.

**Run Tests**\
`dotnet test`

**Run Benchmarks**\
` dotnet run --project .\Benchmarks\Benchmarks.csproj -c release `