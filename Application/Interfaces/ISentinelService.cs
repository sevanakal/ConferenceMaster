namespace ConferenceMaster.Application.Interfaces;

public interface ISentinelService
{
    //Bir işlem yapılmadan önce sistemin müsait olup olmadığı
    bool IsSystemHealthy();

    //Eğer sistem yoğunsa hata fırlat
    void ValidateSystemLoad();

}