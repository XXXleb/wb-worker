using System.Data;
using System.Text.Json;
using WbWorker.Domain.Suppliers.Models;

namespace WbWorker;

public static class DataWrapper
{
	public static DataTable ExciseDataGet(string json)
	{
		List<Excise> excises = JsonSerializer.Deserialize<List<Excise>>(json);

		DataTable dt = DefineExciseDataTable("ExciseCall");
		foreach (var i in excises)
		{
			var dr = dt.NewRow();

			dr["Id"] = i.Id;
			dr["FinishedPrice"] = i.FinishedPrice;
			dr["OperationTypeId"] = i.OperationTypeId;
			dr["FiscalDt"] = i.FiscalDt;
			dr["DocNumber"] = i.DocNumber;
			dr["FnNumber"] = i.FnNumber;
			dr["RegNumber"] = i.RegNumber;
			dr["Excise"] = i.ExciseCode;
			dr["Date"] = i.Date;

			dt.Rows.Add(dr);
		}

		return dt;
	}

	public static (DataTable, long) ReportDataGet(string json, int limit)
	{
		List<Report> reports = JsonSerializer.Deserialize<List<Report>>(json);
		long lastId = 0;

		if (reports.Count == limit)
		{
			lastId = reports.Max(m => m.RrdId);
		}

		DataTable dt = DefineReportDataTable("ReportLog");
		foreach (var i in reports)
		{
			var dr = dt.NewRow();

			dr["RealizationreportId"] = i.RealizationreportId;
			dr["DateFrom"] = i.DateFrom;
			dr["DateTo"] = i.DateTo;
			dr["CreateDt"] = i.CreateDt is null ? DBNull.Value : i.CreateDt;
			dr["SuppliercontractCode"] = i.SuppliercontractCode;
			dr["RrdId"] = i.RrdId;
			dr["GiId"] = i.GiId;
			dr["SubjectName"] = i.SubjectName;
			dr["NmId"] = i.NmId is null ? DBNull.Value : i.NmId;
			dr["BrandName"] = i.BrandName;
			dr["SaName"] = i.SaName;
			dr["TsName"] = i.TsName;
			dr["Barcode"] = i.Barcode;
			dr["DocTypeName"] = i.DocTypeName;
			dr["Quantity"] = i.Quantity;
			dr["RetailPrice"] = i.RetailPrice;
			dr["RetailAmount"] = i.RetailAmount;
			dr["SalePercent"] = i.SalePercent;
			dr["CommissionPercent"] = i.CommissionPercent;
			dr["OfficeName"] = i.OfficeName;
			dr["SupplierOperName"] = i.SupplierOperName;
			dr["OrderDt"] = i.OrderDt;
			dr["SaleDt"] = i.SaleDt;
			dr["RrDt"] = i.RrDt;
			dr["ShkId"] = i.ShkId;
			dr["RetailPriceWithdiscRub"] = i.RetailPriceWithdiscRub;
			dr["DeliveryAmount"] = i.DeliveryAmount;
			dr["ReturnAmount"] = i.RetailAmount;
			dr["DeliveryRub"] = i.DeliveryRub;
			dr["GiBoxTypeName"] = i.GiBoxTypeName;
			dr["ProductDiscountForReport"] = i.ProductDiscountForReport;
			dr["SupplierPromo"] = i.SupplierPromo;
			dr["RId"] = i.Rid;
			dr["PpvzSppPrc"] = i.PpvzSppPrc;
			dr["PpvzKvwPrcBase"] = i.PpvzKvwPrcBase;
			dr["PpvzKvwPrc"] = i.PpvzKvwPrc;
			dr["PpvzSalesCommission"] = i.PpvzSalesCommission;
			dr["PpvzForPay"] = i.PpvzForPay;
			dr["PpvzReward"] = i.PpvzReward;
			dr["AcquiringFee"] = i.AcquiringFee;
			dr["AcquiringBank"] = i.AcquiringBank;
			dr["PpvzVw"] = i.PpvzVw;
			dr["PpvzVwNds"] = i.PpvzVwNds;
			dr["PpvzOfficeId"] = i.PpvzOfficeId;
			dr["PpvzOfficeName"] = i.PpvzOfficeName;
			dr["PpvzSupplierId"] = i.PpvzSupplierId;
			dr["PpvzSupplierName"] = i.PpvzSupplierName;
			dr["PpvzInn"] = i.PpvzInn;
			dr["DeclarationNumber"] = i.DeclarationNumber;
			dr["BonusTypeName"] = i.BonusTypeName;
			dr["StickerId"] = i.StickerId;
			dr["SiteCountry"] = i.SiteCountry;
			dr["Penalty"] = i.Penalty;
			dr["AdditionalPayment"] = i.AdditionalPayment;
			dr["SrId"] = i.Srid;

			dt.Rows.Add(dr);
		}

		return (dt, lastId);
	}

