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
            var count = ((IDictionary<string, object>)expando).Count;

            Assert.IsTrue(expando is ExpandoObject);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Anonymous()
        {
            dynamic expando = new { Foo = "Bar" }.ToExpando();
            expando.X = "Y";

            var count = ((IDictionary<string, object>)expando).Count;

            Assert.IsTrue(expando is ExpandoObject);
            Assert.AreEqual(2, count);
            Assert.AreEqual("Bar", expando.Foo);
            Assert.AreEqual("Y", expando.X);
        }

        [TestMethod]
        public void Dictionary()
        {
            dynamic expando = new Dictionary<string, object> { { "Foo", "Bar" } }.ToExpando();
            expando.X = "Y";

            var count = ((IDictionary<string, object>)expando).Count;

            Assert.IsTrue(expando is ExpandoObject);
            Assert.AreEqual(2, count);
            Assert.AreEqual("Bar", expando.Foo);
            Assert.AreEqual("Y", expando.X);
        }
    }
}
