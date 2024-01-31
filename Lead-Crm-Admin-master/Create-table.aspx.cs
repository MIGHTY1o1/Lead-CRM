using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace Hotel_ERP_UI
{
    public partial class Create_table : System.Web.UI.Page
    {
        compress compressobj = new compress();
        string Url = ConfigurationManager.AppSettings["BaseUrl"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClientData();
            }
        }


        // Method for Bind Client Name
        public async void bindClientData()
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


        // Method For create Table
        protected async void BtnTable_Create(object sender, EventArgs e)
        {
           

            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/AddTable";
                var data = new
                {
                    tableName = Text_tablename.Text.Trim(),
                    clientMasterID = DropDown_clientname.SelectedValue,
                    tablealiasname = Text_aliasname.Text.Trim(),
                    tableurl = Text_url.Text.Trim(),    
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
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>success('Success: " + responseObject.responseMessage + "')</script>", false);

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
                    Text_tablename.Text = Text_aliasname.Text = Text_url.Text = string.Empty;
                    DropDown_clientname.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('An error occurred: " + ex.Message + "')</script>", false);
                }
            }
        }



        // Method is used to Clear add table Input Field
        protected void BtnTable_Clear(object sender, EventArgs e)
        {
            Text_tablename.Text = Text_aliasname.Text = Text_url.Text = string.Empty;
            DropDown_clientname.SelectedIndex = 0;
        }


        // Method for Bind Client Name
        public async void bindDataTable()
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
                            GridView.DataSource = extensionTable;
                            GridView.DataBind();
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