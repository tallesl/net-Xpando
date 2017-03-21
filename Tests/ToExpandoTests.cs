namespace XpandoLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    [TestClass]
    public class ToExpandoTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullObject()
        {
            ((object)null).ToExpando();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullExpando()
        {
            Xpando.RemoveProperty(null, "foo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullPropertyName()
        {
            new ExpandoObject().RemoveProperty(null);
        }

        [TestMethod]
        public void Empty()
        {
            var expando = new { }.ToExpando();
            var dict = (IDictionary<string, object>)expando;

            Assert.IsTrue(expando is ExpandoObject);
            Assert.AreEqual(0, dict.Count);
        }

        [TestMethod]
        public void Anonymous()
        {
            dynamic expando = new { Foo = "Bar" }.ToExpando();
            expando.X = "Y";

            var dict = (IDictionary<string, object>)expando;

            Assert.IsTrue(expando is ExpandoObject);
            Assert.AreEqual(2, dict.Count);
            Assert.AreEqual("Bar", dict["Foo"]);
            Assert.AreEqual("Y", dict["X"]);
        }
    }
}
