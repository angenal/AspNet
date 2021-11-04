namespace natsql
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || !CommandLine.Parser.TryParse(args, out Flags flags))
            {
                Flags.Usage();
                return;
            }

            if (string.IsNullOrEmpty(flags.Config))
            {
                Flags.Usage();
                return;
            }

            if (!string.IsNullOrEmpty(flags.Test))
            {
                Test.Run(flags);
                return;
            }

            Subscribes.Run(flags);
        }
    }
}
