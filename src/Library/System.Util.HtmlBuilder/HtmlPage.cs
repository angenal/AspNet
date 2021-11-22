using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Util.HtmlBuilder.Body;
using System.Util.HtmlBuilder.Header;

namespace System.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlPage
    /// </summary>
    public class HtmlPage : HtmlNode
    {
        /// <summary>
        /// Version
        /// </summary>
#if NETSTANDARD
        public static readonly string Version = $"HtmlBuilder/{typeof(HtmlPage).GetTypeInfo().Assembly.GetName().Version})";
#else
        public static readonly string Version = $"HtmlBuilder/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version})";
#endif
        /// <summary>
        /// HtmlPage
        /// </summary>
        public HtmlPage()
        {
            Children.Add(Head);
            Children.Add((HtmlNode)this.Body);
        }
        /// <summary>
        /// head
        /// </summary>
        public Head Head
        {
            get;
            set;
        } = new Head();
        /// <summary>
        /// body
        /// </summary>
        public Body.Body Body
        {
            get;
            set;
        } = new Body.Body();
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            if (i != 0)
            {
                throw new Exception("HtmlPage Must Be The Root Node");
            }
            else
            {
                return
$@"<!DOCTYPE html>
<html{Params.ToString()}>
<!--The Page Is Built By {Version}.-->{GetContent(0)}
</html>
";
            }
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="node"></param>
        public override void Add(HtmlNode node)
        {
            if (node is Head)
            {
                this.Children.Remove(this.Head);
                this.Head = node as Head;
                this.Children.Add(this.Head);
            }
            else if (node is Body.Body)
            {
                this.Children.Remove((HtmlNode)this.Body);
                this.Body = node as Body.Body;
                this.Children.Add((HtmlNode)this.Body);
            }
            else
            {
                base.Add(node);
            }

        }
    }
}
