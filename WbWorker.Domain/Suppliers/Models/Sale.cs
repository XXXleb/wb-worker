using System.Text.Json.Serialization;

namespace WbWorker.Domain.Suppliers.Models;

public class Sale
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
    public double TotalPrice { get; set; }

    [JsonPropertyName("discountPercent")]
    public double DiscountPercent { get; set; }

    [JsonPropertyName("isSupply")]
    public bool? IsSupply { get; set; }

    [JsonPropertyName("isRealization")]
    public bool? IsRealization { get; set; }

    [JsonPropertyName("promoCodeDiscount")]
    public double PromoCodeDiscount { get; set; }

    [JsonPropertyName("warehouseName")]
    public string? WarehouseName { get; set; }

    [JsonPropertyName("countryName")]
    public string? CountryName { get; set; }

    [JsonPropertyName("oblastOkrugName")]
    public string? OblastOkrugName { get; set; }

    [JsonPropertyName("regionName")]
    public string? RegionName { get; set; }

    [JsonPropertyName("incomeID")]
    public long? IncomeId { get; set; }

    [JsonPropertyName("saleID")]
    public string? SaleId { get; set; }

    [JsonPropertyName("odid")]
    public long OdId { get; set; }

    [JsonPropertyName("spp")]
    public double Spp { get; set; }

    [JsonPropertyName("forPay")]
    public double ForPay { get; set; }

    [JsonPropertyName("finishedPrice")]
    public double FinishedPrice { get; set; }

    [JsonPropertyName("priceWithDisc")]
    public double PriceWithDisc { get; set; }

    [JsonPropertyName("nmId")]
    public long NmId { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    [JsonPropertyName("IsStorno")]
    public int IsStorno { get; set; }

    [JsonPropertyName("gNumber")]
    public string? GNumber { get; set; }

    [JsonPropertyName("sticker")]
    public string? Sticker { get; set; }
}