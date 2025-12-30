namespace ProjectCenturion.WorkerFunctions.Workers.Consumers;

public class TestConsumer(ILogger<TestConsumer> logger) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}