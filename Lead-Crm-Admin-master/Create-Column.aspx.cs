using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_ERP_UI
{
    public partial class Create_Column : System.Web.UI.Page
    {
        compress compressobj = new compress();
        string Url = ConfigurationManager.AppSettings["BaseUrl"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {

                referenceTable.Visible = false;
                referenceField.Visible = false;
                datatype_length.Visible = false;
                tablename.Visible = false;
                bindClientData();
                bindDatatype();
                bindDataTable();
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
                            DropDown_client.DataSource = extensionTable;
                            DropDown_client.DataTextField = "ClientName";
                            DropDown_client.DataValueField = "ClientMasterID";
                            DropDown_client.DataBind();
                            DropDown_client.Items.Insert(0, new ListItem("--Select--", "0") { Selected = true });
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


        // Method for Bind Table Name
        public async void bindtablename()
        {
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/GetMasterDataBinding";
                string ClientMasterID = DropDown_client.SelectedValue;

                var data = new
                {
                    action = "TABMAS",
                    searchText = "",
                    filterID = ClientMasterID,
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
                            var extensionTable = JsonConvert.DeserializeObject<List<ResponseTable>>(unzippedResponse);
                            DropDown_tablename.DataSource = extensionTable;
                            DropDown_tablename.DataTextField = "ExtensionTableName";
                            DropDown_tablename.DataValueField = "ExtensionTableCode";
                            DropDown_tablename.DataBind();
                            DropDown_tablename.Items.Insert(0, new ListItem("--Select--", "0") { Selected = true });
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

        // Method for Bind Column Name Acc. to table name
        public async void bindColumnName(string tablecode)
        {
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/GetMasterDataBinding";
                string tableCode = tablecode;
                var data = new
                {
                    action = "COLMAS",
                    searchText = "",
                    filterID = tableCode,
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
                            var extensionTable = JsonConvert.DeserializeObject<List<ResponseColumnName>>(unzippedResponse);
                            DropDown_reffield.DataSource = extensionTable;
                            DropDown_reffield.DataTextField = "FieldName";
                            DropDown_reffield.DataValueField = "FieldName";
                            DropDown_reffield.DataBind();
                            DropDown_reffield.Items.Insert(0, new ListItem("--Select--", "0") { Selected = true });
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


        // Method for bind table name when IsReference = "Yes"
        public async void bindReferencetablename()
        { 
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/GetMasterDataBinding";
                string ClientMasterID = DropDown_client.SelectedValue;

                var data = new
                {
                    action = "TABMAS",
                    searchText = "",
                    filterID = ClientMasterID,
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
                            var extensionTable = JsonConvert.DeserializeObject<List<ResponseTable>>(unzippedResponse);
                            DropDown_reftable.DataSource = extensionTable;
                            DropDown_reftable.DataTextField = "ExtensionTableName";
                            DropDown_reftable.DataValueField = "ExtensionTableCode";
                            DropDown_reftable.DataBind();
                            DropDown_reftable.Items.Insert(0, new ListItem("--Select--", "0") { Selected = true });
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('Error: " + responseObject.responseMessage + "')</script>", false);
                            DropDown_reference.SelectedIndex = -1;
                            referenceTable.Visible = false;
                            referenceField.Visible = false;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('Request failed with status code: " + response.StatusCode + "')</script>", false);
                        DropDown_reference.SelectedIndex = -1;
                        referenceTable.Visible = false;
                        referenceField.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('An error occurred: " + ex.Message + "')</script>", false);
                    DropDown_reference.SelectedIndex = -1;
                    referenceTable.Visible = false;
                    referenceField.Visible = false;
                }
            }

        }


        // Method is used to bind Datatype
        public async void bindDatatype()
        {
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/GetMasterDataBinding";
                var data = new
                {
                    action = "DATATYP",
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
                            var extensionTable = JsonConvert.DeserializeObject<List<ResponseDataTyp>>(unzippedResponse);
                            DropDown_datatype.DataSource = extensionTable;
                            DropDown_datatype.DataTextField = "DataName";
                            DropDown_datatype.DataValueField = "DataTypeID";
                            DropDown_datatype.DataBind();
                            DropDown_datatype.Items.Insert(0, new ListItem("--Select--", "0") { Selected = true });
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


        // Method is used when clear button click.
        protected void BtnColumn_Clear(object sender, EventArgs e)
        {
            InputFieldDataClear();            
        }

        // Method is used to Clear add column Input Field
        public void InputFieldDataClear()
        {
            Text_table_name.Text = Text_dname.Text = String.Empty;
            if (DropDown_tablename.Items.Count > 0)
                DropDown_tablename.SelectedIndex = 0;

            if (DropDown_reference.Items.Count > 0)
                DropDown_reference.SelectedIndex = -1;

            if (DropDown_required.SelectedIndex > 0)
                DropDown_required.SelectedValue = "-1";

            if (DropDown_unique.Items.Count > 0)
                DropDown_unique.SelectedValue = "-1";

            if (DropDown_datatype.Items.Count > 0)
                DropDown_datatype.SelectedIndex = 0;

            if (DropDown_client.Items.Count > 0)
                DropDown_client.SelectedIndex = 0;

            tablename.Visible = datatype_length.Visible = referenceTable.Visible = referenceField.Visible = false;
        }



        // Method is Used to save Column in selected Table.
        protected async void BtnColumn_Save(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                string UserID = Request.Cookies["userid"]?.Value;
                string ipAddress = Request.UserHostAddress;
                var apiUrl = Url + "ERP/Setup/AddColumn";
                string TempMaxlength = "";
                string TempReftable = "";
                string TempRefField = "";

                if (DropDown_datatype.SelectedItem.Text == "Text")
                {
                    TempMaxlength = TextBox_length.Text;
                }
                else
                {
                    TempMaxlength = "0";
                }
                if (!string.IsNullOrEmpty( DropDown_reftable.Text) && DropDown_reference.SelectedValue == "1")
                {
                    TempReftable = DropDown_reftable.SelectedItem.Text;
                }
                else
                {
                    TempReftable = "";
                }
                if (!string.IsNullOrEmpty(DropDown_reffield.Text) && DropDown_reference.SelectedValue == "1") 
                {
                    TempRefField = DropDown_reffield.SelectedItem.Text;
                }
                else
                {
                    TempRefField = "";
                }

                var data = new
                {
                    extensionTableCode = DropDown_tablename.SelectedValue,
                    extensionTableName = DropDown_tablename.SelectedItem.Text,
                    fieldName = Text_table_name.Text,
                    displayName = Text_dname.Text,
                    controlType = "0",
                    inputDataType = DropDown_datatype.SelectedValue,                    
                    validate_MaxLength = TempMaxlength,
                    validate_isRequired = DropDown_required.SelectedValue,
                    validate_isUnique = DropDown_unique.SelectedValue,
                    validate_isReference = DropDown_reference.SelectedValue,
                    referenceTableName = TempReftable,
                    referenceFieldName = TempRefField,
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
                            var result = unzippedResponse;
                            InputFieldDataClear();
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
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('An error occurred: " + ex.Message + "')</script>", false);
                }
            }
        }


        // this code run when dropdown IS reference index change
        protected void DropDown_reference_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDown_reference.SelectedValue == "1")
            {
                referenceTable.Visible = true;
                referenceField.Visible = true;
                bindReferencetablename();
            }

            else
            {
                referenceTable.Visible = false;
                referenceField.Visible = false;
            }
        }

        // this code run when dropdown reference table column index change
        protected void DropDown_referencetable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tablecode = DropDown_reftable.SelectedValue;
            bindColumnName(tablecode);
        }


        // this code run when dropdown datatype index change
        protected void DropDown_datatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDown_datatype.SelectedItem.Text == "Text")
            {
                datatype_length.Visible = true;
            }

            else
            {
                datatype_length.Visible = false;
            }
        }


        // this code run when dropdown Client index change
        protected void DropDown_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDown_client.SelectedItem.Value != "0")
            {
                tablename.Visible = true;
                bindtablename();
            }

            else
            {
                tablename.Visible = false;
            }
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
    }
}