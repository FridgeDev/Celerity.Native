#pragma once

namespace Celerity
{
	namespace Native {
		public ref class Interlocked abstract sealed
		{
		public:
			/// <summary>
			/// Decrements (decreases by one) the value of the specified 16-bit variable as an atomic operation.
			/// See: https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockeddecrement16
			/// </summary>
			/// <param name="addend">A pointer to the variable to be decremented.</param>
			/// <returns>The function returns the resulting decremented value.</returns>
			/// <remarks>
			/// The variable pointed to by the Addend parameter must be aligned on a 16-bit boundary; otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
			/// </remarks>
			static System::Int16 Decrement(System::Int16* addend);

			/// <summary>
			/// Decrements (decreases by one) the value of the specified 32-bit variable as an atomic operation.
			/// See: https://docs.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockeddecrement
			/// </summary>
			/// <param name="addend">A pointer to the variable to be decremented.</param>
			/// <returns>The function returns the resulting decremented value.</returns>
			/// <remarks>
			/// The variable pointed to by the Addend parameter must be aligned on a 32-bit boundary; otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems. 
			/// </remarks>
			static System::Int32 Decrement(System::Int32* addend);

			/// <summary>
			/// Decrements (decreases by one) the value of the specified 64-bit variable as an atomic operation.
			/// </summary>
			/// <param name="addend">A pointer to the variable to be decremented.</param>
			/// <returns>The function returns the resulting decremented value.</returns>
			/// <remarks>
			/// The variable pointed to by the Addend parameter must be aligned on a 64-bit boundary; otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems. 
			/// </remarks>
			static System::Int64 Decrement(System::Int64* addend);
		};
	}
}