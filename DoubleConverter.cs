using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Innovoft
{
	public static class DoubleConverter
	{
		#region Constants
		private const byte MinusByte = ASCIIConverter.Minus;
		private const byte Digit0Byte = ASCIIConverter.Digit0;
		#endregion //Constants

		#region Methods
		//[MethodImpl(MethodImplOptions.AggressiveInlining)]
		//public static int WriteDouble5(byte[] buffer, int offset, double value)
		//{
		//	var raw = BitConverter.DoubleToInt64Bits(value);

		//	var mantissa = raw & 0xFFFFFFFFFFFFFL;
		//	var exponent = ((int)(raw >> 52)) & 0x7FF;

		//	if (exponent == 0)
		//	{
		//		++exponent;
		//	}
		//	else
		//	{
		//		mantissa |= 1L << 52;
		//	}
		//	exponent -= (1 << (11 - 1)) - 1;

		//	if (raw < 0)
		//	{
		//		buffer[offset++] = MinusByte;
		//	}

		//	long fraction;
		//	if (exponent >= 0)
		//	{
		//		var whole = (int)(mantissa >> (52 - exponent));
		//		offset = WriteInt32Positive(offset, whole);
		//		fraction = (mantissa << (1 + exponent)) & 0x1FFFFFFFFFFFFFL;
		//	}
		//	else
		//	{
		//		buffer[offset++] = Digit0Byte;
		//		fraction = (mantissa & 0x1FFFFFFFFFFFFFL) >> -(exponent + 1);
		//	}

		//	//Fraction
		//	var point = true;
		//	var zeros = 0;
		//	for (var i = 5 - 1; i >= 0; --i)
		//	{
		//		fraction = (fraction << 3) + (fraction << 1);
		//		var digit = fraction >> (52 + 1);
		//		fraction &= 0x1FFFFFFFFFFFFFL;
		//		//if (digit != 9 && fraction >= 9000000000000000L)
		//		if (digit != 9 && fraction >= 0x1FFFFFFF000000L)
		//		{
		//			++digit;
		//			fraction = 0;
		//		}
		//		if (digit != 0)
		//		{
		//			if (point)
		//			{
		//				buffer[offset++] = 0x2E;//.
		//				point = false;
		//			}
		//			if (zeros > 0)
		//			{
		//				do
		//				{
		//					buffer[offset++] = Digit0Byte;
		//					--zeros;
		//				}
		//				while (zeros > 0);
		//			}
		//			buffer[offset++] = (byte)(digit + Digit0Byte);
		//		}
		//		else
		//		{
		//			++zeros;
		//		}
		//	}

		//	return offset;
		//}
		#endregion //Methods
	}
}
