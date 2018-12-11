<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/menuLateral.master" AutoEventWireup="true" CodeFile="insertTipoSolo.aspx.cs" Inherits="Paginas_insertTipoSolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titulo">
        <h2>Cadastro de tipo de solo</h2>
    </div>
    <div class="container">
        <div class="col-md-6">
            <label>Nome:</label>
            <asp:TextBox ID="txtNome" cssclass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <br />
            <label>Acidez:</label>
            <asp:TextBox ID="txtAcidez" cssclass="form-control" runat="server"></asp:TextBox>
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