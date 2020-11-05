#include "pch.h"
#include "NativeInterlocked.h"
#include <Windows.h>

SHORT NativeInterlockedDecrement16(volatile SHORT* addend)
{
    return InterlockedDecrement16(addend);
}

LONG NativeInterlockedDecrement32(volatile LONG* addend)
{
    return InterlockedDecrement(addend);
}

LONG64 NativeInterlockedDecrement64(volatile LONG64* addend)
{
    return InterlockedDecrement64(addend);
}