using System.Text.Json.Serialization;

namespace WbWorker.Domain.Suppliers.Models;

public class Supply
{
    [JsonPropertyName("incomeId")]
    public long? IncomeId { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

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

    [JsonPropertyName("totalPrice")]
    public double TotalPrice { get; set; }

    [JsonPropertyName("dateClose")]
    public DateTime? DateClose { get; set; }

    [JsonPropertyName("warehouseName")]
    public string? WarehouseName { get; set; }

    [JsonPropertyName("nmId")]
    public long NmId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}