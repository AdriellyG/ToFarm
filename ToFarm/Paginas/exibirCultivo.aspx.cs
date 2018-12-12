using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_exibirCultivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarGrid();
        }
    }

    public void CarregarGrid()
    {
        DataSet ds = CultivoDB.SelectAllGrid();
        int qtd = ds.Tables[0].Rows.Count;
        if (qtd > 0)
        {
            gdv.DataSource = ds.Tables[0].DefaultView;
            gdv.DataBind();
            gdv.Visible = true;
            lblGrid.Text = "Foram encontrados " + qtd + " registros";
        }
        else
        {
            gdv.Visible = false;
            lblGrid.Text = "Não foram encontrado registros...";
        }
    }
}