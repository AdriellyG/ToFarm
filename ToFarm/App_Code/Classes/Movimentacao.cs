using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Movimentacao
{
    private int id;
    private double quantidade;
    private TipoMovimentacao tipo;
    private Produto produto;
    private LocalFisico local;

    public double Quantidade
    {
        get
        {
            return quantidade;
        }

        set
        {
            quantidade = value;
        }
    }

    public TipoMovimentacao Tipo
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

    public Produto Produto
    {
        get
        {
            return produto;
        }

        set
        {
            produto = value;
        }
    }

    public LocalFisico Local
    {
        get
        {
            return local;
        }

        set
        {
            local = value;
        }
    }

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
}