	public static DataTable SaleDataGet(string json)
	{
		List<Sale> sales = JsonSerializer.Deserialize<List<Sale>>(json);

		DataTable dt = DefineSaleDataTable("SaleLog");
		foreach (var i in sales)
		{
			var dr = dt.NewRow();

			dr["Date"] = i.Date;
			dr["LastChangeDate"] = i.LastChangeDate;
			dr["SupplierArticle"] = i.SupplierArticle;
			dr["TechSize"] = i.TechSize;
			dr["Barcode"] = i.Barcode;
			dr["TotalPrice"] = i.TotalPrice;
			dr["DiscountPercent"] = i.DiscountPercent;
			dr["IsSupply"] = i.IsSupply;
			dr["IsRealization"] = i.IsRealization;
			dr["PromoCodeDiscount"] = i.PromoCodeDiscount;
			dr["WarehouseName"] = i.WarehouseName;
			dr["CountryName"] = i.CountryName;
			dr["OblastOkrugName"] = i.OblastOkrugName;
			dr["RegionName"] = i.RegionName;
			dr["IncomeId"] = i.IncomeId is null ? DBNull.Value : i.IncomeId;
			dr["SaleId"] = i.SaleId;
			dr["OdId"] = i.OdId;
			dr["Spp"] = i.Spp;
			dr["ForPay"] = i.ForPay;
			dr["FinishedPrice"] = i.FinishedPrice;
			dr["PriceWithDisc"] = i.PriceWithDisc;
			dr["NmId"] = i.NmId;
			dr["Subject"] = i.Subject;
			dr["Category"] = i.Category;
			dr["Brand"] = i.Brand;
			dr["IsStorno"] = i.IsStorno;
			dr["GNumber"] = i.GNumber;
			dr["Sticker"] = i.Sticker;

			dt.Rows.Add(dr);
		}

		return dt;
	}

	public static DataTable OrderDataGet(string json)
	{
		List<Order> orders = JsonSerializer.Deserialize<List<Order>>(json);

		DataTable dt = DefineOrderDataTable("OrderLog");
		foreach (var i in orders)
		{
			var dr = dt.NewRow();

			dr["Date"] = i.Date;
			dr["LastChangeDate"] = i.LastChangeDate;
			dr["SupplierArticle"] = i.SupplierArticle;
			dr["TechSize"] = i.TechSize;
			dr["Barcode"] = i.Barcode;
			dr["TotalPrice"] = i.TotalPrice;
			dr["DiscountPercent"] = i.DiscountPercent;
			dr["WarehouseName"] = i.WarehouseName;
			dr["Oblast"] = i.Oblast;
			dr["IncomeId"] = i.IncomeId is null ? DBNull.Value : i.IncomeId;
			dr["OdId"] = i.OdId;
			dr["NmId"] = i.NmId;
			dr["Subject"] = i.Subject;
			dr["Category"] = i.Category;
			dr["Brand"] = i.Brand;
			dr["IsCancel"] = i.IsCancel;
			dr["CancelDt"] = i.CancelDt;
			dr["GNumber"] = i.GNumber;
			dr["Sticker"] = i.Sticker;

			dt.Rows.Add(dr);
		}

		return dt;
	}

