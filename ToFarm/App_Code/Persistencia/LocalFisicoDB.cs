using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class LocalFisicoDB
{

    //insert
    public static bool Insert(LocalFisico local)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO lof_local_fisico(lof_nome, loc_descricao) VALUES(?lof_nome, ?loc_descricao)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?lof_nome", local.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("loc_descricao", local.Descricao));
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
        objCommand = Mapped.Command("SELECT * FROM lof_local_fisico", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public LocalFisico Select(int id)
    {
        LocalFisico obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM lof_local_fisico WHERE lof_id = ?lof_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?lof_id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new LocalFisico();
            obj.Nome = Convert.ToString(objDataReader["lof_nome"]);
            obj.Descricao = Convert.ToString(objDataReader["loc_descricao"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    //update
    public bool Update(LocalFisico local)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE lof_local_fisico SET lof_nome = ?lof_nome, loc_descricao = ?loc_descricao WHERE lof_id = ?lof_id";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?lof_nome", local.Nome));
        objCommand.Parameters.Add(Mapped.Parameter("?loc_descricao", local.Descricao));
        objCommand.Parameters.Add(Mapped.Parameter("?lof_id", local.Id));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return true;
    }

    //delete
    public bool Delete(int id)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "DELETE FROM lof_local_fisico WHERE lof_id = ?lof_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?lof_id", id));

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