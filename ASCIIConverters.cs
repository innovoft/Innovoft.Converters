using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Innovoft
{
	public static class ASCIIConverters
	{
		#region Constants
		public const byte NUL = 0x00;
		public const byte SOH = 0x01;
		public const byte STX = 0x02;
		public const byte ETX = 0x03;
		public const byte EOT = 0x04;
		public const byte ENQ = 0x05;
		public const byte ACK = 0x06;
		public const byte BEL = 0x07;
		public const byte BS = 0x08;
		public const byte TAB = 0x09;
		public const byte LF = 0x0A;
		public const byte VT = 0x0B;
		public const byte FF = 0x0C;
		public const byte CR = 0x0D;
		public const byte SO = 0x0E;
		public const byte SI = 0x0F;
		public const byte DLE = 0x10;
		public const byte DC1 = 0x11;
		public const byte DC2 = 0x12;
		public const byte DC3 = 0x13;
		public const byte DC4 = 0x14;
		public const byte NAK = 0x15;
		public const byte SYN = 0x16;
		public const byte ETB = 0x17;
		public const byte CAN = 0x18;
		public const byte EM = 0x19;
		public const byte SUB = 0x1A;
		public const byte ESC = 0x1B;
		public const byte FS = 0x1C;
		public const byte GS = 0x1D;
		public const byte RS = 0x1E;
		public const byte US = 0x1F;
		public const byte Space = 0x20;
		public const byte DoubleQuote = 0x22;
		public const byte SingleQuote = 0x27;
		public const byte Comma = 0x2C;
		public const byte Minus = 0x2D;
		public const byte Dash = 0x2D;
		public const byte Digit0 = 0x30;
		public const byte Digit1 = 0x31;
		public const byte Digit2 = 0x32;
		public const byte Digit3 = 0x33;
		public const byte Digit4 = 0x34;
		public const byte Digit5 = 0x35;
		public const byte Digit6 = 0x36;
		public const byte Digit7 = 0x37;
		public const byte Digit8 = 0x38;
		public const byte Digit9 = 0x39;
		public const byte Colon = 0x3A;
		public const byte SquareOpen = 0x5B;
		public const byte SquareClose = 0x5D;
		public const byte CurlyOpen = 0x7B;
		public const byte CurlyClose = 0x7D;
		public const byte Z = 0x5A;
		#endregion //Constants

		#region Methods
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsDigit(byte raw)
		{
			return raw >= Digit0 && raw <= Digit9;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetDigit(byte raw)
		{
			return raw - Digit0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDigit(byte raw, out int digit)
		{
			if (raw >= Digit0 && raw <= Digit9)
			{
				digit = raw - Digit0;
				return true;
			}
			else
			{
				digit = 0;
				return false;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int WriteTextOnly(byte[] raw, int offset, string value)
		{
			for (var i = 0; i < value.Length; ++i)
			{
				raw[offset] = (byte)value[i];
				offset++;
			}
			return offset;
		}
		#endregion //Methods
	}
}
