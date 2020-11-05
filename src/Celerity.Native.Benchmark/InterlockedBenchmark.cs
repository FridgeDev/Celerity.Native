using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.InteropServices;

namespace Celerity.Native.Benchmark
{
    public unsafe class InterlockedBenchmark
    {
        private static readonly object sync = new object();
        private IntPtr memoryPointer;

        private IntPtr shortAllignedAddress;
        private short* shortAllignedPointer;

        private IntPtr intAllignedAddress;
        private int* intAllignedPointer;

        private IntPtr longAllignedAddress;
        private long* longAllignedPointer;

        [GlobalSetup]
        public void Setup()
        {
            this.memoryPointer = Marshal.AllocHGlobal(cb: 1024);

            this.shortAllignedAddress = new IntPtr(memoryPointer.ToInt64() + 128 + ((memoryPointer.ToInt64() + 128) % 16));
            this.shortAllignedPointer = (short*)this.shortAllignedAddress.ToPointer();

            this.intAllignedAddress = new IntPtr(memoryPointer.ToInt64() + 256 + ((memoryPointer.ToInt64() + 256) % 32));
            this.intAllignedPointer = (int*)this.intAllignedAddress.ToPointer();

            this.longAllignedAddress = new IntPtr(memoryPointer.ToInt64() + 512 + ((memoryPointer.ToInt64() + 512) % 64));
            this.longAllignedPointer = (long*)this.longAllignedAddress.ToPointer();

            Marshal.WriteInt16(shortAllignedAddress, 10);
            Marshal.WriteInt32(intAllignedAddress, 10);
            Marshal.WriteInt64(longAllignedAddress, 10);
        }

        [Benchmark]
        public int DecrementUnlockedInt()
        {
            int value = 10;
            value = value - 1;
            return value;
        }

        [Benchmark]
        public void DecrementLockedInt()
        {
            int value = 10;
            lock (sync)
            {
                value--;
            }
        }

        [Benchmark]
        public unsafe void DecrementShortNative()
        {
            short value = 10;
            Celerity.Native.Interlocked.Decrement(&value);
        }

        [Benchmark]
        public unsafe void DecrementShortNativeAlligned()
        {
            Celerity.Native.Interlocked.Decrement(this.shortAllignedPointer);
        }

        [Benchmark]
        public unsafe void DecrementIntNative()
        {
            int value = 10;
            Celerity.Native.Interlocked.Decrement(&value);
        }

        [Benchmark]
        public unsafe void DecrementIntNativeAlligned()
        {
            Celerity.Native.Interlocked.Decrement(this.intAllignedPointer);
        }


        [Benchmark]
        public void DecrementIntManaged()
        {
            int value = 10;
            System.Threading.Interlocked.Decrement(ref value);
        }

        [Benchmark]
        public unsafe void DecrementLongNative()
        {
            long value = 10;
            Celerity.Native.Interlocked.Decrement(&value);
        }

        [Benchmark]
        public unsafe void DecrementLongNativeAlligned()
        {
            Celerity.Native.Interlocked.Decrement(this.longAllignedPointer);
        }

        [Benchmark]
        public void DecrementLongManaged()
        {
            long value = 10;
            System.Threading.Interlocked.Decrement(ref value);
        }
    }
}