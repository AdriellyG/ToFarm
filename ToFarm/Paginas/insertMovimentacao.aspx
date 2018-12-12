<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/menuLateral.master" AutoEventWireup="true" CodeFile="insertMovimentacao.aspx.cs" Inherits="Paginas_insertMovimentacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titulo">
        <h2>Cadastro de movimentação</h2>
    </div>
    <div class="container">
        <div class="col-md-6">
            <label>Quantidade:</label>
            <asp:TextBox ID="txtQtd" cssclass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label>Local físico:</label>
            <asp:DropDownList ID="ddlLocal" cssclass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-6">
            <label>Tipo de movimentação:</label>
            <asp:DropDownList ID="ddlTipo" cssclass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-6">
            <label>Produto:</label>
            <asp:DropDownList ID="ddlProduto" cssclass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-6">
            <br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-success" OnClick="btnCadastrar_Click"/>
            <a class="btn btn-primary" href="exibirTipoCultivo.aspx">Voltar</a>
        </div>
        <div class="col-md-5">
            <br />
            <asp:Label ID="lbl" CssClass="label-msg" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>