using ConferenceMaster.Application.Interfaces;

namespace ConferenceMaster.Infrastructure.Sentinel;

public class SentinelService : ISentinelService
{
    public bool IsSystemHealthy()
    {
        // Şimdilik sistemin her zaman sağlıklı olduğunu varsayalım
        return true;
    }

    public void ValidateSystemLoad()
    {
        if (!IsSystemHealthy())
        {
            throw new Exception("Sentinel: Sistem yorgun, işlem yapılamaz!");
        }
    }
}