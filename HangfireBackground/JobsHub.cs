using Hangfire;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HangfireBackground
{
    public class JobsHub : BackgroundService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IPrinterJob _printerJob;

        public JobsHub(IRecurringJobManager recurringJobManager, IBackgroundJobClient backgroundJobClient, IPrinterJob printerJob)
        {
            _recurringJobManager = recurringJobManager;
            _backgroundJobClient = backgroundJobClient;
            _printerJob = printerJob;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _backgroundJobClient.Enqueue(() => Console.WriteLine("Hello, Hangfire!"));

            await Task.Run(() => _recurringJobManager.AddOrUpdate("Run every minute", () => _printerJob.Print(), Cron.Minutely));
        }
    }
}
