using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Util.Reflection;



namespace System.Util.CsBuilder
{
    /// <summary>
    /// Auto Property
    /// </summary>
    public class AutoProperty : ClassMember
    {
        /// <summary>
        /// VIsibility
        /// </summary>
        public Visibility Visibility
        {
            get;
            set;
        } = Visibility.None;
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            set;
        } = "AutoPropertyName";
        /// <summary>
        /// Return Type
        /// </summary>
        public Type ReturnType
        {
            get;
            set;
        } = typeof(void);



        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString(0);
        /// <summary>
        /// Convert To String
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i * 4);
            sb.AppendLine($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} {ReturnType.GetTypeName()} {Name}");
            sb.Append(NULL, i * 4);
            sb.AppendLine("{");
            sb.Append(NULL, (i + 1) * 4);
            sb.AppendLine("get;");
            sb.Append(NULL, (i + 1) * 4);
            sb.AppendLine("set;");
            sb.Append(NULL, i * 4);
            sb.AppendLine("}");


            return sb.ToString();
        }
    }
}
