using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_insertTipoMovimentacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        TipoMovimentacao tipo = new TipoMovimentacao();

        tipo.Nome = txtNome.Text;
        tipo.Descricao = txtDescricao.Text;

        TipoMovimentacaoDB t = new TipoMovimentacaoDB();

        if (t.Insert(tipo))
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