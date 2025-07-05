#if !NET5_0_OR_GREATER

using System.ComponentModel;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Runtime.CompilerServices;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class IsExternalInit
{
}

#endif
