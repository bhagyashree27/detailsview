<%@ Page Language="C#" AutoEventWireup="true" CodeFile="details_view.aspx.cs" Inherits="details_view" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
            AutoGenerateRows="False" BackColor="#CCCCCC" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
            DataKeyNames="cid" ForeColor="Black" Height="50px" 
            onitemdeleting="DetailsView1_ItemDeleting" 
            oniteminserting="DetailsView1_ItemInserting" 
            onitemupdating="DetailsView1_ItemUpdating" 
            onmodechanging="DetailsView1_ModeChanging" 
            onpageindexchanging="DetailsView1_PageIndexChanging" Width="125px">
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:TemplateField HeaderText="id">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cid") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("cid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cname") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cname") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("cname") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                  <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnq" CommandName="Update"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                <asp:CommandField ShowInsertButton="True" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
        </asp:DetailsView>

        <asp:Chart ID="Chart1" runat="server" OnDataBound="Chart1_DataBound" OnDataBinding="Chart1_DataBinding">
            <Titles>
                <asp:Title Text="chart"></asp:Title>
            </Titles>
            <Series >
                <asp:Series Name="Series1" XValueMember="cname" YValueMembers="cid"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX  Title="city"></AxisX>
                    <AxisY Title="cname" ></AxisY>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Title="key" ></asp:Legend>
            </Legends>
        </asp:Chart>
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1">
            <Series>
                <asp:Series Name="Series1" XValueMember="cname" YValueMembers="cid" YValuesPerPoint="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dem123ConnectionString2 %>" SelectCommand="SELECT * FROM [country]"></asp:SqlDataSource>
        <asp:Chart ID="Chart3" runat="server">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br />
        <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
