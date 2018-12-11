using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_insertMovimentacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = LocalFisicoDB.SelectAll();
            ddlLocal.DataSource = ds;
            ddlLocal.DataTextField = "lof_nome"; // Nome da coluna do Banco de dados          
            ddlLocal.DataValueField = "lof_id";
            ddlLocal.DataBind();
            ddlLocal.Items.Insert(0, "Selecione");

            DataSet ds1 = TipoMovimentacaoDB.SelectAll();
            ddlTipo.DataSource = ds1;
            ddlTipo.DataTextField = "tim_nome"; // Nome da coluna do Banco de dados          
            ddlTipo.DataValueField = "tim_id";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, "Selecione");

            DataSet ds2 = ProdutoDB.SelectAll();
            ddlProduto.DataSource = ds2;
            ddlProduto.DataTextField = "pro_nome"; // Nome da coluna do Banco de dados          
            ddlProduto.DataValueField = "pro_id";
            ddlProduto.DataBind();
            ddlProduto.Items.Insert(0, "Selecione");
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        Movimentacao mov = new Movimentacao();
        mov.Quantidade =Convert.ToDouble(txtQtd.Text);

        TipoMovimentacao tip = new TipoMovimentacao();
        tip.Id = Convert.ToInt32(ddlTipo.SelectedValue);

        mov.Tipo = tip;

        LocalFisico loc = new LocalFisico();
        loc.Id = Convert.ToInt32(ddlLocal.SelectedValue);

        mov.Local = loc;

        Produto pro = new Produto();
        pro.Id = Convert.ToInt32(ddlProduto.SelectedValue);

        mov.Produto = pro;

        if (MovimentacaoDB.Insert(mov))
        {
            lbl.Text = "Cadastrado com sucesso!";
            txtQtd.Text = "";
            ddlLocal.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            ddlProduto.SelectedIndex = 0;
            txtQtd.Focus();
        }
        else
            lbl.Text = "Erro!";
    }
}