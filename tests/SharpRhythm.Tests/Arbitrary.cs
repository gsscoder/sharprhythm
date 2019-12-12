using Microsoft.FSharp.Core;
using Microsoft.FSharp.Collections;
using FsCheck;

namespace SharpRhythm.Tests
{
    static class ArbitraryIntegers
    {
        public static Arbitrary<FSharpList<int>> IntegerListGenerator()
        {
            return Gen.ListOf(30, Gen.Choose(-30, 30)).ToArbitrary();
        }
    }

    static class ArbitraryStrings
    {
        public static Arbitrary<FSharpList<string>> StringListGenerator()
        {
            return Gen.ListOf<string>(30, Gen.Filter(new NotNullAndAlphanumeric(), Arb.Generate<string>())).ToArbitrary();
        }

        class NotNullAndAlphanumeric : FSharpFunc<string, bool>
        {
            public override bool Invoke(string @string)
            {
                return @string != null && @string.IsAlphanumeric();
            }
        }
    }
}