using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace Innovoft
{
	public static class DoubleConverter
	{
		#region Constants
		private const byte MinusByte = ASCIIConverter.Minus;
		private const byte Digit0Byte = ASCIIConverter.Digit0;
		#endregion //Constants

		#region Methods
		public static double Parse(XmlNode parse)
		{
			return double.Parse(parse.InnerText);
		}

		public static double? ParseNullable(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			else
			{
				return double.Parse(text);
			}
		}

		public static object ParseObject(string text)
		{
			return double.Parse(text);
		}

		public static bool TryParseObject(string parse, out object value)
		{
			if (double.TryParse(parse, out var parsed))
			{
				value = parsed;
				return true;
			}
			else
			{
				value = null;
				return false;
			}
		}

		public static int AscendingComparison(double x, double y)
		{
			if (x == y)
			{
				return 0;
			}
			if (x > y)
			{
				return +1;
			}
			else
			{
				return -1;
			}
		}

		public static int AscendingComparison(object x, object y)
		{
			var xv = (double)x;
			var yv = (double)y;
			if (xv == yv)
			{
				return 0;
			}
			if (xv > yv)
			{
				return +1;
			}
			else
			{
				return -1;
			}
		}

		public static int DescendingComparison(double x, double y)
		{
			if (x == y)
			{
				return 0;
			}
			if (x < y)
			{
				return +1;
			}
			else
			{
				return -1;
			}
		}

		public static int DescendingComparison(object x, object y)
		{
			var xv = (double)x;
			var yv = (double)y;
			if (xv == yv)
			{
				return 0;
			}
			if (xv < yv)
			{
				return +1;
			}
			else
			{
				return -1;
			}
		}

		public static bool IsNormal(double value)
		{
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
			return double.IsNormal(value);
#else //NETSTANDARD2_1 || NET5_0_OR_GREATER
			if (double.IsNaN(value))
			{
				return false;
			}
			if (double.IsInfinity(value))
			{
				return false;
			}
			return true;
#endif //NETSTANDARD2_1 || NET5_0_OR_GREATER
		}

		public static double GetNaN(double value)
		{
			return double.NaN;
		}

		public static double GetNaN()
		{
			return double.NaN;
		}

		#region Max
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Max(double v0, double v1)
		{
			return Math.Max(v0, v1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Max(double v0, double v1, double v2)
		{
			var max = v0;
			if (v1 > max)
			{
				max = v1;
			}
			if (v2 > max)
			{
				max = v2;
			}
			return max;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Max(double v0, double v1, double v2, double v3)
		{
			var max = v0;
			if (v1 > max)
			{
				max = v1;
			}
			if (v2 > max)
			{
				max = v2;
			}
			if (v3 > max)
			{
				max = v3;
			}
			return max;
		}

		public static double Max(params double[] values)
		{
			var max = values[0];
			for (var i = values.Length - 1; i > 0; --i)
			{
				var value = values[i];
				if (value > max)
				{
					max = value;
				}
			}
			return max;
		}

		public static double Max(IEnumerable<double> values)
		{
			using (var enumerator = values.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					throw new ArgumentException(nameof(values));
				}
				var max = enumerator.Current;
				while (enumerator.MoveNext())
				{
					var value = enumerator.Current;
					if (value > max)
					{
						max = value;
					}
				}
				return max;
			}
		}
		#endregion //Max

		#region NaN
		public static double NaN()
		{
			return double.NaN;
		}

		public static double NaN(double value)
		{
			return double.NaN;
		}

		public static bool NaN(double value, out double converted)
		{
			converted = double.NaN;
			return true;
		}
		#endregion //NaN

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
