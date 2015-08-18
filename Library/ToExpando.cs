namespace ToExpando
{
    using PropertiesHash;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    public static class ToExpandoExtension
    {
        /// <summary>
        /// Makes a ExpandoObject out of the given object.
        /// </summary>
        /// <param name="obj">Object to become ExpandoObject</param>
        /// <returns>The ExpandoObject made</returns>
        public static ExpandoObject ToExpando(this object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            else if (obj is ExpandoObject) return (ExpandoObject)obj;
            else
            {
                var expando = new ExpandoObject();
                var dict = (IDictionary<string, object>)expando;
                foreach (var kvp in PropertiesHasher.Make(obj)) dict.Add(kvp);
                return expando;
            }
        }
    }
}
