<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="accessDataSource" KeyFieldName="ProductID" 
            OnCustomUnboundColumnData="grid_CustomUnboundColumnData" OnCustomSummaryCalculate="grid_CustomSummaryCalculate">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ProductName" />
                <dx:GridViewDataTextColumn FieldName="CategoryID" GroupIndex="0" />
                <dx:GridViewDataTextColumn FieldName="UnitPrice" />
                <dx:GridViewDataTextColumn FieldName="UnitsInStock" />
                <dx:GridViewDataTextColumn FieldName="Variance" Name="Variance" UnboundType="Decimal">
                    <PropertiesTextEdit DisplayFormatString="F2" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <Settings ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleIfExpanded" />
            <SettingsBehavior AllowSort="true" AllowGroup="true" />
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="Variance" SummaryType="Custom" DisplayFormat="F2"/>
            </TotalSummary>
            <GroupSummary>
                <dx:ASPxSummaryItem FieldName="Variance" SummaryType="Custom" DisplayFormat="F2" ShowInGroupFooterColumn="Variance" />
            </GroupSummary>
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="accessDataSource" runat="server" DataFile="~/App_Data/nwind.mdb" SelectCommand="SELECT TOP 4  *  FROM [Products]" />
    </div>
    </form>
</body>
</html>
