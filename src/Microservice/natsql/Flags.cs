using CommandLine.Attributes;
using System;

namespace natsql
{
    /// <summary>
    /// 命令行参数解析
    /// </summary>
    public class Flags
    {
        [OptionalArgument("natsql.yaml", "c", "sets config file")]
        public string Config { get; set; }

        [OptionalArgument("", "t", "sets json file and run SQL test")]
        public string Test { get; set; }

        [OptionalArgument(0, "i", "sets auto create subscribes interval seconds")]
        public int CreateInterval { get; set; }

        [OptionalArgument("", "a", "the NatS-Server address")]
        public string Addr { get; set; }

        [OptionalArgument("", "name", "the NatS-Subscription name prefix")]
        public string Name { get; set; }

        [OptionalArgument("", "token", "the NatS-Token auth string [required]")]
        public string Token { get; set; }

        [OptionalArgument("", "cred", "the NatS-Cred file")]
        public string Cred { get; set; }

        [OptionalArgument("", "cert", "the NatS-TLS cert file")]
        public string Cert { get; set; }

        [OptionalArgument("", "key", "the NatS-TLS key file")]
        public string Key { get; set; }

        public static void Usage()
        {
            Console.WriteLine(@" Usage of natsql:
  -c string
        sets config file (default ""natsql.yaml"")
  -t string
        sets json file and run SQL test
  -i int
        sets auto create subscribes interval seconds
  -a string
        the NatS-Server address
  -name string
        the NatS - Subscription name prefix
  -token string
        the NatS - Token auth string
  -cred string
        the NatS - Cred file
  -cert string
        the NatS - TLS cert file
  -key string
        the NatS - TLS key file");
        }
    }
}
