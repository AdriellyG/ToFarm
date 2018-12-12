using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_insertArea : System.Web.UI.Page
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

            DataSet ds1 = TipoSoloDB.SelectAll();
            ddlTipo.DataSource = ds1;
            ddlTipo.DataTextField = "tis_nome"; // Nome da coluna do Banco de dados          
            ddlTipo.DataValueField = "tis_id";
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, "Selecione");
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        string mensagem;
        Area area = new Area();
        area.Nome = txtNome.Text;

        TipoSolo tip = new TipoSolo();
        tip.Id = Convert.ToInt32(ddlTipo.SelectedValue);

        area.Tipo_solo = tip;

        LocalFisico loc = new LocalFisico();
        loc.Id = Convert.ToInt32(ddlLocal.SelectedValue);

        area.Local = loc;

        if (AreaDB.Insert(area))
        {
            mensagem = "Cadastrado com sucesso!";
            txtNome.Text = "";
            ddlLocal.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            txtNome.Focus();
        }
        else
            mensagem = "Erro!";
        Response.Write("<script language='javascript'>alert('" + mensagem + "');</script>");
    }
}