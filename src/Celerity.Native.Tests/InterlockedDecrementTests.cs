using System;
using Xunit;

namespace Celerity.Native.Tests
{
    public class InterlockedDecrementTests
    {
        [Fact]
        public unsafe void TestDecrementShort()
        {
            short e = 9;
            Interlocked.Decrement(&e);
            Assert.Equal(8, e);
        }

        [Fact]
        public unsafe void TestDecrementInt()
        {
            int e = 9;
            Interlocked.Decrement(&e);
            Assert.Equal(8, e);
        }

        [Fact]
        public unsafe void TestDecrementLong()
        {
            long e = 9;
            Interlocked.Decrement(&e);
            Assert.Equal(8, e);
        }
    }
}
