using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_ERP_UI
{

    public class ResponseClientDetail
    {
        public int ClientMasterID { get; set; }
        public string ClientName { get; set; }
    }

    public class ResponseDataTyp
    {
        public int DataTypeID { get; set; }
        public string DataName { get; set; }
    }

    public class ResponseTable
    {
        public int ExtensionTableID { get; set; }
        public int ExtensionTableCode { get; set; }
        public string ExtensionTableName { get; set; }
    }

    public class ResponseClass
    {
        public int responseCode { get; set; }
        public string responseDynamic { get; set; }
        public string responseMessage { get; set; }
    }

    public class Userdata
    {
        public string UserDisplayName { get; set; }
        public string UserID { get; set; }
        public string AppAccessTypeID { get; set; }
    }
    public class ResponseColumnName
    {
        public string ExtensionTableCode { get; set; }
        public string ExtensionTableName { get; set; }
        public string InputDataType { get; set; }
        public string FieldName { get; set; }
        public string DisplayName { get; set; }
    }
}