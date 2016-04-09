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


    protected void Button1_Click(object sender, EventArgs e)
    {
        AirTicketWeb.BLL.Member login = new AirTicketWeb.BLL.Member();
        if (login.UserLogin(txtMName.Text, txtMPwd.Text))
        {
            Session["Users"] = txtMName.Text;

            TABLE1.Visible = false;
            table2.Visible = true;
            MName.Text = txtMName.Text;
        }
        else
        {
            TABLE1.Visible = true;
            table2.Visible = false;
            Label1.Text = "Error.Please be aware that your ID/Password are case sensitive.Please check and re-enter.";
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {

        Session["Users"] = null;
        Session.Abandon();
        Session.Clear();

        TABLE1.Visible = true;
        table2.Visible = false;
    }
    private void getTInfoList()
    {
        try
        {
            DataSet ds = new DataSet();

            AirTicketWeb.BLL.TInfo GetTInfo = new AirTicketWeb.BLL.TInfo();
            ds = GetTInfo.GetAllList();

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = ds.Tables[0].DefaultView;

            objPds.AllowPaging = true;
            objPds.PageSize = 12;

            int CurPage;
            if (Request.QueryString["Page"] != null)
                CurPage = Convert.ToInt32(Request.QueryString["Page"]);
            else
                CurPage = 1;

            objPds.CurrentPageIndex = CurPage - 1;
            lblCurrentPage.Text = CurPage.ToString();
            lblSumPage.Text = objPds.PageCount.ToString();

            DataList1.DataSource = objPds;
            DataList1.DataBind();


        }
        catch
        {

        }

    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}
