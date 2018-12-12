using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class CultivoDB
{

    // insert
    public static bool Insert(Cultivo cultivo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO cul_cultivo(cul_nome, tic_id) VALUES(?cul_nome, ?tic_id)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cul_nome", cultivo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_id", cultivo.Tipo.Id));
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

    // selectall
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cul_cultivo", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectAllGrid()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT c.cul_nome as Nome, t.tip_nome as Tipo FROM cul_cultivo c inner join tic_tipo_cultivo t on t.tic_id = c.tic_id", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    // select id
    public Cultivo Select(int id)
    {
        Cultivo obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();

        objCommand = Mapped.Command("SELECT * FROM cul_cultivo WHERE cul_id = ?cul_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cul_id", id));
        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Cultivo();
            obj.Nome = Convert.ToString(objDataReader["cul_nome"]);
            obj.Tipo.Id = Convert.ToInt32(objDataReader["tic_id"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    // update
    public bool Update(Cultivo cultivo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE cul_cultivo SET cul_nome = ?cul_nome, tic_id = ?tic_id WHERE cul_id = ?cul_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cul_nome", cultivo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?cul_id", cultivo.Id));
            objCommand.Parameters.Add(Mapped.Parameter("?tic_id", cultivo.Tipo.Id));
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
        string sql = "DELETE FROM cul_cultivo WHERE cul_id = ?cul_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cul_id", id));

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