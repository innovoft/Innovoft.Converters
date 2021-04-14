using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft
{
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
	public delegate TOutput ConverterRead<TInput, out TOutput>(ReadOnlySpan<TInput> input);
#endif
}
