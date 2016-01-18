using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// This class has a constructor that creates the connection 
/// object and three methods. 
/// 
/// GetAuthors method sets up the SQL 
/// string to access services and serviceKey. 
/// 
/// GetAuthorBooks method does the same but the sql string 
/// has a variable.
/// 
/// The Process Query Method executes the sql and returns
/// a datatable.
/// </summary>
public class AuthorsAndBooks
{
    //create connection object
    SqlConnection connect;
    public AuthorsAndBooks()
    {
        //initialize connection object
        //the connection string is in the web config
        //The config manager lets the code
        //access the web config file
        connect = new SqlConnection(ConfigurationManager.
            ConnectionStrings["BookReviewDBConnectionString"].ToString());
    }

    public DataTable GetAuthors()
    {
        //create sql string
        string sql = "Select AuthorKey, AuthorName from Author";
        DataTable tbl;//declare table
        //initialize the command passing sql and connection
        SqlCommand cmd = new SqlCommand(sql, connect);
        try
        {
            //call ProcessQuery method
            tbl = ProcessQuery(cmd);
        }
        catch (Exception ex)
        {
            //throw it back to the form
            throw ex;
        }
        return tbl;

    }
    public DataTable GetAuthorBooks(int authorKey)
    {
        string sql = "SELECT * FROM Book INNER JOIN AuthorBook ON Book.BookKey = AuthorBook.BookKey WHERE AuthorKey = @AuthorKey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        //add a parameter to store the variable from 
        //the drop down list
        cmd.Parameters.Add("@AuthorKey", authorKey);

        DataTable tbl;
        try
        {
            tbl = ProcessQuery(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return tbl;

    }

    private DataTable ProcessQuery(SqlCommand cmd)
    {
        //This method processes the queries
        DataTable table = new DataTable();
        SqlDataReader reader;
        try
        {
            connect.Open();
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return table;
    }
}
