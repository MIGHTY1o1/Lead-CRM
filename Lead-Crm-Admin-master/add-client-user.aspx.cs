using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_ERP_UI
{
    public partial class add_client_user : System.Web.UI.Page
    {
        compress compressobj = new compress();
        string Url = ConfigurationManager.AppSettings["BaseUrl"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindclientname();
               // bindDataTable();
            }
        }


        // Method for Bind Client Name
        public async void bindclientname()
        {
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/GetMasterDataBinding";
                var data = new
                {
                    action = "CLNTMAS",
                    searchText = "",
                    filterID = "0",
                    filterID1 = "0",
                    filterID2 = "",
                    filterID3 = "",
                    searchCriteria = "",
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
                            var extensionTable = JsonConvert.DeserializeObject<List<ResponseClientDetail>>(unzippedResponse);
                            DropDown_clientname.DataSource = extensionTable;
                            DropDown_clientname.DataTextField = "ClientName";
                            DropDown_clientname.DataValueField = "ClientMasterID";
                            DropDown_clientname.DataBind();
                            DropDown_clientname.Items.Insert(0, new ListItem("--Select--", "0") { Selected = true });
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



        // Method is use to Add New Client
        protected async void BtnClientUser_Create(object sender, EventArgs e)
        {
            try
            {
                if (DropDown_clientname.SelectedIndex == 0)
                {
                    label_error.Text = "Please select a value.";
                    label_error.Visible = true;
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }

            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/AddClientUser";
                var data = new
                {
                    clientMasterID = DropDown_clientname.SelectedValue,
                    userDisplayName = TextBox_displayname.Text.Trim(),
                    appAccessUserName = TextBox_username.Text.Trim(),
                    appAccessPWD = TextBox_userpwd.Text.Trim(),
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
                    DropDown_clientname.SelectedIndex = 0;
                    TextBox_displayname.Text = TextBox_username.Text = TextBox_userpwd.Text = string.Empty;
                    label_error.Visible = true;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('An error occurred: " + ex.Message + "')</script>", false);
                }
            }
        }


        //Method is used to clear Text Field Data
        protected void Btn_Clear(object sender, EventArgs e)
        {
            DropDown_clientname.SelectedIndex = 0;
            TextBox_displayname.Text = TextBox_username.Text = TextBox_userpwd.Text = string.Empty;
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
                    tableName = "client_user_details",
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


        protected  void ChangeStatus(object sender, EventArgs e)
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