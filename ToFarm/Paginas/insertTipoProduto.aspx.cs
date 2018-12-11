using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_insertTipoProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        TipoProduto tipo = new TipoProduto();

        tipo.Nome = txtNome.Text;
        tipo.Descricao = txtDescricao.Text;

        if (TipoProdutoDB.Insert(tipo))
        {
            lbl.Text = "Cadastrado com sucesso!";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtNome.Focus();
        }
        else
            lbl.Text = "Erro!";

    }
}