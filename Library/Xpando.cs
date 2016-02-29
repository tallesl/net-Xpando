namespace XpandoLibrary
{
    using DictionaryLibrary;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Dynamic;

    /// <summary>
    /// Provides a ToExpando extension method.
    /// </summary>
    public static class Xpando
    {
        /// <summary>
        /// Makes a ExpandoObject out of the given object.
        /// </summary>
        /// <param name="value">Object to become ExpandoObject</param>
        /// <returns>The ExpandoObject made</returns>
        public static ExpandoObject ToExpando(this object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var expando = value as ExpandoObject;

            if (expando == null)
            {
                expando = new ExpandoObject();
                var dict = (IDictionary<string, object>)expando;

                foreach (var kvp in DictionaryMaker.Make(value))
                    dict.Add(kvp);
            }

            return expando;
        }

        /// <summary>
        /// Removes the property of the given ExpandoObject.
        /// </summary>
        /// <param name="expando">Object to remove property from</param>
        /// <param name="propertyName">Property name to be removed</param>
        public static void RemoveProperty(this ExpandoObject expando, string propertyName)
        {
            if (expando == null)
                throw new ArgumentNullException("expando");

            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            ((IDictionary<string, object>)expando).Remove(propertyName);
        }
    }
}
