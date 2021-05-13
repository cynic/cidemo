// This file is copyright by ME
using NUnit.Framework;
using System.IO;
using cidemo;

namespace testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenTextIsWrittenItAppearsInTheFile()
        {
            // ARRANGE
            Prepender p = new Prepender("hello, how are you?");
            File.Delete("moo.txt");
            // ACT
            p.Prepend("moo.txt");
            // ASSERT
            Assert.AreEqual("hello, how are you?\r\n", File.ReadAllText("moo.txt"), "The value should be prepended to the file");
        }
        [Test]
        public void WhenTextIsWrittenTwiceItIsPrepended()
        {
            // ARRANGE
            Prepender p = new Prepender("hello, how are you?");
            Prepender q = new Prepender("Hi there!");
            File.Delete("moo.txt");
            // ACT
            p.Prepend("moo.txt");
            q.Prepend("Moo.txt");
            // ASSERT
            Assert.AreEqual("Hi there!\r\nhello, how are you?\r\n", File.ReadAllText("moo.txt"), "Two values should be prepended");
        }
    }
}
