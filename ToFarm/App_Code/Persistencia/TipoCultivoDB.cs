using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class TipoCultivoDB
{

    //insert
    public bool Insert(TipoCultivo tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO tic_tipo_cultivo(tip_nome) VALUES(?tic_nome)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tic_nome", tipo.Nome));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    //selectall
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM tic_tipo_cultivo", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public TipoCultivo Select(int id)
    {
        TipoCultivo obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM tic_tipo_cultivo WHERE tic_id = ?tic_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?tic_id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new TipoCultivo();
            obj.Nome = Convert.ToString(objDataReader["tip_nome"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    //update
    public bool Update(TipoCultivo tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE tic_tipo_cultivo SET tic_nome = ?tic_nome WHERE tic_id = ?tic_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tip_nome", tipo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_id", tipo.Id));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }catch(Exception e)
        {
            return false;
        }
    }

    //delete
    public bool Delete(int id)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "DELETE FROM tic_tipo_cultivo WHERE tic_id = ?tic_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tic_id", id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }catch(Exception e)
        {
            return false;
        }
    }

}