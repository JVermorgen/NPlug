namespace NPlug;

/// <summary>
/// Defines the interface for handling Linux-specific events for the audio plugin.
/// </summary>
/// <remarks>
/// Mirrors VST3's Steinberg::Linux::IEventHandler (plug-in-implemented).
/// </remarks>
public interface IAudioPluginLinuxEventHandler
{
    /// <summary>
    /// Called when a file descriptor is set.
    /// </summary>
    /// <param name="fileDescriptor"></param>
    void OnFileDescriptorIsSet(int fileDescriptor);
}
