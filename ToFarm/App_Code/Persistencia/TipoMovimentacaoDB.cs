using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class TipoMovimentacaoDB
{

    //insert
    public bool Insert(TipoMovimentacao tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO tim_tipo_movimentacao(tim_nome, tim_descricao) VALUES(?tim_nome, ?tim_descricao)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tim_nome", tipo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tim_descricao", tipo.Nome));
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
        objCommand = Mapped.Command("SELECT * FROM tim_tipo_movimentacao", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public TipoMovimentacao Select(int id)
    {
        TipoMovimentacao obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM tim_tipo_movimentacao WHERE tim_id = ?tim_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?tim_id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new TipoMovimentacao();
            obj.Nome = Convert.ToString(objDataReader["tim_nome"]);
            obj.Descricao = Convert.ToString(objDataReader["tim_descricao"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    //update
    public bool Update(TipoMovimentacao tipo)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE tim_tipo_movimentcao SET tim_nome = ?tim_nome, tim_descricao = ?tim_descricao WHERE tim_id = ?tim_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tim_nome", tipo.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?tim_descricao", tipo.Descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?tim_id", tipo.Id));
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
        string sql = "DELETE FROM tim_tipo_movimentacao WHERE tim_id = ?tim_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tim_id", id));

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

}