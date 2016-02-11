using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Admin_Descriptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            createTable();
        }

        private void createTable()
        {
            //Create table headers
            TableHeaderRow headerRow = new TableHeaderRow();

            TableHeaderCell IDHead = new TableHeaderCell();
            Label IDHeadLabel = new Label();
            IDHeadLabel.Text = "ID";
            IDHead.Controls.Add(IDHeadLabel);

            TableHeaderCell pageHead = new TableHeaderCell();
            Label pageHeadLabel = new Label();
            pageHeadLabel.Text = "Page";
            pageHead.Controls.Add(pageHeadLabel);

            TableHeaderCell descHead = new TableHeaderCell();
            Label descHeadLabel = new Label();
            descHeadLabel.Text = "Description";
            descHead.Controls.Add(descHeadLabel);

            TableHeaderCell activeHead = new TableHeaderCell();
            Label activeHeadLabel = new Label();
            activeHeadLabel.Text = "Active";
            activeHead.Controls.Add(activeHeadLabel);

            TableHeaderCell editHead = new TableHeaderCell();
            Label editHeadLabel = new Label();
            editHeadLabel.Text = "Edit";
            editHead.Controls.Add(editHeadLabel);

            headerRow.Controls.Add(IDHead);
            headerRow.Controls.Add(pageHead);
            headerRow.Controls.Add(descHead);
            headerRow.Controls.Add(activeHead);
            headerRow.Controls.Add(editHead);

            descTable.Controls.Add(headerRow);

            var reader = DbConn.dBRead("EXEC GetDescriptions");
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell IDCell = new TableCell();
                Label IDLabel = new Label();
                IDLabel.Text = "" + reader["ID"];

                TableCell pageCell = new TableCell();
                Label pageLabel = new Label();
                pageLabel.Text = "" + reader["Page"];

                TableCell descCell = new TableCell();
                Label descLabel = new Label();
                descLabel.Text = "" + reader["Description"];

                TableCell activeCell = new TableCell();
                Label activeLabel = new Label();
                activeLabel.Text = "" + reader["Active"];

                Button button = new Button();
                button.ID = Convert.ToString(reader["ID"]);
                button.Text = "Edit";
                button.Click += new EventHandler(editCellMethod);

                TableCell buttonCell = new TableCell();
                buttonCell.Controls.Add(button);

                IDCell.Controls.Add(IDLabel);
                pageCell.Controls.Add(pageLabel);
                descCell.Controls.Add(descLabel);
                activeCell.Controls.Add(activeLabel);

                row.Controls.Add(IDCell);
                row.Controls.Add(pageCell);
                row.Controls.Add(descCell);
                row.Controls.Add(activeCell);
                row.Cells.Add(buttonCell);

                descTable.Controls.Add(row);
            }
        }

        protected void editCellMethod(object sender, EventArgs e)
        {
            string ID = ((Button)sender).ID;
            HttpContext.Current.Session["DID"] = ID;
            Response.Redirect("/Admin_EditDescription.aspx");
        }

    }
}