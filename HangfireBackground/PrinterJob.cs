using System.Threading.Tasks;

namespace HangfireBackground
{
    public class PrinterJob : IPrinterJob
    {
        public void Print()
        {
            System.Console.WriteLine("Hangfire recurring job!");
        }
    }
}
