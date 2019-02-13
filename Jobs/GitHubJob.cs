using Andoromeda.Framework.GitHub;
using Andoromeda.Framework.Logger;
using Microsoft.Extensions.Configuration;
using Pomelo.AspNetCore.TimedJob;
using System;
using System.IO;

namespace Andoromeda.Kyubey.Incubator.Jobs
{
    public class GitHubJob : Job
    {
        [Invoke(Begin = "2018-11-01 0:00", Interval = 1000 * 60 * 10, SkipWhileExecuting = true)]
        public void SyncTokensRepository(IConfiguration config, ILogger logger)
        {
            try
            {
                GitHubSynchronizer.CreateOrUpdateRepositoryAsync(
                "kyubey-network", "token-list", "master",
                Path.Combine(config["RepositoryStore"], "token-list")).Wait();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }
        }
    }
}
