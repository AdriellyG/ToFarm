﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TipoCultivo
{
    private int id;
    private string nome;


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
}