using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LocalFisico
{
    private int id;
    private string nome;
    private string descricao;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Nome
    {
        get
        {
            return nome;
        }

        set
        {
            nome = value;
        }
    }

    public string Descricao
    {
        get
        {
            return descricao;
        }

        set
        {
            descricao = value;
        }
    }
}