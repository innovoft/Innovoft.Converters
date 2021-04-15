using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft
{
	public static class DateTimeConverters
	{
		#region Constants
		private const char ZChar = CharConverters.Z;
		private const byte ZByte = ASCIIConverters.Z;
		#endregion //Constants

		#region Methods
		public static DateTime ParseOZ(string parse)
		{
			return ParseO(parse, DateTimeKind.Utc);
		}

		public static DateTime ParseOL(string parse)
		{
			return ParseO(parse, DateTimeKind.Local);
		}

		public static DateTime ParseO(string parse, DateTimeKind kind)
		{
			//yyyy-MM-ddTHH:mm:ss.fffffffZ
			//012345678901234567890123456
			var year = 0;
			var month = 0;
			var day = 0;
			var hour = 0;
			var minute = 0;
			var second = 0;
			var milli = 0;
			var ticks = 0L;
			for (var offset = 0; offset < parse.Length; ++offset)
			{
				var letter = parse[offset];

				switch (offset)
				{
				case 0://y
					year = 1000 * (letter - 0x30);
					break;

				case 1://yy
					year += 100 * (letter - 0x30);
					break;

				case 2://yyy
					year += 10 * (letter - 0x30);
					break;

				case 3://yyyy
					year += 1 * (letter - 0x30);
					break;

				case 4://yyyy-
					break;

				case 5://yyyy-M
					month += 10 * (letter - 0x30);
					break;

				case 6://yyyy-MM
					month += 1 * (letter - 0x30);
					break;

				case 7://yyyy-MM-
					break;

				case 8://yyyy-MM-d
					day += 10 * (letter - 0x30);
					break;

				case 9://yyyy-MM-dd
					day += 1 * (letter - 0x30);
					break;

				case 10://yyyy-MM-ddT
					break;

				case 11://yyyy-MM-ddTH
					hour += 10 * (letter - 0x30);
					break;

				case 12://yyyy-MM-ddTHH
					hour += 1 * (letter - 0x30);
					break;

				case 13://yyyy-MM-ddTHH:
					break;

				case 14://yyyy-MM-ddTHH:m
					minute += 10 * (letter - 0x30);
					break;

				case 15://yyyy-MM-ddTHH:mm
					minute += 1 * (letter - 0x30);
					break;

				case 16://yyyy-MM-ddTHH:mm:
					break;

				case 17://yyyy-MM-ddTHH:mm:s
					second += 10 * (letter - 0x30);
					break;

				case 18://yyyy-MM-ddTHH:mm:ss
					second += 1 * (letter - 0x30);
					break;

				case 19://yyyy-MM-ddTHH:mm:ss.
					break;

				case 20://yyyy-MM-ddTHH:mm:ss.f
					if (letter != ZChar)
					{
						milli += 100 * (letter - 0x30);
					}
					break;

				case 21://yyyy-MM-ddTHH:mm:ss.ff
					if (letter != ZChar)
					{
						milli += 10 * (letter - 0x30);
					}
					break;

				case 22://yyyy-MM-ddTHH:mm:ss.fff
					if (letter != ZChar)
					{
						milli += 1 * (letter - 0x30);
					}
					break;

				case 23://yyyy-MM-ddTHH:mm:ss.ffff
					if (letter != ZChar)
					{
						ticks += 1_000 * (letter - 0x30);
					}
					break;

				case 24://yyyy-MM-ddTHH:mm:ss.fffff
					if (letter != ZChar)
					{
						ticks += 100 * (letter - 0x30);
					}
					break;

				case 25://yyyy-MM-ddTHH:mm:ss.ffffff
					if (letter != ZChar)
					{
						ticks += 10 * (letter - 0x30);
					}
					break;

				case 26://yyyy-MM-ddTHH:mm:ss.fffffff
					if (letter != ZChar)
					{
						ticks += 1 * (letter - 0x30);
					}
					break;
				}
			}
			var value = new DateTime(year, month, day, hour, minute, second, milli, kind);
			if (ticks <= 0)
			{
				return value;
			}
			else
			{
				return value.AddTicks(ticks);
			}
		}

		public static DateTime ParseOZ(char[] parse, int offset, int length)
		{
			//yyyy-MM-ddTHH:mm:ss.fffffffZ
			//012345678901234567890123456
			var year = 0;
			var month = 0;
			var day = 0;
			var hour = 0;
			var minute = 0;
			var second = 0;
			var milli = 0;
			var ticks = 0L;
			for (var i = 0; i < length; ++i)
			{
				var letter = parse[offset + i];

				switch (i)
				{
				case 0://y
					year = 1000 * (letter - 0x30);
					break;

				case 1://yy
					year += 100 * (letter - 0x30);
					break;

				case 2://yyy
					year += 10 * (letter - 0x30);
					break;

				case 3://yyyy
					year += 1 * (letter - 0x30);
					break;

				case 4://yyyy-
					break;

				case 5://yyyy-M
					month += 10 * (letter - 0x30);
					break;

				case 6://yyyy-MM
					month += 1 * (letter - 0x30);
					break;

				case 7://yyyy-MM-
					break;

				case 8://yyyy-MM-d
					day += 10 * (letter - 0x30);
					break;

				case 9://yyyy-MM-dd
					day += 1 * (letter - 0x30);
					break;

				case 10://yyyy-MM-ddT
					break;

				case 11://yyyy-MM-ddTH
					hour += 10 * (letter - 0x30);
					break;

				case 12://yyyy-MM-ddTHH
					hour += 1 * (letter - 0x30);
					break;

				case 13://yyyy-MM-ddTHH:
					break;

				case 14://yyyy-MM-ddTHH:m
					minute += 10 * (letter - 0x30);
					break;

				case 15://yyyy-MM-ddTHH:mm
					minute += 1 * (letter - 0x30);
					break;

				case 16://yyyy-MM-ddTHH:mm:
					break;

				case 17://yyyy-MM-ddTHH:mm:s
					second += 10 * (letter - 0x30);
					break;

				case 18://yyyy-MM-ddTHH:mm:ss
					second += 1 * (letter - 0x30);
					break;

				case 19://yyyy-MM-ddTHH:mm:ss.
					break;

				case 20://yyyy-MM-ddTHH:mm:ss.f
					if (letter != ZChar)
					{
						milli += 100 * (letter - 0x30);
					}
					break;

				case 21://yyyy-MM-ddTHH:mm:ss.ff
					if (letter != ZChar)
					{
						milli += 10 * (letter - 0x30);
					}
					break;

				case 22://yyyy-MM-ddTHH:mm:ss.fff
					if (letter != ZChar)
					{
						milli += 1 * (letter - 0x30);
					}
					break;

				case 23://yyyy-MM-ddTHH:mm:ss.ffff
					if (letter != ZChar)
					{
						ticks += 1_000 * (letter - 0x30);
					}
					break;

				case 24://yyyy-MM-ddTHH:mm:ss.fffff
					if (letter != ZChar)
					{
						ticks += 100 * (letter - 0x30);
					}
					break;

				case 25://yyyy-MM-ddTHH:mm:ss.ffffff
					if (letter != ZChar)
					{
						ticks += 10 * (letter - 0x30);
					}
					break;

				case 26://yyyy-MM-ddTHH:mm:ss.fffffff
					if (letter != ZChar)
					{
						ticks += 1 * (letter - 0x30);
					}
					break;
				}
			}
			var value = new DateTime(year, month, day, hour, minute, second, milli, DateTimeKind.Utc);
			if (ticks <= 0)
			{
				return value;
			}
			else
			{
				return value.AddTicks(ticks);
			}
		}

		public static DateTime ParseOZ(byte[] parse, int offset, int length)
		{
			//yyyy-MM-ddTHH:mm:ss.fffffffZ
			//012345678901234567890123456
			var year = 0;
			var month = 0;
			var day = 0;
			var hour = 0;
			var minute = 0;
			var second = 0;
			var milli = 0;
			var ticks = 0L;
			for (var i = 0; i < length; ++i)
			{
				var letter = parse[offset + i];

				switch (i)
				{
				case 0://y
					year = 1000 * (letter - 0x30);
					break;

				case 1://yy
					year += 100 * (letter - 0x30);
					break;

				case 2://yyy
					year += 10 * (letter - 0x30);
					break;

				case 3://yyyy
					year += 1 * (letter - 0x30);
					break;

				case 4://yyyy-
					break;

				case 5://yyyy-M
					month += 10 * (letter - 0x30);
					break;

				case 6://yyyy-MM
					month += 1 * (letter - 0x30);
					break;

				case 7://yyyy-MM-
					break;

				case 8://yyyy-MM-d
					day += 10 * (letter - 0x30);
					break;

				case 9://yyyy-MM-dd
					day += 1 * (letter - 0x30);
					break;

				case 10://yyyy-MM-ddT
					break;

				case 11://yyyy-MM-ddTH
					hour += 10 * (letter - 0x30);
					break;

				case 12://yyyy-MM-ddTHH
					hour += 1 * (letter - 0x30);
					break;

				case 13://yyyy-MM-ddTHH:
					break;

				case 14://yyyy-MM-ddTHH:m
					minute += 10 * (letter - 0x30);
					break;

				case 15://yyyy-MM-ddTHH:mm
					minute += 1 * (letter - 0x30);
					break;

				case 16://yyyy-MM-ddTHH:mm:
					break;

				case 17://yyyy-MM-ddTHH:mm:s
					second += 10 * (letter - 0x30);
					break;

				case 18://yyyy-MM-ddTHH:mm:ss
					second += 1 * (letter - 0x30);
					break;

				case 19://yyyy-MM-ddTHH:mm:ss.
					break;

				case 20://yyyy-MM-ddTHH:mm:ss.f
					if (letter != ZByte)
					{
						milli += 100 * (letter - 0x30);
					}
					break;

				case 21://yyyy-MM-ddTHH:mm:ss.ff
					if (letter != ZByte)
					{
						milli += 10 * (letter - 0x30);
					}
					break;

				case 22://yyyy-MM-ddTHH:mm:ss.fff
					if (letter != ZByte)
					{
						milli += 1 * (letter - 0x30);
					}
					break;

				case 23://yyyy-MM-ddTHH:mm:ss.ffff
					if (letter != ZByte)
					{
						ticks += 1_000 * (letter - 0x30);
					}
					break;

				case 24://yyyy-MM-ddTHH:mm:ss.fffff
					if (letter != ZByte)
					{
						ticks += 100 * (letter - 0x30);
					}
					break;

				case 25://yyyy-MM-ddTHH:mm:ss.ffffff
					if (letter != ZByte)
					{
						ticks += 10 * (letter - 0x30);
					}
					break;

				case 26://yyyy-MM-ddTHH:mm:ss.fffffff
					if (letter != ZByte)
					{
						ticks += 1 * (letter - 0x30);
					}
					break;
				}
			}
			var value = new DateTime(year, month, day, hour, minute, second, milli, DateTimeKind.Utc);
			if (ticks <= 0)
			{
				return value;
			}
			else
			{
				return value.AddTicks(ticks);
			}
		}

#if NETSTANDARD2_1 || NET5_0_OR_GREATER
		public static DateTime ParseOZ(ReadOnlySpan<char> parse)
		{
			//yyyy-MM-ddTHH:mm:ss.fffffffZ
			//012345678901234567890123456
			var year = 0;
			var month = 0;
			var day = 0;
			var hour = 0;
			var minute = 0;
			var second = 0;
			var milli = 0;
			var ticks = 0L;
			for (var offset = 0; offset < parse.Length; ++offset)
			{
				var letter = parse[offset];

				switch (offset)
				{
				case 0://y
					year = 1000 * (letter - 0x30);
					break;

				case 1://yy
					year += 100 * (letter - 0x30);
					break;

				case 2://yyy
					year += 10 * (letter - 0x30);
					break;

				case 3://yyyy
					year += 1 * (letter - 0x30);
					break;

				case 4://yyyy-
					break;

				case 5://yyyy-M
					month += 10 * (letter - 0x30);
					break;

				case 6://yyyy-MM
					month += 1 * (letter - 0x30);
					break;

				case 7://yyyy-MM-
					break;

				case 8://yyyy-MM-d
					day += 10 * (letter - 0x30);
					break;

				case 9://yyyy-MM-dd
					day += 1 * (letter - 0x30);
					break;

				case 10://yyyy-MM-ddT
					break;

				case 11://yyyy-MM-ddTH
					hour += 10 * (letter - 0x30);
					break;

				case 12://yyyy-MM-ddTHH
					hour += 1 * (letter - 0x30);
					break;

				case 13://yyyy-MM-ddTHH:
					break;

				case 14://yyyy-MM-ddTHH:m
					minute += 10 * (letter - 0x30);
					break;

				case 15://yyyy-MM-ddTHH:mm
					minute += 1 * (letter - 0x30);
					break;

				case 16://yyyy-MM-ddTHH:mm:
					break;

				case 17://yyyy-MM-ddTHH:mm:s
					second += 10 * (letter - 0x30);
					break;

				case 18://yyyy-MM-ddTHH:mm:ss
					second += 1 * (letter - 0x30);
					break;

				case 19://yyyy-MM-ddTHH:mm:ss.
					break;

				case 20://yyyy-MM-ddTHH:mm:ss.f
					if (letter != ZChar)
					{
						milli += 100 * (letter - 0x30);
					}
					break;

				case 21://yyyy-MM-ddTHH:mm:ss.ff
					if (letter != ZChar)
					{
						milli += 10 * (letter - 0x30);
					}
					break;

				case 22://yyyy-MM-ddTHH:mm:ss.fff
					if (letter != ZChar)
					{
						milli += 1 * (letter - 0x30);
					}
					break;

				case 23://yyyy-MM-ddTHH:mm:ss.ffff
					if (letter != ZChar)
					{
						ticks += 1_000 * (letter - 0x30);
					}
					break;

				case 24://yyyy-MM-ddTHH:mm:ss.fffff
					if (letter != ZChar)
					{
						ticks += 100 * (letter - 0x30);
					}
					break;

				case 25://yyyy-MM-ddTHH:mm:ss.ffffff
					if (letter != ZChar)
					{
						ticks += 10 * (letter - 0x30);
					}
					break;

				case 26://yyyy-MM-ddTHH:mm:ss.fffffff
					if (letter != ZChar)
					{
						ticks += 1 * (letter - 0x30);
					}
					break;
				}
			}
			var value = new DateTime(year, month, day, hour, minute, second, milli, DateTimeKind.Utc);
			if (ticks <= 0)
			{
				return value;
			}
			else
			{
				return value.AddTicks(ticks);
			}
		}

		public static DateTime ParseOZ(ReadOnlySpan<byte> parse)
		{
			//yyyy-MM-ddTHH:mm:ss.fffffffZ
			//012345678901234567890123456
			var year = 0;
			var month = 0;
			var day = 0;
			var hour = 0;
			var minute = 0;
			var second = 0;
			var milli = 0;
			var ticks = 0L;
			for (var offset = 0; offset < parse.Length; ++offset)
			{
				var letter = parse[offset];

				switch (offset)
				{
				case 0://y
					year = 1000 * (letter - 0x30);
					break;

				case 1://yy
					year += 100 * (letter - 0x30);
					break;

				case 2://yyy
					year += 10 * (letter - 0x30);
					break;

				case 3://yyyy
					year += 1 * (letter - 0x30);
					break;

				case 4://yyyy-
					break;

				case 5://yyyy-M
					month += 10 * (letter - 0x30);
					break;

				case 6://yyyy-MM
					month += 1 * (letter - 0x30);
					break;

				case 7://yyyy-MM-
					break;

				case 8://yyyy-MM-d
					day += 10 * (letter - 0x30);
					break;

				case 9://yyyy-MM-dd
					day += 1 * (letter - 0x30);
					break;

				case 10://yyyy-MM-ddT
					break;

				case 11://yyyy-MM-ddTH
					hour += 10 * (letter - 0x30);
					break;

				case 12://yyyy-MM-ddTHH
					hour += 1 * (letter - 0x30);
					break;

				case 13://yyyy-MM-ddTHH:
					break;

				case 14://yyyy-MM-ddTHH:m
					minute += 10 * (letter - 0x30);
					break;

				case 15://yyyy-MM-ddTHH:mm
					minute += 1 * (letter - 0x30);
					break;

				case 16://yyyy-MM-ddTHH:mm:
					break;

				case 17://yyyy-MM-ddTHH:mm:s
					second += 10 * (letter - 0x30);
					break;

				case 18://yyyy-MM-ddTHH:mm:ss
					second += 1 * (letter - 0x30);
					break;

				case 19://yyyy-MM-ddTHH:mm:ss.
					break;

				case 20://yyyy-MM-ddTHH:mm:ss.f
					if (letter != ZByte)
					{
						milli += 100 * (letter - 0x30);
					}
					break;

				case 21://yyyy-MM-ddTHH:mm:ss.ff
					if (letter != ZByte)
					{
						milli += 10 * (letter - 0x30);
					}
					break;

				case 22://yyyy-MM-ddTHH:mm:ss.fff
					if (letter != ZByte)
					{
						milli += 1 * (letter - 0x30);
					}
					break;

				case 23://yyyy-MM-ddTHH:mm:ss.ffff
					if (letter != ZByte)
					{
						ticks += 1_000 * (letter - 0x30);
					}
					break;

				case 24://yyyy-MM-ddTHH:mm:ss.fffff
					if (letter != ZByte)
					{
						ticks += 100 * (letter - 0x30);
					}
					break;

				case 25://yyyy-MM-ddTHH:mm:ss.ffffff
					if (letter != ZByte)
					{
						ticks += 10 * (letter - 0x30);
					}
					break;

				case 26://yyyy-MM-ddTHH:mm:ss.fffffff
					if (letter != ZByte)
					{
						ticks += 1 * (letter - 0x30);
					}
					break;
				}
			}
			var value = new DateTime(year, month, day, hour, minute, second, milli, DateTimeKind.Utc);
			if (ticks <= 0)
			{
				return value;
			}
			else
			{
				return value.AddTicks(ticks);
			}
		}

		public static bool TryParseOZ(ReadOnlySpan<byte> parse, out DateTime value)
		{
			return TryParseO(parse, DateTimeKind.Utc, out value);
		}

		public static bool TryParseOL(ReadOnlySpan<byte> parse, out DateTime value)
		{
			return TryParseO(parse, DateTimeKind.Local, out value);
		}

		public static bool TryParseOU(ReadOnlySpan<byte> parse, out DateTime value)
		{
			return TryParseO(parse, DateTimeKind.Unspecified, out value);
		}

		public static bool TryParseO(ReadOnlySpan<byte> parse, DateTimeKind kind, out DateTime value)
		{
			//yyyy-MM-ddTHH:mm:ss.fffffffZ
			//012345678901234567890123456
			var year = 0;
			var month = 0;
			var day = 0;
			var hour = 0;
			var minute = 0;
			var second = 0;
			var milli = 0;
			var ticks = 0L;
			for (var offset = 0; offset < parse.Length; ++offset)
			{
				var letter = parse[offset];

				switch (offset)
				{
				case 0://y
					year = 1000 * (letter - 0x30);
					break;

				case 1://yy
					year += 100 * (letter - 0x30);
					break;

				case 2://yyy
					year += 10 * (letter - 0x30);
					break;

				case 3://yyyy
					year += 1 * (letter - 0x30);
					break;

				case 4://yyyy-
					break;

				case 5://yyyy-M
					month += 10 * (letter - 0x30);
					break;

				case 6://yyyy-MM
					month += 1 * (letter - 0x30);
					break;

				case 7://yyyy-MM-
					break;

				case 8://yyyy-MM-d
					day += 10 * (letter - 0x30);
					break;

				case 9://yyyy-MM-dd
					day += 1 * (letter - 0x30);
					break;

				case 10://yyyy-MM-ddT
					break;

				case 11://yyyy-MM-ddTH
					hour += 10 * (letter - 0x30);
					break;

				case 12://yyyy-MM-ddTHH
					hour += 1 * (letter - 0x30);
					break;

				case 13://yyyy-MM-ddTHH:
					break;

				case 14://yyyy-MM-ddTHH:m
					minute += 10 * (letter - 0x30);
					break;

				case 15://yyyy-MM-ddTHH:mm
					minute += 1 * (letter - 0x30);
					break;

				case 16://yyyy-MM-ddTHH:mm:
					break;

				case 17://yyyy-MM-ddTHH:mm:s
					second += 10 * (letter - 0x30);
					break;

				case 18://yyyy-MM-ddTHH:mm:ss
					second += 1 * (letter - 0x30);
					break;

				case 19://yyyy-MM-ddTHH:mm:ss.
					break;

				case 20://yyyy-MM-ddTHH:mm:ss.f
					if (letter != ZByte)
					{
						milli += 100 * (letter - 0x30);
					}
					break;

				case 21://yyyy-MM-ddTHH:mm:ss.ff
					if (letter != ZByte)
					{
						milli += 10 * (letter - 0x30);
					}
					break;

				case 22://yyyy-MM-ddTHH:mm:ss.fff
					if (letter != ZByte)
					{
						milli += 1 * (letter - 0x30);
					}
					break;

				case 23://yyyy-MM-ddTHH:mm:ss.ffff
					if (letter != ZByte)
					{
						ticks += 1_000 * (letter - 0x30);
					}
					break;

				case 24://yyyy-MM-ddTHH:mm:ss.fffff
					if (letter != ZByte)
					{
						ticks += 100 * (letter - 0x30);
					}
					break;

				case 25://yyyy-MM-ddTHH:mm:ss.ffffff
					if (letter != ZByte)
					{
						ticks += 10 * (letter - 0x30);
					}
					break;

				case 26://yyyy-MM-ddTHH:mm:ss.fffffff
					if (letter != ZByte)
					{
						ticks += 1 * (letter - 0x30);
					}
					break;
				}
			}
			DateTime temp;
			try
			{
				temp = new DateTime(year, month, day, hour, minute, second, milli, kind);
			}
			catch
			{
				value = default;
				return false;
			}
			if (ticks <= 0)
			{
				value = temp;
				return true;
			}
			else
			{
				value = temp.AddTicks(ticks);
				return true;
			}
		}
#endif //NETSTANDARD2_1 || NET5_0_OR_GREATER
		#endregion //Methods
	}
}
