using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class TipoProdutoDB
{

    //insert
    public static bool Insert(TipoProduto tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO tip_tipo_produto(tip_nome, tip_descricao) VALUES(?tic_nome, ?tip_descricao)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tic_nome", tipo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tip_descricao", tipo.Descricao));
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
        objCommand = Mapped.Command("SELECT * FROM tip_tipo_produto", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public TipoProduto SelectID(int id)
    {
        TipoProduto obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM tip_tipo_produto WHERE tip_id = ?tip_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?tip_id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new TipoProduto();
            obj.Nome = Convert.ToString(objDataReader["tip_nome"]);
            obj.Descricao = Convert.ToString(objDataReader["tip_descricao"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    //update
    public static bool Update(TipoProduto tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE tip_tipo_produto SET tip_nome = ?tic_nome, tip_descricao = ?tip_descricao WHERE tip_id = ?tip_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tip_nome", tipo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tip_descricao", tipo.Descricao));
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
        string sql = "DELETE FROM tip_tipo_produto WHERE tip_id = ?tip_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tip_id", id));

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