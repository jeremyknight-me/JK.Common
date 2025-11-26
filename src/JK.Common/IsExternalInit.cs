#if !NET5_0_OR_GREATER

using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Runtime.CompilerServices;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
[EditorBrowsable(EditorBrowsableState.Never)]
internal static class IsExternalInit
{
}

#endif
