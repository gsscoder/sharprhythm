using System;
using System.Linq;
using Microsoft.FSharp.Collections;
using FluentAssertions;
using FsCheck;
using CSharpx;
using SharpRhythm.Algorithms;

namespace SharpRhythm.Tests.Unit
{
    public abstract class SortTest
    {
        protected void Execute<T>(FSharpList<T> list, ISort sut)
            where T : IComparable, 
                      IComparable<T>
        {
            var expected = (from n in list
                            select n).ToArray().Sort();

            var sorted = sut.Sort(list);

            sorted.Should().NotBeEmpty()
                .And.HaveCount(list.Count())
                .And.ContainInOrder(expected);
        }
    }
}