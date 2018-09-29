using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dexiom.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Dexiom.StringExtensions.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        private const string LazyFox = "The quick brown fox jumps over the lazy dog";

        [TestMethod()]
        public void ToWordsTest()
        {
            const string fromValue = "TheGSTReportIsCompleted";
            const string toValue = "The GST Report Is Completed";

            Assert.IsTrue(fromValue.ToWords() == toValue);
        }

        [TestMethod()]
        public void RightTest()
        {
            const string text = "The quick brown fox jumps over the lazy dog";

            Assert.IsTrue(text.Right(3) == "dog");
            Assert.IsTrue(text.Right(int.MaxValue) == text);
        }

        [TestMethod()]
        public void LeftTest()
        {
            const string text = "The quick brown fox jumps over the lazy dog";
            Assert.IsTrue(text.Left(3) == "The");
            Assert.IsTrue(text.Left(int.MaxValue) == text);
        }

        [TestMethod()]
        public void MidTest()
        {
            const string text = "0123456789";

            Assert.IsTrue(text.Mid(4, 2) == "45");
            Assert.IsTrue(text.Mid(7) == "789");
            Assert.IsTrue(text.Mid(int.MaxValue) == string.Empty);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            const string text = "JonathanParé";

            Assert.IsTrue(text.Contains("Nathan", StringComparison.OrdinalIgnoreCase));
            Assert.IsFalse(text.Contains("paré", StringComparison.Ordinal));
            Assert.IsTrue(text.Contains("Paré", StringComparison.Ordinal));
        }

        [TestMethod()]
        public void ShortenTest()
        {
            Assert.IsTrue(LazyFox.Shorten(6) == "The...");
            Assert.IsTrue(LazyFox.Shorten(LazyFox.Length) == LazyFox);
        }
    }
}