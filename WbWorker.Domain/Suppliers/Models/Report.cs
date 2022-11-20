using System.Text.Json.Serialization;

namespace WbWorker.Domain.Suppliers.Models;

public class Report
{
    [JsonPropertyName("realizationreport_id")]
    public long RealizationreportId { get; set; }

    [JsonPropertyName("date_from")]
    public DateTime? DateFrom { get; set; }

    [JsonPropertyName("date_to")]
    public DateTime? DateTo { get; set; }

    [JsonPropertyName("create_dt")]
    public DateTime? CreateDt { get; set; }

    [JsonPropertyName("suppliercontract_code")]
    public string? SuppliercontractCode { get; set; }

    [JsonPropertyName("rrd_id")]
    public long RrdId { get; set; }

    [JsonPropertyName("gi_id")]
    public long GiId { get; set; }

    [JsonPropertyName("subject_name")]
    public string? SubjectName { get; set; }

    [JsonPropertyName("nm_id")]
    public long NmId { get; set; }

    [JsonPropertyName("brand_name")]
    public string? BrandName { get; set; }

    [JsonPropertyName("sa_name")]
    public string? SaName { get; set; }

    [JsonPropertyName("ts_name")]
    public string? TsName { get; set; }

    [JsonPropertyName("barcode")]
    public string? Barcode { get; set; }

    [JsonPropertyName("doc_type_name")]
    public string? DocTypeName { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("retail_price")]
    public double RetailPrice { get; set; }

    [JsonPropertyName("retail_amount")]
    public double RetailAmount { get; set; }

    [JsonPropertyName("sale_percent")]
    public double SalePercent { get; set; }

    [JsonPropertyName("commission_percent")]
    public double? CommissionPercent { get; set; }

    [JsonPropertyName("office_name")]
    public string? OfficeName { get; set; }

    [JsonPropertyName("supplier_oper_name")]
    public string? SupplierOperName { get; set; }

    [JsonPropertyName("order_dt")]
    public DateTime? OrderDt { get; set; }

    [JsonPropertyName("sale_dt")]
    public DateTime? SaleDt { get; set; }

    [JsonPropertyName("rr_dt")]
    public DateTime? RrDt { get; set; }

    [JsonPropertyName("shk_id")]
    public long ShkId { get; set; }

    [JsonPropertyName("retail_price_withdisc_rub")]
    public double? RetailPriceWithdiscRub { get; set; }

    [JsonPropertyName("delivery_amount")]
    public double DeliveryAmount { get; set; }

    [JsonPropertyName("return_amount")]
    public double ReturnAmount { get; set; }

    [JsonPropertyName("delivery_rub")]
    public double DeliveryRub { get; set; }

    [JsonPropertyName("gi_box_type_name")]
    public string? GiBoxTypeName { get; set; }

    [JsonPropertyName("product_discount_for_report")]
    public double? ProductDiscountForReport { get; set; }

    [JsonPropertyName("supplier_promo")]
    public double SupplierPromo { get; set; }

    [JsonPropertyName("rid")]
    public long? Rid { get; set; }

    [JsonPropertyName("ppvz_spp_prc")]
    public double? PpvzSppPrc { get; set; }

    [JsonPropertyName("ppvz_kvw_prc_base")]
    public double? PpvzKvwPrcBase { get; set; }

    [JsonPropertyName("ppvz_kvw_prc")]
    public double? PpvzKvwPrc { get; set; }

    [JsonPropertyName("ppvz_sales_commission")]
    public double? PpvzSalesCommission { get; set; }

    [JsonPropertyName("ppvz_for_pay")]
    public double? PpvzForPay { get; set; }

    [JsonPropertyName("ppvz_reward")]
    public double PpvzReward { get; set; }

    [JsonPropertyName("acquiring_fee")]
    public double? AcquiringFee { get; set; }

    [JsonPropertyName("acquiring_bank")]
    public string? AcquiringBank { get; set; }

    [JsonPropertyName("ppvz_vw")]
    public double? PpvzVw { get; set; }

    [JsonPropertyName("ppvz_vw_nds")]
    public double? PpvzVwNds { get; set; }

    [JsonPropertyName("ppvz_office_id")]
    public int PpvzOfficeId { get; set; }

    [JsonPropertyName("ppvz_office_name")]
    public string? PpvzOfficeName { get; set; }

    [JsonPropertyName("ppvz_supplier_id")]
    public int PpvzSupplierId { get; set; }

    [JsonPropertyName("ppvz_supplier_name")]
    public string? PpvzSupplierName { get; set; }

    [JsonPropertyName("ppvz_inn")]
    public string? PpvzInn { get; set; }

    [JsonPropertyName("declaration_number")]
    public string? DeclarationNumber { get; set; }

    [JsonPropertyName("bonus_type_name")]
    public string? BonusTypeName { get; set; }

    [JsonPropertyName("sticker_id")]
    public string? StickerId { get; set; }

    [JsonPropertyName("site_country")]
    public string? SiteCountry { get; set; }

    [JsonPropertyName("penalty")]
    public double? Penalty { get; set; }

    [JsonPropertyName("additional_payment")]
    public double AdditionalPayment { get; set; }

    [JsonPropertyName("srid")]
    public string? Srid { get; set; }
}