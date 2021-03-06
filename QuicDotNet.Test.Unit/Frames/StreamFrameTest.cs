﻿namespace QuicDotNet.Test.Unit.Frames
{
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using QuicDotNet.Frames;
    using QuicDotNet.Messages;

    [TestClass]
    public class StreamFrameTest
    {
        [TestMethod]
        public void Stream1ClientInchoateGoogleCachedServerParametersClientMessage()
        {
            var tags = Messages.ClientHandshakeMessageTest.ClientInchoateGoogleCachedServerParametersClientMessageFactory.Value;
            var message2 = new ClientHandshakeMessage(tags);
            var messageBytes2 = message2.ToByteArray();

            var stream = new StreamFrame(1, 0);
            stream.SetData(messageBytes2, false);

            var streamBytes = stream.ToByteArray();
            Assert.IsNotNull(streamBytes);
            Debug.WriteLine(streamBytes.GenerateHexDumpWithASCII());

            //Assert.AreEqual(streamBytes.Length, FrameLibrary.ClientInchoateGoogleCachedServerParametersStream1Subset.Length);

            // Soft warn
            for (var i = 0; i < streamBytes.Length; i++)
            {
                if (streamBytes[i] != FrameLibrary.ClientInchoateGoogleCachedServerParametersStream1Subset[i])
                    Debug.WriteLine($"Byte difference at position {i}: generated byte is {streamBytes[i]:x2} but reference byte was {FrameLibrary.ClientInchoateGoogleCachedServerParametersStream1Subset[i]:x2}");
            }

            // Hard test fail
            for (var i = 0; i < streamBytes.Length; i++)
            {
                Assert.AreEqual(streamBytes[i], FrameLibrary.ClientInchoateGoogleCachedServerParametersStream1Subset[i], $"Byte difference at position {i}: generated byte is {streamBytes[i]:x2} but reference byte was {FrameLibrary.ClientInchoateGoogleCachedServerParametersStream1Subset[i]:x2}");
            }
        }
    }
}
