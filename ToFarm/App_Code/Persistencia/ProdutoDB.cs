using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ProdutoDB
{

    // insert
    public static bool Insert(Produto produto)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO pro_produto(pro_nome, tip_id) VALUES(?pro_nome, ?tip_id)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_nome", produto.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tip_id", produto.Tipo.Id));
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
        objCommand = Mapped.Command("SELECT * FROM pro_produto", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    // select id
    public Produto Select(int id)
    {
        Produto obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();

        objCommand = Mapped.Command("SELECT * FROM pro_produto WHERE pro_id = ?pro_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_id", id));
        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Produto();
            obj.Nome = Convert.ToString(objDataReader["pro_nome"]);
            obj.Tipo.Id = Convert.ToInt32(objDataReader["tip_id"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    // update
    public bool Update(Produto produto)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE cul_cultivo SET cul_nome = ?cul_nome, tic_id = ?tic_id WHERE cul_id = ?cul_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_nome", produto.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_id", produto.Id));
            objCommand.Parameters.Add(Mapped.Parameter("?tip_id", produto.Tipo.Id));
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
        string sql = "DELETE FROM pro_produto WHERE pro_id = ?pro_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_id", id));

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