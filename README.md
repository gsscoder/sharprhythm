# SharpRhythm

Stub project for algorithms and data structures implementation C#. Inspired by [javascript-algorithms](https://github.com/trekhleb/javascript-algorithms).

# Build

**NOTE**: .NET Core 3.0 or higher is required.
```sh
# clone the repository
$ git clone https://github.com/gsscoder/sharprhythm.git

# build the package
$ cd sharprhythm/src/SharpRhythm
$ dotnet build -c Release.
```

## Test

```sh
# change to tests directory
$ cd sharprhythm/tests/SharpRhythm.Tests

# build with debug configuration
$ dotnet build -c Debug
...

# execute tests
$ dotnet test
...
```

### Implemented

* Algorithms
  * Sorting
    * [Bubble Sort](https://en.wikipedia.org/wiki/Bubble_sort)
    * [Quick Sort](https://en.wikipedia.org/wiki/Quicksort)
  * Strings
    * [Levenshtein Fuzzy Match](https://en.wikipedia.org/wiki/Levenshtein_distance)
* Data Structures
  * [Trie](https://en.wikipedia.org/wiki/Trie)