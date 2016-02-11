using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JBPhotography
{
    public partial class Admin_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AdminInfo.checkCredentials(Convert.ToString(HttpContext.Current.Session["ID"])))
            {
                //Response.Redirect("/default.aspx");
            }

            getProducts();
        }

        private void getProducts()
        {
            var reader = DbConn.dBRead("Exec SelectProducts");
            ProductTable.GridLines = GridLines.Both;
            TableRow headerRow = new TableRow();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                TableCell headerCell = new TableCell();
                headerCell.Controls.Add(new LiteralControl(Convert.ToString(reader.GetName(i))));
                headerRow.Cells.Add(headerCell);
            }
            TableCell editCell = new TableCell();
            editCell.Controls.Add((new LiteralControl("Edit")));
            headerRow.Cells.Add(editCell);

            ProductTable.Rows.Add(headerRow);

            int count = 1;
            while (reader.Read())
            {
                TableRow row = new TableRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Controls.Add(new LiteralControl(Convert.ToString(reader.GetValue(i))));
                    row.Cells.Add(cell);
                }
                Button button = new Button();
                
                button.ID = Convert.ToString(reader["ID"]);
                button.Text = "Edit";
                button.Click += new EventHandler(editCellMethod);

                TableCell buttonCell = new TableCell();
                buttonCell.Controls.Add(button);
                row.Cells.Add(buttonCell);

                ProductTable.Rows.Add(row);
                count++;
            }
        }

        protected void editCellMethod(object sender, EventArgs e)
        {
            string ID = ((Button)sender).ID;
            HttpContext.Current.Session["PID"] = ID;
            Response.Redirect("/EditProduct.aspx");
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddProduct.aspx");
        }
    }
}