	public static DataTable StockDataGet(string json)
	{
		List<Stock> stocks = JsonSerializer.Deserialize<List<Stock>>(json);

		DataTable dt = DefineStockDataTable("StockLog");
		foreach (var stock in stocks)
		{
			var dr = dt.NewRow();

			dr["LastChangeDate"] = stock.LastChangeDate;
			dr["SupplierArticle"] = stock.SupplierArticle;
			dr["TechSize"] = stock.TechSize;
			dr["Barcode"] = stock.Barcode;
			dr["Quantity"] = stock.Quantity;
			dr["IsSupply"] = stock.IsSupply;
			dr["IsRealization"] = stock.IsRealization;
			dr["QuantityFull"] = stock.QuantityFull;
			dr["QuantityNotInOrders"] = stock.QuantityNotInOrders;
			dr["Warehouse"] = stock.Warehouse;
			dr["WarehouseName"] = stock.WarehouseName;
			dr["InWayToClient"] = stock.InWayToClient;
			dr["InWayFromClient"] = stock.InWayFromClient;
			dr["NmId"] = stock.NmId;
			dr["Subject"] = stock.Subject;
			dr["Category"] = stock.Category;
			dr["DaysOnSite"] = stock.DaysOnSite;
			dr["Brand"] = stock.Brand;
			dr["SCCode"] = stock.SCCode;
			dr["Price"] = stock.Price;
			dr["Discount"] = stock.Discount;

			dt.Rows.Add(dr);
		}

		return dt;
	}

	public static DataTable SupplyDataGet(string json)
	{
		List<Supply> supplies = JsonSerializer.Deserialize<List<Supply>>(json);

		DataTable dt = DefineSupplyDataTable("SupplyCall");
		foreach (var supply in supplies)
		{
			var dr = dt.NewRow();

			dr["IncomeId"] = supply.IncomeId is null ? DBNull.Value : supply.IncomeId;
			dr["Number"] = supply.Number;
			dr["Date"] = supply.Date;
			dr["LastChangeDate"] = supply.LastChangeDate;
			dr["SupplierArticle"] = supply.SupplierArticle;
			dr["TechSize"] = supply.TechSize;
			dr["Barcode"] = supply.Barcode;
			dr["Quantity"] = supply.Quantity;
			dr["TotalPrice"] = supply.TotalPrice;
			dr["DateClose"] = supply.DateClose;
			dr["WarehouseName"] = supply.WarehouseName;
			dr["NmId"] = supply.NmId;
			dr["Status"] = supply.Status;

			dt.Rows.Add(dr);
		}

		return dt;
	}

	private static DataTable DefineExciseDataTable(string name)
	{
		DataTable dt = new(name);
		dt.Columns.AddRange(new DataColumn[] {
				new DataColumn { ColumnName = "Id", DataType = typeof(long) },
				new DataColumn { ColumnName = "FinishedPrice", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "OperationTypeId", DataType = typeof(int) },
				new DataColumn { ColumnName = "FiscalDt", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "DocNumber", DataType = typeof(int) },
				new DataColumn { ColumnName = "FnNumber", DataType = typeof(string) },
				new DataColumn { ColumnName = "RegNumber", DataType = typeof(string) },
				new DataColumn { ColumnName = "Excise", DataType = typeof(string) },
				new DataColumn { ColumnName = "Date", DataType = typeof(DateTime) },
		});
		return dt;
	}

