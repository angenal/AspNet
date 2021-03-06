using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlNodeWithoutNewLine
    /// </summary>
    public class HtmlNodeWithoutNewLine : HtmlNode
    {
        internal override bool IsWithoutNewLine
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append($@"<{Name}{Params.ToString()}>");
            sb.Append(GetContent(i));
            sb.Append($@"</{Name}>");
            return sb.ToString();
        }
    }
}
