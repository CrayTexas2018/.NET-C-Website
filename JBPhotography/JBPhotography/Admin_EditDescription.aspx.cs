using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Admin_EditDescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getInfo();
            }
        }

        private void getInfo()
        {
            var reader = DbConn.dBRead("EXEC GetDescriptionsToEdit " + Session["DID"]);

            if (reader.Read())
            {
                var encoded = HttpUtility.HtmlDecode("" + reader["Description"]);
                DescIDLabel.Text = "Description ID: " + reader["ID"];
                DescNameLabel.Text =  "Page Info: " + reader["MetaData"];
                DescriptionLabel.Text = "" + "Description: ";
                DescriptionTextBox.Text = "" + reader["Description"];
                DescNameTextBox.Text = "" + reader["MetaData"];

                if ((bool)reader["Active"] == true)
                {
                    DescActiveList.SelectedValue = "1";
                }
                else
                {
                    DescActiveList.SelectedValue = "0";
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string metaData = DescNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            string active = DescActiveList.SelectedValue;

            DbConn.dBWrite("EXEC UpdateDescription " + Session["DID"] + ", '" + metaData
                 + "', '" + description + "', " + active);

            Response.Redirect("Admin_Descriptions.aspx");
        }
    }
}