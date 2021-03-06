using HtmlAgilityPack;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using NATS.Client;
using System;
using System.Xml;

namespace natsql.V8Script
{
    /// <summary>
    /// V8 JavaScript Runtime.
    /// https://microsoft.github.io/ClearScript/Examples/Examples.html
    /// https://microsoft.github.io/ClearScript/Tutorial/FAQtorial.html
    /// </summary>
    public sealed class JS
    {
        /// <summary>
        /// Identity.
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// Represents an instance of the V8 JavaScript engine.
        /// </summary>
        public readonly V8ScriptEngine Engine;

        /// <summary>
        /// Compiled script.
        /// </summary>
        public readonly Microsoft.ClearScript.V8.V8Script Script;

        public readonly DatabaseObject Database;
        public readonly NatsObject NatsObject;
        public readonly CacheObject CacheObject;
        public readonly RedisObject RedisObject;

        /// <summary>
        /// V8 JavaScript Runtime.
        /// </summary>
        /// <param name="script"></param>
        /// <param name="extensions"></param>
        /// <param name="executing"></param>
        /// <param name="enableDebugging"></param>
        public JS(string script, DbConfig dbConfig, RedisConfig redisConfig, IConnection connection, string prefix, string subject, bool extensions = true, bool executing = true, bool enableDebugging = false)
        {
            Id = script.Crc32();

            //var constraints = new V8RuntimeConstraints
            //{
            //    MaxNewSpaceSize = 16,
            //    MaxOldSpaceSize = 16,
            //};
            Engine = enableDebugging ? new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging) : new V8ScriptEngine();

            if (extensions)
            {
                Engine.AddHostType(typeof(DateTime));
                Engine.AddHostType(typeof(TimeSpan));
                Engine.AddHostType(typeof(XmlDocument));
                Engine.AddHostType(typeof(HtmlDocument));
                Engine.AddHostType(typeof(HtmlWeb));
                Engine.AddHostType(typeof(HtmlNode));
                Engine.AddHostType(typeof(HtmlNodeCollection));
                Engine.AddHostType(typeof(ScriptExtensions));
                //Engine.AddHostObject("host", new HostFunctions());
                //engine.AddHostObject("type", new HostTypeCollection("mscorlib", "System", "System.Core"));
                Engine.AddHostType("console", typeof(ConsoleFunctions));
                Engine.AddHostObject("$", new AjaxFunctions(Engine));
                Engine.AddHostObject("$db", Database = new DatabaseObject(dbConfig, Engine, prefix, subject));
                Engine.AddHostObject("$nats", NatsObject = new NatsObject(connection, prefix, subject));
                Engine.AddHostObject("$cache", CacheObject = new CacheObject(redisConfig, Engine, prefix, subject));
                Engine.AddHostObject("$redis", RedisObject = new RedisObject(redisConfig, Engine, prefix, subject));
                Engine.AddHostExtensions();
            }

            // Creates a compiled script.
            Script = Engine.Compile(script);
            if (executing) Engine.Execute(Script);
        }

        public void Add<T>() => Engine.AddHostType(typeof(T));
        public void Add<T>(string itemName) => Engine.AddHostType(itemName, typeof(T));
        public void Add(string itemName, object target) => Engine.AddHostObject(itemName, target);
        public void Execute(string script) => Engine.Execute(script);
        public object Eval(string code) => Engine.Evaluate(SecurityCode(code));
        public object Invoke(string funcName, params object[] args) => Engine.Invoke(funcName, args);
        public object Invoke(string funcName, string codeEvalToArgs) => Engine.Invoke(funcName, Eval(codeEvalToArgs));
        public static string SecurityCode(string code) => code != null && code.StartsWith("{") ? $"_{new Random().Next(100, 9999)}=" + code : code;
    }
}
