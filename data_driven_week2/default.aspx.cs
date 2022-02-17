using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace data_driven_week2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection myConn;

            myConn = new SqlConnection();

            String targetConnection = ConfigurationManager.ConnectionStrings["CurrentConnection"].ConnectionString;

            if(targetConnection.Equals("dev"))
            {
                myConn.ConnectionString = AppConstant.DevConnectionString;
            }
            else if(targetConnection.Equals("test"))
            {
                myConn.ConnectionString = AppConstant.TestConnectionString;
            }
            else if (targetConnection.Equals("prod"))
            {
                myConn.ConnectionString = AppConstant.ProdConnectionString;
            }
            else
            {
                throw new Exception();
            }

            myConn.Open();

            SqlCommand myCommand;
            myCommand = new SqlCommand("SELECT * FROM [User]", myConn);

            SqlDataReader myReader;
            myReader = myCommand.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Uid", System.Type.GetType("System.String"));
            dt.Columns.Add("UserName", System.Type.GetType("System.String"));
            dt.Columns.Add("UserLevel", System.Type.GetType("System.String"));

            DataRow myRow;

            while (myReader.Read())
            {
                myRow = dt.NewRow();

                myRow["Uid"] = myReader["UID"].ToString();
                myRow["UserName"] = myReader["UserName"].ToString();
                myRow["UserLevel"] = myReader["UserLevel"].ToString();

                dt.Rows.Add(myRow);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            myConn.Close();

        }
    }
}