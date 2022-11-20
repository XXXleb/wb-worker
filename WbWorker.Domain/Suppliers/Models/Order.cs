using System.Text.Json.Serialization;

namespace WbWorker.Domain.Suppliers.Models;

public class Order
{
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("lastChangeDate")]
    public DateTime? LastChangeDate { get; set; }

    [JsonPropertyName("supplierArticle")]
    public string? SupplierArticle { get; set; }

    [JsonPropertyName("techSize")]
    public string? TechSize { get; set; }

    [JsonPropertyName("barcode")]
    public string? Barcode { get; set; }

    [JsonPropertyName("totalPrice")]
    public double? TotalPrice { get; set; }

    [JsonPropertyName("discountPercent")]
    public double DiscountPercent { get; set; }

    [JsonPropertyName("warehouseName")]
    public string? WarehouseName { get; set; }

    [JsonPropertyName("oblast")]
    public string? Oblast { get; set; }

    [JsonPropertyName("incomeID")]
    public long IncomeId { get; set; }

    [JsonPropertyName("odid")]
    public long OdId { get; set; }

    [JsonPropertyName("nmId")]
    public long NmId { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    [JsonPropertyName("isCancel")]
    public bool? IsCancel { get; set; }

    [JsonPropertyName("cancel_dt")]
    public DateTime? CancelDt { get; set; }

    [JsonPropertyName("gNumber")]
    public string? GNumber { get; set; }

    [JsonPropertyName("sticker")]
    public string? Sticker { get; set; }
}