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

        [TestMethod]
        public void ShallowCopy()
        {
            dynamic original = new ExpandoObject();
            original.Prop1 = 1;

            original.Expando = new ExpandoObject();
            original.Expando.Prop2 = 2;

            original.Expando.Expando = new ExpandoObject();
            original.Expando.Expando.Prop3 = 3;

            dynamic copy = ((ExpandoObject)original).ShallowCopy();

            Assert.AreEqual(original.Prop1, copy.Prop1);
            Assert.AreEqual(original.Expando.Prop2, copy.Expando.Prop2);
            Assert.AreEqual(original.Expando.Expando.Prop3, copy.Expando.Expando.Prop3);

            Assert.IsFalse(Object.ReferenceEquals(original, copy));
            Assert.IsTrue(Object.ReferenceEquals(original.Expando, copy.Expando));
            Assert.IsTrue(Object.ReferenceEquals(original.Expando.Expando, copy.Expando.Expando));
        }

        [TestMethod]
        public void DeepCopy()
        {
            dynamic original = new ExpandoObject();
            original.Prop1 = 1;

            original.Expando = new ExpandoObject();
            original.Expando.Prop2 = 2;

            original.Expando.Expando = new ExpandoObject();
            original.Expando.Expando.Prop3 = 3;

            dynamic copy = ((ExpandoObject)original).DeepCopy();

            Assert.AreEqual(original.Prop1, copy.Prop1);
            Assert.AreEqual(original.Expando.Prop2, copy.Expando.Prop2);
            Assert.AreEqual(original.Expando.Expando.Prop3, copy.Expando.Expando.Prop3);

            Assert.IsFalse(Object.ReferenceEquals(original, copy));
            Assert.IsFalse(Object.ReferenceEquals(original.Expando, copy.Expando));
            Assert.IsFalse(Object.ReferenceEquals(original.Expando.Expando, copy.Expando.Expando));
        }
    }
}
