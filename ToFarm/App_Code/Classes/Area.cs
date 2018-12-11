using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class Area
{
    private int id;
    private string nome;
    private LocalFisico local;
    private TipoSolo tipo_solo;

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

    public TipoSolo Tipo_solo
    {
        get
        {
            return tipo_solo;
        }

        set
        {
            tipo_solo = value;
        }
    }
}