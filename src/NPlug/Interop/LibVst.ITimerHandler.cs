// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Runtime.CompilerServices;

namespace NPlug.Interop;

internal static unsafe partial class LibVst
{
    public partial struct ITimerHandler
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IAudioPluginLinuxTimerHandler Get(ITimerHandler* self) => ((ComObjectHandle*)self)->As<IAudioPluginLinuxTimerHandler>();

        private static partial void onTimer_ToManaged(ITimerHandler* self)
        {
            Get(self).OnTimer();
        }
    }
}