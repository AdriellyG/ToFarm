using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Cultivo
{
    private int id;
    private string nome;
    private TipoCultivo tipo;

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

    public TipoCultivo Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }
}