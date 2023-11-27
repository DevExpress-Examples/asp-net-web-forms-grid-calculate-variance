Imports System
Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack AndAlso Not IsCallback Then
			grid.ExpandAll()
		End If
	End Sub
	Protected Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewColumnDataEventArgs)
		If e.Column.FieldName = "Variance" Then
			Dim unitPrice As Decimal = Convert.ToDecimal(e.GetListSourceFieldValue("UnitPrice"))
			Dim unitsInStock As Decimal = Convert.ToDecimal(e.GetListSourceFieldValue("UnitsInStock"))
			If unitPrice <> 0 Then
				e.Value = (unitPrice - unitsInStock) / unitPrice
			Else
				e.Value = 0
			End If
		End If
	End Sub
	Private totalSumUnitPrice As Decimal
	Private totalSumUnitsInStock As Decimal
	Protected Sub grid_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs)
		If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
			totalSumUnitPrice = 0
			totalSumUnitsInStock = 0
		Else
		If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
			totalSumUnitPrice += Convert.ToDecimal(e.GetValue("UnitPrice"))
			totalSumUnitsInStock += Convert.ToDecimal(e.GetValue("UnitsInStock"))
		Else
		If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
			If totalSumUnitPrice <> 0 Then
				e.TotalValue = (totalSumUnitPrice - totalSumUnitsInStock) / totalSumUnitPrice
			Else
				e.TotalValue = 0
			End If
		End If
		End If
		End If
	End Sub
End Class
