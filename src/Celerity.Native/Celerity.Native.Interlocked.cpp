#include "pch.h"
#include "Celerity.Native.Interlocked.h"
#include "NativeInterlocked.h"

System::Int16 Celerity::Native::Interlocked::Decrement(System::Int16* addend)
{
	return NativeInterlockedDecrement16(addend);
}

System::Int32 Celerity::Native::Interlocked::Decrement(System::Int32* addend)
{
	return NativeInterlockedDecrement32((long*)addend);
}

System::Int64 Celerity::Native::Interlocked::Decrement(System::Int64* addend)
{
	return NativeInterlockedDecrement64(addend);
}