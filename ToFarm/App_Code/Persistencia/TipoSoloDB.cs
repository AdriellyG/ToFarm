using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class TipoSoloDB
{

    //insert
    public static bool Insert(TipoSolo tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO tis_tipo_solo(tis_nome, tis_acidez) VALUES(?tis_nome, ?tis_acidez)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tis_nome", tipo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tis_acidez", tipo.Acidez));
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
        objCommand = Mapped.Command("SELECT * FROM tis_tipo_solo", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public TipoSolo Select(int id)
    {
        TipoSolo obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM tic_tipo_cultivo WHERE tic_id = ?tic_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?tic_id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new TipoSolo();
            obj.Nome = Convert.ToString(objDataReader["tis_nome"]);
            obj.Acidez = Convert.ToDouble(objDataReader["tis_acidez"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    //update
    public bool Update(TipoSolo tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE tis_tipo_solo SET tis_nome = ?tis_nome, tis_acidez = ?tis_acidez WHERE tis_id = ?tis_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tis_nome", tipo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tis_acidez", tipo.Acidez));
            objCommand.Parameters.Add(Mapped.Parameter("?tis_id", tipo.Id));
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

    //delete
    public bool Delete(int id)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "DELETE FROM tis_tipo_solo WHERE tis_id = ?tis_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tis_id", id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            return true;
        }catch(Exception e) {
            return false;
        }
    }

}