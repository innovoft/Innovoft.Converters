using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft
{
	public delegate bool TryConverter<in TInput, TOutput>(TInput intput, out TOutput output);
}
