<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/menuLateral.master" AutoEventWireup="true" CodeFile="insertProduto.aspx.cs" Inherits="Paginas_insertProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titulo">
        <h2>Cadastro de produto</h2>
    </div>
    <div class="container">
        <div class="col-md-6">
            <label>Nome:</label>
            <asp:TextBox ID="txtNome" cssclass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label>Tipo:</label>
            <asp:DropDownList ID="ddlTipo" cssclass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-6">
            <br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-success" OnClick="btnCadastrar_Click"/>
        </div>
        <div class="col-md-5">
            <br />
            <asp:Label ID="lbl" CssClass="label-msg" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>