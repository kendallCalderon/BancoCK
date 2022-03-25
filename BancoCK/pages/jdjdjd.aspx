<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jdjdjd.aspx.cs" Inherits="BancoCK.pages.jdjdjd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="">
            <asp:GridView class="tabla" ID="GridView1" runat="server" AutoGenerateColumns="False" >
                <Columns>

                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Préstamo #" HeaderText="Préstamo #">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Identificación" HeaderText="Identificación">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>


                    <asp:TemplateField  HeaderText="Nombre Analista">

                           <ItemTemplate>
                               <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1">
                               </asp:DropDownList>
                               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoSitiosConnectionString %>" SelectCommand="devolverAnalistasComboBox" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                        </ItemTemplate>

                           <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                    </asp:TemplateField>



                    <asp:TemplateField  HeaderText="Acciones">

                        <ItemTemplate>
                            <itemstyle horizontalalign="Center" />
                            <asp:LinkButton Text="text" runat="server"><i class="fa-solid fa-circle-check icn"></i></asp:LinkButton>
                        </ItemTemplate>

                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
        </div>
        </div>
    </form>
</body>
</html>
