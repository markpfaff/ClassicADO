using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//add this
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    //declare the AuthorsAndBooks class so it is available
    //to all methods
    AuthorsAndBooks gs = new AuthorsAndBooks();
    protected void Page_Load(object sender, EventArgs e)
    {
        //call the FillDropDownList Method if it is not a postback
        if (!IsPostBack)
            FillDropDownList();
    }
    protected void AuthorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //when the index of the selected item in the
        //drop down box changes call the FillGridViewMethod
        FillGridView();
    }

    protected void FillDropDownList()
    {
        //Declare the dataTabe
        DataTable table = null; ;
        try
        {
            //call the method in the class to fill the table
            table = gs.GetAuthors();
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = ex.Message;
        }
        //Attach the table as a datasource for the 
        //drop down list
        //assign the display and value fields
        AuthorDropDownList.DataSource = table;
        AuthorDropDownList.DataTextField = "AuthorName";
        AuthorDropDownList.DataValueField = "AuthorKey";
        AuthorDropDownList.DataBind();
    }

    protected void FillGridView()
    {
        //Get the value from the drop down list
        //selected value
        int authorKey = int.Parse(AuthorDropDownList.SelectedValue.ToString());
        DataTable tbl = null;
        try
        {
            //call the GetAuthorBooks field and pass 
            //it the service key
            tbl = gs.GetAuthorBooks(authorKey);

        }
        catch (Exception ex)
        {
            ErrorLabel.Text = ex.Message;
        }

        //attach the table as a data source to the
        //gridView
        BooksGridView.DataSource = tbl;
        BooksGridView.DataBind();
    }
}