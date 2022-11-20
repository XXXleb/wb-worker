using System.Text.Json.Serialization;

namespace WbWorker.Domain.Suppliers.Models;

public class Stock
{
    [JsonPropertyName("lastChangeDate")]
    public DateTime LastChangeDate { get; set; }

    [JsonPropertyName("supplierArticle")]
    public string? SupplierArticle { get; set; }

    [JsonPropertyName("techSize")]
    public string? TechSize { get; set; }

    [JsonPropertyName("barcode")]
    public string? Barcode { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("isSupply")]
    public bool IsSupply { get; set; }

    [JsonPropertyName("isRealization")]
    public bool IsRealization { get; set; }

    [JsonPropertyName("quantityFull")]
    public int QuantityFull { get; set; }

    [JsonPropertyName("quantityNotInOrders")]
    public int QuantityNotInOrders { get; set; }

    [JsonPropertyName("warehouse")]
    public int Warehouse { get; set; }

    [JsonPropertyName("warehouseName")]
    public string? WarehouseName { get; set; }

    [JsonPropertyName("inWayToClient")]
    public int InWayToClient { get; set; }

    [JsonPropertyName("inWayFromClient")]
    public int InWayFromClient { get; set; }

    [JsonPropertyName("nmId")]
    public long NmId { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("daysOnSite")]
    public int DaysOnSite { get; set; }

    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    [JsonPropertyName("SCCode")]
    public string? SCCode { get; set; }

    [JsonPropertyName("Price")]
    public double Price { get; set; }

    [JsonPropertyName("Discount")]
    public double Discount { get; set; }
}
