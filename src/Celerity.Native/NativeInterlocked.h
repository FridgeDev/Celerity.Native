#pragma once
#include <Windows.h>

SHORT NativeInterlockedDecrement16(volatile SHORT* addend);
LONG NativeInterlockedDecrement32(volatile LONG* addend);
LONG64 NativeInterlockedDecrement64(volatile LONG64* addend);