using WorkerServiceHubSpot;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<WorkerExtend>();
       
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();
