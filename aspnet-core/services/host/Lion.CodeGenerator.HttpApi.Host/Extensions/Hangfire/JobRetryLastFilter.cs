using Hangfire.Common;
using Hangfire.States;
using Serilog;

namespace Lion.CodeGenerator.Extensions.Hangfire;

/// <summary>
/// 重试最后一次
/// </summary>
public class JobRetryLastFilter : JobFilterAttribute, IElectStateFilter
{
    private int RetryCount { get; }

    public JobRetryLastFilter(int retryCount)
    {
        RetryCount = retryCount;
    }


    public void OnStateElection(ElectStateContext context)
    {
        int retryAttempt = context.GetJobParameter<int>("RetryCount");
        if (RetryCount == retryAttempt)
        {
            Log.Error("最后一次重试");
        }
    }
}