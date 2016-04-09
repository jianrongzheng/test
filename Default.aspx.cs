using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getTInfoList();
            if (Session["Users"] == null)
            {
                TABLE1.Visible = true;
                table2.Visible = false;
            }
            else
            {
                TABLE1.Visible = false;
                table2.Visible = true;
                MName.Text = Session["Users"].ToString();
            }
        }

    }

}
