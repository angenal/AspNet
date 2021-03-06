using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Util.Collections;

namespace System.Util.SQLBuilder.Statement
{
    /// <summary>
    /// Create Table
    /// </summary>
    public class CreateTable : SQLStatement
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName
        {
            get;
            set;
        }
        SafeStringToStringDictionary data;
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Util.SQLBuilder.Statement.CreateTable"/> class
        /// </summary>
        /// <param name="TableName"></param>
        public CreateTable(string TableName) : this(TableName, new SafeStringToStringDictionary())
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Util.SQLBuilder.Statement.CreateTable"/> class
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="data"></param>
        public CreateTable(string TableName, SafeStringToStringDictionary data)
        {
            this.TableName = TableName;
            this.data = data;
        }

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($@"CREATE TABLE {TableName}");
            sb.AppendLine();
            sb.Append(@"(");
            sb.AppendLine();
            foreach (var x in data)
            {
                sb.AppendLine($@"[{x.Key}] {x.Value},");
            }
            sb.Remove(sb.Length - 3, 1);
            sb.Append(")");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
