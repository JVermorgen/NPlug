// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.
namespace NPlug.Interop;


using System;

internal static unsafe partial class LibVst
{
    public partial struct IPlugFrame
    {
        private static partial ComResult resizeView_ToManaged(IPlugFrame* self, LibVst.IPlugView* view, LibVst.ViewRect* newSize)
        {
            throw new NotImplementedException();
        }
    }

    private class AudioPluginFrameVst : IAudioPluginFrame, IAudioPluginRunLoop
    {
        private readonly IPlugFrame* _frame;

        public AudioPluginFrameVst(IPlugFrame* frame)
        {
            _frame = frame;
        }

        public void ResizeView(IAudioPluginView view, ViewRectangle newSize)
        {
            var comObject = ComObjectManager.Instance.GetOrCreateComObject(view);
            var plugView = comObject.QueryInterface<IPlugView>();
            _frame->resizeView(plugView, (ViewRect*)&newSize);
        }

        public bool RegisterEventHandler(IAudioPluginLinuxEventHandler handler, int fileDescriptor)
        {
            var runLoop = QueryRunLoop();
            if (runLoop == null) return false;

            var comObject = ComObjectManager.Instance.GetOrCreateComObject(handler);
            var nativeHandler = comObject.QueryInterface<IEventHandler>();
            return runLoop->registerEventHandler(nativeHandler, fileDescriptor) == ComResult.Ok;
        }

        public void UnregisterEventHandler(IAudioPluginLinuxEventHandler handler)
        {
            var runLoop = QueryRunLoop();
            if (runLoop == null) return;

            var comObject = ComObjectManager.Instance.GetOrCreateComObject(handler);
            var nativeHandler = comObject.QueryInterface<IEventHandler>();
            runLoop->unregisterEventHandler(nativeHandler);
        }

        public bool RegisterTimer(IAudioPluginLinuxTimerHandler handler, ulong intervalMilliseconds)
        {
            var runLoop = QueryRunLoop();
            if (runLoop == null) return false;

            var comObject = ComObjectManager.Instance.GetOrCreateComObject(handler);
            var nativeHandler = comObject.QueryInterface<ITimerHandler>();
            return runLoop->registerTimer(nativeHandler, intervalMilliseconds) == ComResult.Ok;
        }

        public void UnregisterTimer(IAudioPluginLinuxTimerHandler handler)
        {
            var runLoop = QueryRunLoop();
            if (runLoop == null) return;

            var comObject = ComObjectManager.Instance.GetOrCreateComObject(handler);
            var nativeHandler = comObject.QueryInterface<ITimerHandler>();
            runLoop->unregisterTimer(nativeHandler);
        }

        private IRunLoop* QueryRunLoop()
        {
            // _frame is itself an FUnknown-derived pointer - queryInterface on
            // it for IRunLoop, exactly like the C++ Steinberg::U::cast<IRunLoop>(plugFrame) pattern.
            void* result;
            var iid = IRunLoop.IId;
            var hr = ((FUnknown*)_frame)->queryInterface(&iid, &result);
            return hr == ComResult.Ok ? (IRunLoop*)result : null;
        }
    }
}
