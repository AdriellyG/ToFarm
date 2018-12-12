using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_insertLocalFisico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        string mensagem;
        LocalFisico tipo = new LocalFisico();

        tipo.Nome = txtNome.Text;
        tipo.Descricao = txtDescricao.Text;

        if (LocalFisicoDB.Insert(tipo))
        {
            mensagem = "Cadastrado com sucesso!";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtNome.Focus();
        }
        else
            mensagem = "Erro!";
        Response.Write("<script language='javascript'>alert('" + mensagem + "');</script>");
    }
}