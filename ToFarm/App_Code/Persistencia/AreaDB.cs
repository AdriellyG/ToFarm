using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class AreaDB
{

    //insert
    public static bool Insert(Area area)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO are_area(are_nome, lof_id, tis_id) VALUES(?are_nome, ?lof_id, ?tis_id)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?are_nome", area.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("lof_id", area.Local.Id));
            objCommand.Parameters.Add(Mapped.Parameter("tis_id", area.Tipo_solo.Id));
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
        objCommand = Mapped.Command("SELECT * FROM are_area", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public Area Select(int id)
    {
        Area obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM are_area WHERE are_id = ?are_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?are_id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new Area();
            obj.Nome = Convert.ToString(objDataReader["are_nome"]);
            obj.Local.Id = Convert.ToInt32(objDataReader["lof_id"]);
            obj.Tipo_solo.Id = Convert.ToInt32(objDataReader["tis_id"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    //update
    public bool Update(Area area)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE are_area SET are_nome = ?are_nome, lof_id = ?lof_id, tis_id = ?tis_id WHERE are_id = ?are_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?are_nome", area.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?lof_id", area.Local.Id));
            objCommand.Parameters.Add(Mapped.Parameter("?tis_id", area.Tipo_solo.Id));
            objCommand.Parameters.Add(Mapped.Parameter("?are_id", area.Id));
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
        string sql = "DELETE FROM are_area WHERE are_id = ?are_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?are_id", id));

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