using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de TipoSolo
/// </summary>
public class TipoSolo
{
    private int id;
    private string nome;
    private double acidez;

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

    public double Acidez
    {
        get
        {
            return acidez;
        }

        set
        {
            acidez = value;
        }
    }
}