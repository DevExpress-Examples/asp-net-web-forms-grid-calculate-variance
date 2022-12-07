using System;
public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack && !IsCallback)
            grid.ExpandAll();
    }
    protected void grid_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e) {
        if (e.Column.FieldName == "Variance") {
            decimal unitPrice = Convert.ToDecimal(e.GetListSourceFieldValue("UnitPrice"));
            decimal unitsInStock = Convert.ToDecimal(e.GetListSourceFieldValue("UnitsInStock"));
            if (unitPrice != 0)
                e.Value = (unitPrice - unitsInStock) / unitPrice;
            else
                e.Value = 0;
        }
    }
    decimal totalSumUnitPrice;
    decimal totalSumUnitsInStock;
    protected void grid_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e) {
        if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start) {
            totalSumUnitPrice = 0;
            totalSumUnitsInStock = 0;
        }else
        if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate) {
            totalSumUnitPrice += Convert.ToDecimal(e.GetValue("UnitPrice"));
            totalSumUnitsInStock += Convert.ToDecimal(e.GetValue("UnitsInStock"));
        }else
        if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize) {
            if (totalSumUnitPrice != 0)
                e.TotalValue = (totalSumUnitPrice - totalSumUnitsInStock) / totalSumUnitPrice;
            else
                e.TotalValue = 0;
        }
    }
}
