// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using NPlug.Helpers;

namespace NPlug.Tests;

public class TestAudioHelper
{
    private const float Threshold = 0.001f;

    [Test]
    public void SilentBufferIsSilent()
    {
        foreach (var length in new[] { 0, 1, 3, 4, 7, 8, 9, 17, 512 })
        {
            Assert.IsTrue(AudioHelper.CheckIsSilent(new float[length], Threshold), $"length {length}");
        }
    }

    [Test]
    public void LoudSampleAnywhereIsHeard()
    {
        // Every position, both signs, and lengths that leave a tail after the vectors.
        foreach (var length in new[] { 1, 3, 4, 7, 8, 9, 17, 515 })
        {
            for (var position = 0; position < length; position++)
            {
                foreach (var value in new[] { 0.5f, -0.5f })
                {
                    var buffer = new float[length];
                    buffer[position] = value;
                    Assert.IsFalse(AudioHelper.CheckIsSilent(buffer, Threshold), $"length {length}, {value} at {position}");
                }
            }
        }
    }

    [Test]
    public void SamplesUnderTheThresholdAreSilent()
    {
        var buffer = new double[515];
        for (var index = 0; index < buffer.Length; index++) buffer[index] = index % 2 == 0 ? 0.0005 : -0.0005;
        Assert.IsTrue(AudioHelper.CheckIsSilent(buffer, 0.001));
    }
}
