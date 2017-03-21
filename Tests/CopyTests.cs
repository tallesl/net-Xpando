namespace XpandoLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Dynamic;

    [TestClass]
    public class CopyTests
    {
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
