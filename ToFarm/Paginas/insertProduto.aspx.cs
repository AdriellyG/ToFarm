using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_insertProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = TipoProdutoDB.SelectAll();
            ddlTipo.DataSource = ds;
            ddlTipo.DataTextField = "tip_nome"; // Nome da coluna do Banco de dados          
            ddlTipo.DataValueField = "tip_id";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, "Selecione");
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        string mensagem;
        Produto pro = new Produto();
        pro.Nome = txtNome.Text;

        TipoProduto tip = new TipoProduto();
        tip.Id = Convert.ToInt32(ddlTipo.SelectedValue);

        pro.Tipo = tip;

        if (ProdutoDB.Insert(pro))
        {
            mensagem = "Cadastrado com sucesso!";
            txtNome.Text = "";
            txtNome.Focus();
        }
        else
            mensagem = "Erro!";
        Response.Write("<script language='javascript'>alert('" + mensagem + "');</script>");
    }
}