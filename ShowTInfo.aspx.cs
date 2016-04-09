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

public partial class ShowTInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
       

            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                string id = Request.Params["id"];
                ShowInfo(int.Parse(id));
            }
        }


    }
    private void ShowInfo(int id)
    {
        AirTicketWeb.BLL.TInfo bll = new AirTicketWeb.BLL.TInfo();
        AirTicketWeb.Model.TInfo model = bll.GetModel(id);

        this.txtname.Text = model.name;

        this.typeName.Text = model.typeName;

        this.StartT.Text = model.StartT;

        this.ET.Text = model.ET;
        this.txtds.Text = model.Ds;

        this.STime.Text = model.STime;
        this.DanJia.Text = model.DanJia;
        this.ShiJian.Text = model.ShiJian;


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["Users"] == null)
        {
            Maticsoft.DBUtility.js.AlertAndRedirect("Sorry. You need to log in.", "login.aspx");
        }
        else
        {
            string TName = this.txtname.Text;
            int TId = int.Parse(Request.Params["id"].ToString());
            string UserName = Session["Users"].ToString();
            string TNum = TextBox1.Text;

            AirTicketWeb.Model.OrderInfo model = new AirTicketWeb.Model.OrderInfo();
            model.TName = TName;
            model.TId = TId;
            model.UserName = UserName;
            model.TNum = TNum;

            AirTicketWeb.BLL.OrderInfo bll = new AirTicketWeb.BLL.OrderInfo();
            bll.Add(model);
            Maticsoft.DBUtility.js.AlertAndRedirect("Order successful!", "MyOrder.aspx");
        }
    }
    protected void txtname_TextChanged(object sender, EventArgs e)
    {

    }
}
