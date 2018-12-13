<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/menuLateral.master" AutoEventWireup="true" CodeFile="exibirTipoCultivo.aspx.cs" Inherits="Paginas_exibirTipoCultivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .grdContent {
            width: 80%;
            border: solid 2px black;
            min-width: 80%;
        }

        .header {
            background-color: #646464;
            font-family: Arial;
            color: White;
            border: none 0px transparent;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
            border: none 0px transparent;
        }

        .rows:hover {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            text-align: left;
        }

        .selectedrow {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }

        .mydatagrid a /** FOR THE PAGING ICONS  **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

        .mygrdContent a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/ {
            background-color: #000;
            color: #fff;
        }

        .mygrdContent span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #c9c9c9;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #646464;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mygrdContent td {
            padding: 1%;
        }

        .mygrdContent th {
            padding: 1%;
        }
    </style>
    <div class="titulo">    
        <h2>Listar tipos de cultivo</h2>
    </div>
    <div class="container">
        
        <div class="col-md-12">
            <a class="btn btn-success" href="insertTipoCultivo.aspx">Inserir novo registro</a>
            <br /><br />
        </div>
        
        <div class="col-md-12">
            <asp:GridView ID="gdv" runat="server" AutoGenerateColumns="False" PagerStyle-CssClass="pager" Width="90%" CssClass="mygrdContent" AllowPaging="False" RowStyle-CssClass="rows" HeaderStyle-CssClass="header">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="tip_nome" HeaderText="Nome" ControlStyle-CssClass="form-control" />
                </Columns>
            </asp:GridView>
            <br /><br />
        </div>

        <div class="col-md-12 mx-auto">
            <asp:Label ID="lblGrid" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>