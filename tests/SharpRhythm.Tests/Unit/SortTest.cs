using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FSharp.Collections;
using FluentAssertions;
using FsCheck;

namespace SharpRhythm.Tests.Unit
{
    public abstract class SortTest
    {
        protected void Execute<T>(FSharpList<T> list,
                                  Func<IEnumerable<T>, IEnumerable<T>> test)
            where T : IComparable, 
                      IComparable<T>
        {
            var expected = (from n in list
                            select n).ToArray().Sort();

            var sorted = test(list);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(list.Count())
                .And.ContainInOrder(expected);
        }
    }
}