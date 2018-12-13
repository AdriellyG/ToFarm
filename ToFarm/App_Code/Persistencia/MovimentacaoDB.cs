using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class MovimentacaoDB
{

    //insert
    public static bool Insert(Movimentacao movimentacao)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        try
        {
            string sql = "INSERT INTO mov_movimentacao(mov_quantidade, lof_id, pro_id, tim_id)";
            sql += " VALUES(?mov_quantidade, ?lof_id, ?pro_id, ?tim_id)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?mov_quantidade", movimentacao.Quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("lof_id", movimentacao.Local.Id));
            objCommand.Parameters.Add(Mapped.Parameter("pro_id", movimentacao.Produto.Id));
            objCommand.Parameters.Add(Mapped.Parameter("tim_id", movimentacao.Tipo.Id));
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
        objCommand = Mapped.Command("SELECT * FROM mov_movimentacao", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectAllGrid()
    {
        string sql;
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        sql = "select m.mov_quantidade as Quantidade, p.pro_nome as Produto, t.tim_nome as Tipo, l.lof_nome as Local from mov_movimentacao m ";
        sql += "inner join pro_produto p 		   on p.pro_id = m.pro_id ";
        sql += "inner join lof_local_fisico l 	   on l.lof_id = m.lof_id ";
        sql += "inner join tim_tipo_movimentacao t on t.tim_id = m.tim_id ";
        sql += "order by p.pro_nome asc";

        objCommand = Mapped.Command(sql, objConexao);

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public Movimentacao Select(int id)
    {
        Movimentacao obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM mov_movimentacao WHERE mov_id = ?mov_id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?mov_id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new Movimentacao();
            obj.Quantidade = Convert.ToDouble(objDataReader["mov_quantidade"]);
            obj.Local.Id = Convert.ToInt32(objDataReader["lof_id"]);
            obj.Produto.Id = Convert.ToInt32(objDataReader["pro_id"]);
            obj.Tipo.Id = Convert.ToInt32(objDataReader["tim_id"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    //update
    public bool Update(Movimentacao movimentacao)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE mov_movimentacao ";
        sql += "SET mov_quantidade = ?mov_quantidade, lof_id = ?lof_id, pro_id = ?pro_id, tim_id = ?tim_id ";
        sql += "WHERE mov_id = ?mov_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?mov_quantidade", movimentacao.Quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("lof_id", movimentacao.Local.Id));
            objCommand.Parameters.Add(Mapped.Parameter("pro_id", movimentacao.Produto.Id));
            objCommand.Parameters.Add(Mapped.Parameter("tim_id", movimentacao.Tipo.Id));
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
        string sql = "DELETE FROM mov_movimentacao WHERE mov_id = ?mov_id";
        try
        {
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?mov_id", id));

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