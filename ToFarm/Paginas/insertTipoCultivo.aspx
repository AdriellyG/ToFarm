<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/menuLateral.master" AutoEventWireup="true" CodeFile="insertTipoCultivo.aspx.cs" Inherits="Paginas_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="titulo">
        <h2>Cadastro de tipo de cultivo</h2>
    </div>
    <div class="container">
        <div class="col-md-6">
            <label>Nome:</label>
            <asp:TextBox ID="txtNome" cssclass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-success" OnClick="btnCadastrar_Click"/>
            <a class="btn btn-primary" href="exibirTipoCultivo.aspx">Voltar</a>
        </div>

        <script type="JavaScript">
            function mensagemSucesso(stringMensagem, Pagina){
                  alert(stringMensagem);
                  location.href=Pagina;
            }
        </script>
    </div>
</asp:Content>