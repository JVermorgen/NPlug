namespace NPlug;

/// <summary>
/// Linux-only capability, obtained by casting the <see cref="IAudioPluginFrame"/>
/// passed to <see cref="IAudioPluginView.SetFrame"/>. On Linux there is no global
/// event run loop, so the host exposes this interface to let the plug-in register
/// its own event handlers/timers with the host's loop instead.
/// </summary>
/// <remarks>Mirrors VST3's Steinberg::Linux::IRunLoop (host-implemented, extends IPlugFrame).</remarks>

public interface IAudioPluginRunLoop
{
    /// <summary>
    /// Registers a handler to be notified when the given file descriptor becomes readable.
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="fileDescriptor"></param>
    /// <returns></returns>
    bool RegisterEventHandler(IAudioPluginLinuxEventHandler handler, int fileDescriptor);

    /// <summary>
    /// Unregisters a Linux event handler.
    /// </summary>
    /// <param name="handler"></param>
    void UnregisterEventHandler(IAudioPluginLinuxEventHandler handler);

    /// <summary>
    /// Registers a timer handler to be called repeatedly at the specified interval.
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="intervalMilliseconds"></param>
    /// <returns></returns>
    bool RegisterTimer(IAudioPluginLinuxTimerHandler handler, ulong intervalMilliseconds);

    /// <summary>
    /// Unregisters a Linux timer handler.
    /// </summary>
    /// <param name="handler"></param>
    void UnregisterTimer(IAudioPluginLinuxTimerHandler handler);
}
