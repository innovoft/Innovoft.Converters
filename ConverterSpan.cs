using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft
{
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
	public delegate TOutput ConverterSpan<TInput, out TOutput>(Span<TInput> input);
#endif
}
