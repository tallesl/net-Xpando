namespace XpandoLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Dynamic;

    [TestClass]
    public class PropertyTests
    {
        [TestMethod]
        public void RemoveProperty()
        {
            ExpandoObject expando = new { Foo = "Bar", X = "Y", }.ToExpando();
            expando.RemoveProperty("Foo");

            var dict = (IDictionary<string, object>)expando;

            Assert.AreEqual(1, dict.Count);
            Assert.AreEqual("Y", dict["X"]);
        }

        [TestMethod]
        public void HasProperty()
        {
            ExpandoObject expando = new { Foo = "Bar" }.ToExpando();

            Assert.IsTrue(expando.HasProperty("Foo"));
            Assert.IsFalse(expando.HasProperty("X"));
        }
    }
}
