using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_ERP_UI
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string responseData = Request.Cookies["ResponseAdminData"]?.Value;

                if (!string.IsNullOrEmpty(responseData))
                {
                    var userdataList = JsonConvert.DeserializeObject<List<Userdata>>(responseData);

                    if (userdataList.Count > 0)
                    {
                        String Username = userdataList[0].UserDisplayName;
                        String UserID = userdataList[0].UserID.ToString();
                        String AppAccessTypeID = userdataList[0].AppAccessTypeID.ToString();
                        Label_username.Text = Label_uname.Text = Username;
                        Response.Cookies["userid"].Value = UserID;
                    }
                }
                else
                {
                    string script = "alert('Please Login First !'); window.location.href = 'Login.aspx';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                }
            }
        }


        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            // Clear all cookies
            if (Request.Cookies != null)
            {
                foreach (string cookie in Request.Cookies.AllKeys)
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
            }            
            Response.Redirect("Login.aspx");          // Redirect to another page
        }
    }    
}