	private static DataTable DefineReportDataTable(string name)
	{
		DataTable dt = new(name);
		dt.Columns.AddRange(new DataColumn[] {
				new DataColumn { ColumnName = "RealizationreportId", DataType = typeof(long) },
				new DataColumn { ColumnName = "DateFrom", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "DateTo", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "CreateDt", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "SuppliercontractCode", DataType = typeof(string) },
				new DataColumn { ColumnName = "RrdId", DataType = typeof(long) },
				new DataColumn { ColumnName = "GiId", DataType = typeof(long) },
				new DataColumn { ColumnName = "SubjectName", DataType = typeof(string) },
				new DataColumn { ColumnName = "NmId", DataType = typeof(long) },
				new DataColumn { ColumnName = "BrandName", DataType = typeof(string) },
				new DataColumn { ColumnName = "SaName", DataType = typeof(string) },
				new DataColumn { ColumnName = "TsName", DataType = typeof(string) },
				new DataColumn { ColumnName = "Barcode", DataType = typeof(string) },
				new DataColumn { ColumnName = "DocTypeName", DataType = typeof(string) },
				new DataColumn { ColumnName = "Quantity", DataType = typeof(int) },
				new DataColumn { ColumnName = "RetailPrice", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "RetailAmount", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "SalePercent", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "CommissionPercent", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "OfficeName", DataType = typeof(string) },
				new DataColumn { ColumnName = "SupplierOperName", DataType = typeof(string) },
				new DataColumn { ColumnName = "OrderDt", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "SaleDt", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "RrDt", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "ShkId", DataType = typeof(long) },
				new DataColumn { ColumnName = "RetailPriceWithdiscRub", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "DeliveryAmount", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "ReturnAmount", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "DeliveryRub", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "GiBoxTypeName", DataType = typeof(string) },
				new DataColumn { ColumnName = "ProductDiscountForReport", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "SupplierPromo", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "RId", DataType = typeof(long) },
				new DataColumn { ColumnName = "PpvzSppPrc", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PpvzKvwPrcBase", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PpvzKvwPrc", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PpvzSalesCommission", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PpvzForPay", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PpvzReward", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "AcquiringFee", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "AcquiringBank", DataType = typeof(string) },
				new DataColumn { ColumnName = "PpvzVw", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PpvzVwNds", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PpvzOfficeId", DataType = typeof(int) },
				new DataColumn { ColumnName = "PpvzOfficeName", DataType = typeof(string) },
				new DataColumn { ColumnName = "PpvzSupplierId", DataType = typeof(int) },
				new DataColumn { ColumnName = "PpvzSupplierName", DataType = typeof(string) },
				new DataColumn { ColumnName = "PpvzInn", DataType = typeof(string) },
				new DataColumn { ColumnName = "DeclarationNumber", DataType = typeof(string) },
				new DataColumn { ColumnName = "BonusTypeName", DataType = typeof(string) },
				new DataColumn { ColumnName = "StickerId", DataType = typeof(string) },
				new DataColumn { ColumnName = "SiteCountry", DataType = typeof(string) },
				new DataColumn { ColumnName = "Penalty", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "AdditionalPayment", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "SrId", DataType = typeof(string) },
		});
		return dt;
	}

	private static DataTable DefineSaleDataTable(string name)
	{
		DataTable dt = new(name);
		dt.Columns.AddRange(new DataColumn[] {
				new DataColumn { ColumnName = "Date", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "LastChangeDate", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "SupplierArticle", DataType = typeof(string) },
				new DataColumn { ColumnName = "TechSize", DataType = typeof(string) },
				new DataColumn { ColumnName = "Barcode", DataType = typeof(string) },
				new DataColumn { ColumnName = "TotalPrice", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "DiscountPercent", DataType = typeof(bool) },
				new DataColumn { ColumnName = "IsSupply", DataType = typeof(bool) },
				new DataColumn { ColumnName = "IsRealization", DataType = typeof(bool) },
				new DataColumn { ColumnName = "PromoCodeDiscount", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "WarehouseName", DataType = typeof(string) },
				new DataColumn { ColumnName = "CountryName", DataType = typeof(string) },
				new DataColumn { ColumnName = "OblastOkrugName", DataType = typeof(string) },
				new DataColumn { ColumnName = "RegionName", DataType = typeof(string) },
				new DataColumn { ColumnName = "IncomeId", DataType = typeof(long) },
				new DataColumn { ColumnName = "SaleId", DataType = typeof(string) },
				new DataColumn { ColumnName = "OdId", DataType = typeof(long) },
				new DataColumn { ColumnName = "Spp", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "ForPay", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "FinishedPrice", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "PriceWithDisc", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "NmId", DataType = typeof(long) },
				new DataColumn { ColumnName = "Subject", DataType = typeof(string) },
				new DataColumn { ColumnName = "Category", DataType = typeof(string) },
				new DataColumn { ColumnName = "Brand", DataType = typeof(string) },
				new DataColumn { ColumnName = "IsStorno", DataType = typeof(bool) },
				new DataColumn { ColumnName = "GNumber", DataType = typeof(string) },
				new DataColumn { ColumnName = "Sticker", DataType = typeof(string) }
		});
		return dt;
	}

	private static DataTable DefineOrderDataTable(string name)
	{
		DataTable dt = new(name);
		dt.Columns.AddRange(new DataColumn[] {
				new DataColumn { ColumnName = "Date", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "LastChangeDate", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "SupplierArticle", DataType = typeof(string) },
				new DataColumn { ColumnName = "TechSize", DataType = typeof(string) },
				new DataColumn { ColumnName = "Barcode", DataType = typeof(string) },
				new DataColumn { ColumnName = "TotalPrice", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "DiscountPercent", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "WarehouseName", DataType = typeof(string) },
				new DataColumn { ColumnName = "Oblast", DataType = typeof(string) },
				new DataColumn { ColumnName = "IncomeId", DataType = typeof(long) },
				new DataColumn { ColumnName = "OdId", DataType = typeof(long) },
				new DataColumn { ColumnName = "NmId", DataType = typeof(long) },
				new DataColumn { ColumnName = "Subject", DataType = typeof(string) },
				new DataColumn { ColumnName = "Category", DataType = typeof(string) },
				new DataColumn { ColumnName = "Brand", DataType = typeof(string) },
				new DataColumn { ColumnName = "IsCancel", DataType = typeof(bool) },
				new DataColumn { ColumnName = "CancelDt", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "GNumber", DataType = typeof(string) },
				new DataColumn { ColumnName = "Sticker", DataType = typeof(string) }
		});
		return dt;
	}


	private static DataTable DefineStockDataTable(string name)
	{
		DataTable dt = new(name);
		dt.Columns.AddRange(new DataColumn[] {
				new DataColumn { ColumnName = "LastChangeDate", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "SupplierArticle", DataType = typeof(string) },
				new DataColumn { ColumnName = "TechSize", DataType = typeof(string) },
				new DataColumn { ColumnName = "Barcode", DataType = typeof(string) },
				new DataColumn { ColumnName = "Quantity", DataType = typeof(int) },
				new DataColumn { ColumnName = "IsSupply", DataType = typeof(bool) },
				new DataColumn { ColumnName = "IsRealization", DataType = typeof(bool) },
				new DataColumn { ColumnName = "QuantityFull", DataType = typeof(int) },
				new DataColumn { ColumnName = "QuantityNotInOrders", DataType = typeof(int) },
				new DataColumn { ColumnName = "Warehouse", DataType = typeof(int) },
				new DataColumn { ColumnName = "WarehouseName", DataType = typeof(string) },
				new DataColumn { ColumnName = "InWayToClient", DataType = typeof(int) },
				new DataColumn { ColumnName = "InWayFromClient", DataType = typeof(int) },
				new DataColumn { ColumnName = "NmId", DataType = typeof(long) },
				new DataColumn { ColumnName = "Subject", DataType = typeof(string) },
				new DataColumn { ColumnName = "Category", DataType = typeof(string) },
				new DataColumn { ColumnName = "DaysOnSite", DataType = typeof(int) },
				new DataColumn { ColumnName = "Brand", DataType = typeof(string) },
				new DataColumn { ColumnName = "SCCode", DataType = typeof(string) },
				new DataColumn { ColumnName = "Price", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "Discount", DataType = typeof(decimal) }
		});
		return dt;
	}

	private static DataTable DefineSupplyDataTable(string name)
	{
		DataTable dt = new(name);
		dt.Columns.AddRange(new DataColumn[] {
				new DataColumn { ColumnName = "IncomeId", DataType = typeof(long) },
				new DataColumn { ColumnName = "Number", DataType = typeof(string) },
				new DataColumn { ColumnName = "Date", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "LastChangeDate", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "SupplierArticle", DataType = typeof(string) },
				new DataColumn { ColumnName = "TechSize", DataType = typeof(string) },
				new DataColumn { ColumnName = "Barcode", DataType = typeof(string) },
				new DataColumn { ColumnName = "Quantity", DataType = typeof(int) },
				new DataColumn { ColumnName = "TotalPrice", DataType = typeof(decimal) },
				new DataColumn { ColumnName = "DateClose", DataType = typeof(DateTime) },
				new DataColumn { ColumnName = "WarehouseName", DataType = typeof(string) },
				new DataColumn { ColumnName = "NmId", DataType = typeof(long) },
				new DataColumn { ColumnName = "Status", DataType = typeof(string) }
		});
		return dt;
	}
}