using System.Text.Json.Serialization;

namespace WbWorker.Domain.Suppliers.Models;

public class Excise
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("finishedPrice")]
    public decimal FinishedPrice { get; set; }

    [JsonPropertyName("operationTypeId")]
    public int OperationTypeId { get; set; }

    [JsonPropertyName("fiscalDt")]
    public DateTime? FiscalDt { get; set; }

    [JsonPropertyName("docNumber")]
    public int DocNumber { get; set; }

    [JsonPropertyName("fnNumber")]
    public string? FnNumber { get; set; }

    [JsonPropertyName("regNumber")]
    public string? RegNumber { get; set; }

    [JsonPropertyName("excise")]
    public string? ExciseCode { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }
}