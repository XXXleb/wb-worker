namespace WbWorker.Domain.Settings.Models;

public class ApiSetting
{
    public byte MarketplaceId { get; set; }
    public string ApiKey { get; set; }
    public ApiType[] ApiTypes { get; set; }
}
