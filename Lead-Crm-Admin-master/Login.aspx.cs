using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Configuration;

namespace Hotel_ERP_UI
{
    public partial class Login : System.Web.UI.Page
    {
        compress compressobj = new compress();                                   // Compress Class Object
        string Url = ConfigurationManager.AppSettings["BaseUrl"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void BtnLogin_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/ERPLogin";
                var data = new
                {
                    loginUID = Text_useremail.Text.Trim(),
                    loginPWD = Text_password.Text.Trim(),
                };

                try
                {
                    var jsondata = JsonConvert.SerializeObject(data);
                    var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<ResponseClass>(responseContent);
                        if (responseObject.responseCode == 1)
                        {
                            var unzippedResponse = compressobj.Unzip(responseObject.responseDynamic);
                            Response.Cookies["ResponseAdminData"].Value = unzippedResponse;
                            Response.Redirect("dashboard.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('Error: " + responseObject.responseMessage + "')</script>", false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('Request failed with status code: " + response.StatusCode + "')</script>", false);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('An error occurred: " + ex.Message + "')</script>", false);
                }
            }
        }
    }
}