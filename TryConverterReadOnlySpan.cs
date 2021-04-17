using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft
{
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
	public delegate bool TryConverterReadOnlySpan<TInput, TOutput>(ReadOnlySpan<TInput> intput, out TOutput output);
#endif //NETSTANDARD2_1 || NET5_0_OR_GREATER
}
