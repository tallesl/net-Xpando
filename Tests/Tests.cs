namespace XpandoLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null()
        {
            ((object)null).ToExpando();
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

        [TestMethod]
        public void Remove()
        {
            ExpandoObject expando = new { Foo = "Bar", X = "Y", }.ToExpando();
            expando.RemoveProperty("Foo");

            var dict = (IDictionary<string, object>)expando;

            Assert.AreEqual(1, dict.Count);
            Assert.AreEqual("Y", dict["X"]);
        }
    }
}
