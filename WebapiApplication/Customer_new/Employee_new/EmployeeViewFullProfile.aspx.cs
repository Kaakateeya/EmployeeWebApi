using System;

namespace WebapiApplication.Customer_new.Employee_new
{
    public partial class EmployeeViewFullProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strQuerystring = Request.QueryString["MyProfileQSAccept"].ToString();
            string strRedirect = "http://localhost:63006/commonviewfull?MyProfileQSAccept=" + strQuerystring;
            Response.Redirect(strRedirect);
        }
    }
}