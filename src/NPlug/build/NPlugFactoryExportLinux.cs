using System.Runtime.InteropServices;

namespace NPlug.Interop;

/// <summary>
/// This class is responsible for exporting the current registered factory in <see cref="AudioPluginFactoryExporter.Instance"/>.
/// </summary>
internal static partial class NPlugFactoryExport
{
    [UnmanagedCallersOnly(EntryPoint = nameof(ModuleEntry))]
    private static bool ModuleEntry(nint sharedLibraryHandle) => true;

    [UnmanagedCallersOnly(EntryPoint = nameof(ModuleExit))]
    private static bool ModuleExit() => true;
}