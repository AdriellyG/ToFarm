using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Produto
{
    private int id;
    private string nome;
    private TipoProduto tipo;

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

    public TipoProduto Tipo
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