using System.Collections.Generic;

namespace System.Util.Collections
{
    /// <summary>
    /// Safe string to string directionary
    /// </summary>
    public class SafeStringToStringDictionary : SafeDictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Util.Collections.SafeStringToStringDictionary"/> class.
        /// </summary>
        public SafeStringToStringDictionary() : base() => Static.DoNothing();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Util.Collections.SafeStringToStringDirectionary"/> class.
        /// </summary>
        /// <param name="src">Source</param>
        public SafeStringToStringDictionary(Dictionary<string, string> src) : base(src) => Static.DoNothing();

        /// <summary>
        /// NullValue
        /// </summary>
        public sealed override string NullValue => string.Empty;
    }
}
