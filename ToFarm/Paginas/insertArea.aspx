﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/menuLateral.master" AutoEventWireup="true" CodeFile="insertArea.aspx.cs" Inherits="Paginas_insertArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titulo">
        <h2>Cadastro de área</h2>
    </div>
    <div class="container">
        <div class="col-md-6">
            <label>Nome:</label>
            <asp:TextBox ID="txtNome" cssclass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label>Local físico:</label>
            <asp:DropDownList ID="ddlLocal" cssclass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-6">
            <label>Tipo de solo:</label>
            <asp:DropDownList ID="ddlTipo" cssclass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-6">
            <br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-success" OnClick="btnCadastrar_Click"/>
            <a class="btn btn-primary" href="exibirArea.aspx">Voltar</a>
        </div>
    </div>
</asp:Content>