namespace NPlug;

/// <summary>
/// Defines the interface for handling Linux-specific timers for the audio plugin.
/// </summary>
/// <remarks>
/// Mirrors VST3's Steinberg::Linux::ITimerHandler (plug-in-implemented).
/// </remarks>
public interface IAudioPluginLinuxTimerHandler
{
    /// <summary>
    /// Called when the timer fires.
    /// </summary>
    void OnTimer();
}
