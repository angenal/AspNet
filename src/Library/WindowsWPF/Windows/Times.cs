namespace System.Windows
{
    public static class Times
    {
        public static void Delay(int milliseconds)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(milliseconds) > DateTime.Now)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            return;
        }
    }
}
