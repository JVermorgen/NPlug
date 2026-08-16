// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Runtime.CompilerServices;

namespace NPlug.Interop;

internal static unsafe partial class LibVst
{
    public partial struct IEventHandler
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IAudioPluginLinuxEventHandler Get(IEventHandler* self) => ((ComObjectHandle*)self)->As<IAudioPluginLinuxEventHandler>();

        private static partial void onFDIsSet_ToManaged(IEventHandler* self, FileDescriptor fd)
        {
            Get(self).OnFileDescriptorIsSet(fd);
        }
    }
}
