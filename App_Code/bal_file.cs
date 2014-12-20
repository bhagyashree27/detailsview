using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for bal_file
/// </summary>
public class bal_file
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter ad;
	public bal_file()
	{
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["my"].ToString());
	}
    public DataTable bind_grid()
    {
        con.Open();
        cmd = new SqlCommand("select * from country", con);
      //  cmd.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        ad = new SqlDataAdapter(cmd);
        ad.Fill(dt);

        con.Close();
        return dt;
    }
    public void inser_stud(dal dl)
    {
        con.Open();
        cmd = new SqlCommand("insert into country(cname) values(@cname) ", con);
      //  cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@cname", dl.name);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void update_stud(dal dl)
    {
        con.Open();
        cmd = new SqlCommand("update country set cname=@cname where cid= @cid", con);
       // cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@cid", dl.id);
        cmd.Parameters.AddWithValue("@cname", dl.name);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void delete_stud(dal dl)
    {
        con.Open();
        cmd = new SqlCommand("delete  from country where cid=@cid", con);
      //  cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@cid", dl.id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}