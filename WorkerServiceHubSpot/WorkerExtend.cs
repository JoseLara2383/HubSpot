using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceHubSpot
{
    internal class WorkerExtend:BackgroundService
    {
        private readonly ILogger<WorkerExtend> _logger;
        private Boolean IsRunning = false; 

        public WorkerExtend(ILogger<WorkerExtend> logger)
        {
            _logger = logger;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Start: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Stop: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (!IsRunning)
                {
                    IsRunning = true;

                    var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

                    var roundTheCodeSync = config.GetSection("Sync").Get<SyncModel>();

                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    var a = await HubSpotDAL.HubSpotProcess.GetContact();
                    _logger.LogInformation("Result: {a}", a);
                    IsRunning = false;
                    await Task.Delay(roundTheCodeSync.Interval, stoppingToken);
                }
                else
                {
                    _logger.LogInformation("is running {time}", DateTimeOffset.Now);
                }
            }
        }

        public override void Dispose()
        {

        }

    }
}
