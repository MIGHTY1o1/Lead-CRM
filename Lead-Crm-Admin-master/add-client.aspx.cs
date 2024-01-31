using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Data;

namespace Hotel_ERP_UI
{
    public partial class add_client : System.Web.UI.Page
    {
        compress compressobj = new compress();
        string Url = ConfigurationManager.AppSettings["BaseUrl"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // bindDataTable();
            }
        }

        // Method is use to Add New Client
        protected async void BtnClient_Create(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/AddClient";
                var data = new
                {
                    clientName = Text_clientname.Text.Trim(),
                    mobileNumber = TextBox_clientphone.Text.Trim(),
                    emailID = TextBox_clientemail.Text.Trim(),
                    objCommon = new
                    {
                        insertedUserID = UserID,
                        insertedIPAddress = ipAddress,
                        dateShort = "dd-MM-yyyy",
                        dateLong = "dd-MM-yyyy- HH:mm:ss"
                    }
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
                            var clientData = unzippedResponse;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>success('Message: " + responseObject.responseMessage + "')</script>", false);

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
                    Text_clientname.Text = TextBox_clientphone.Text = TextBox_clientemail.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('An error occurred: " + ex.Message + "')</script>", false);
                }
            }
        }


        //Method is used to clear Text Field Data
        protected void BtnClient_Clear(object sender, EventArgs e)
        {
            Text_clientname.Text = TextBox_clientphone.Text = TextBox_clientemail.Text = string.Empty;
        }


        // Method for Bind Client Name
        public async void bindDataTable()
        {
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/Execute";
                var data = new
                {
                    tableName = "client_master",
                    action = "SELECT",
                    primaryColumn = "string",
                    primarydatatype = "string",
                    primaryColumnValue = "string",
                    columns = new[]
                    {
                        new
                        {
                           columnName = "string",
                           columnValue = "string",
                           columnDataType = 0
                        }
                    },
                    objCommon = new
                    {
                        insertedUserID = UserID,
                        insertedIPAddress = ipAddress,
                        dateShort = "dd-MM-yyyy",
                        dateLong = "dd-MM-yyyy- HH:mm:ss"
                    }
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
                            DataTable dt = JsonConvert.DeserializeObject<DataTable>(unzippedResponse);
                            if (dt.Rows.Count > 0)
                            {
                                GridView.DataSource = dt;
                                GridView.DataBind();
                            }
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

        // Row Deleteing Command 
        protected async void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)GridView.Rows[e.RowIndex].FindControl("LinkButton_Delete")).CommandArgument);
            string action = "DELETE";
            using (var httpClient = new HttpClient())
            {
                string tableName = Session["tableName"] as string;
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/Execute";
                var data = new
                {
                    tableName = tableName,
                    action = action,
                    id = id,
                    primaryColumn = "string",
                    primarydatatype = "string",
                    primaryColumnValue = "string",
                    columns = new[]
                    {
                        new
                        {
                           columnName = "string",
                           columnValue = "string",
                           columnDataType = 0
                        }
                    },
                    objCommon = new
                    {
                        insertedUserID = UserID,
                        insertedIPAddress = ipAddress,
                        dateShort = "dd-MM-yyyy",
                        dateLong = "dd-MM-yyyy- HH:mm:ss"
                    }
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
                            DataTable dt = JsonConvert.DeserializeObject<DataTable>(unzippedResponse);
                            if (dt.Rows.Count > 0)
                            {
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
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('An error occurred: " + ex.Message + "')</script>", false);
                }
            }

        }

        // Row Updating Command
        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(((LinkButton)GridView.Rows[e.RowIndex].FindControl("LinkButton_Update")).CommandArgument);
        }

        // Method for change active/ deactive status.
        protected void ChangeStatus(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(this.GridView.DataKeys[row.RowIndex].Value);

            int StatusValue;
            if (btn.Text == "Active")
            {
                StatusValue = 0;
                // btn.Text = "De Active";
                // btn.CssClass = "status-active";
            }
            else
            {
                StatusValue = 1;
                // btn.Text = "Active";
                // btn.CssClass = "status-deactive";
            }

        }
    }
}