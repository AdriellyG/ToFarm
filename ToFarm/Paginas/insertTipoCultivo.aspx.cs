﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default : System.Web.UI.Page
{
    private string mensagem;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        TipoCultivo tipo = new TipoCultivo();

        tipo.Nome = txtNome.Text;

        TipoCultivoDB t = new TipoCultivoDB();
        
        if (t.Insert(tipo))
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