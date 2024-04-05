// Default.aspx.cs

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load the sales bills on page load
            LoadSalesBills();
        }
    }

    private void LoadSalesBills()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT SaleID, BillDate, CustomerName FROM Sales_Head";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable salesTable = new DataTable();
            adapter.Fill(salesTable);

            gvSalesBills.DataSource = salesTable;
            gvSalesBills.DataBind();
        }
    }

    protected void btnAddSale_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddSale.aspx");
    }

    protected void gvSalesBills_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewSale")
        {
            int saleID = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ViewSale.aspx?SaleID=" + saleID);
        }
    }
}