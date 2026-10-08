namespace NPlug;

/// <summary>
/// Optional, for an <see cref="IAudioPluginView"/> that says whether it used a key. VST3's
/// onKeyDown/onKeyUp answer kResultTrue only for a key the plug-in handled - a host such as FL
/// Studio (with "Allow the plugin to handle keystrokes before the host") then keeps every other
/// key for its own shortcuts. A view without this answers kResultTrue for every key, as
/// <see cref="IAudioPluginView.OnKeyDown"/> returns nothing.
/// </summary>
public interface IAudioPluginViewKeyboard
{
    /// <summary>A key pressed: see <see cref="IAudioPluginView.OnKeyDown"/>. True when the view used it.</summary>
    /// <param name="key">The key's character (UTF-16), or 0.</param>
    /// <param name="keyCode">A VST3 VirtualKeyCodes value for a key without a character (keycodes.h), or 0.</param>
    /// <param name="modifiers">VST3 KeyModifier flags: shift 1, alternate 2, command (Ctrl on Windows) 4, control (macOS) 8.</param>
    bool OnKeyDown(ushort key, short keyCode, short modifiers);

    /// <summary>A key released: see <see cref="IAudioPluginView.OnKeyUp"/>. True when the view used it.</summary>
    bool OnKeyUp(ushort key, short keyCode, short modifiers);
}
