<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Create-Column.aspx.cs" Inherits="Hotel_ERP_UI.Create_Column" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.13.5/css/jquery.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pc-container">
        <div class="pc-content">
            <div class="page-header">
                <!-- BreadCrumb Start -->
                <div class="page-block">
                    <div class="row align-items-center">
                        <div class="col-md-12">
                            <ul class="breadcrumb">
                                <li class="breadcrumb-item"><a href="../navigation/index.html">Home</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0)">Create Column</a></li>
                            </ul>
                        </div>
                        <div class="col-md-12">
                            <div class="page-header-title">
                                <h2 class="mb-0">Create Columns</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- BreadCrumb End -->

            <!-- Create Column Code Start -->
            <div class="card">
                <div class="card-header">
                    <h5>Create Column</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="form-group col-md-3">
                            <label class="form-label">Client Name</label>
                            <asp:DropDownList ID="DropDown_client" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDown_client_SelectedIndexChanged" ValidationGroup="Group1"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDown_client" ValidationGroup="Group1" Display="Dynamic" InitialValue="0" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3" id="tablename" runat="server">
                            <label class="form-label">Table Name</label>
                            <asp:DropDownList ID="DropDown_tablename" Class="form-control" runat="server" AutoPostBack="false"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDown_tablename" ValidationGroup="Group1" Display="Dynamic" InitialValue="0" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="form-label">Field Name</label>
                            <asp:TextBox ID="Text_table_name" class="form-control" type="Text" runat="server" placeholder="Enter Field Name" ValidationGroup="Group1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Text_table_name" ValidationGroup="Group1" Display="Dynamic" ErrorMessage="Field Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3">
                            <label class="form-label">Display Name</label>
                            <asp:TextBox ID="Text_dname" class="form-control" type="Text" runat="server" placeholder="Enter Display Name" ValidationGroup="Group1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Text_dname" ValidationGroup="Group1" Display="Dynamic" ErrorMessage="Display Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-2">
                            <label class="form-label">Data Type</label>
                            <asp:DropDownList ID="DropDown_datatype" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDown_datatype_SelectedIndexChanged" Required="true" ValidationGroup="Group1"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDown_datatype" ValidationGroup="Group1" Display="Dynamic" InitialValue="0" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-2" id="datatype_length" runat="server">
                            <label class="form-label">Length</label>
                            <asp:TextBox ID="TextBox_length" class="form-control" type="Text" runat="server" placeholder="Enter Length" ValidationGroup="Group1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox_length" ValidationGroup="Group1" Display="Dynamic" ErrorMessage="Length is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-2">
                            <label class="form-label">Is Reference</label>
                            <asp:DropDownList ID="DropDown_reference" runat="server" CssClass="form-select" Required="true"
                                AutoPostBack="true" OnSelectedIndexChanged="DropDown_reference_SelectedIndexChanged" ValidationGroup="Group1">
                                <asp:ListItem Value="-1" Text="--select--" Selected="true" disabled="disabled"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDown_reference" ValidationGroup="Group1" Display="Dynamic" InitialValue="-1" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3" runat="server" id="referenceTable">
                            <label class="form-label">Reference Table Name</label>
                            <asp:DropDownList ID="DropDown_reftable" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDown_referencetable_SelectedIndexChanged" ValidationGroup="Group1"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDown_reftable" ValidationGroup="Group1" Display="Dynamic" InitialValue="0" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-3" runat="server" id="referenceField">
                            <label class="form-label">Reference Field Name</label>
                            <asp:DropDownList ID="DropDown_reffield" Class="form-control" runat="server" AutoPostBack="false" ValidationGroup="Group1"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDown_reffield" ValidationGroup="Group1" Display="Dynamic" InitialValue="0" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-2">
                            <label class="form-label">Is Required</label>
                            <asp:DropDownList ID="DropDown_required" runat="server" CssClass="form-select" Required="true"
                                AutoPostBack="true" ValidationGroup="Group1">
                                <asp:ListItem Value="-1" Text="--select--" Selected="true" disabled="disabled"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDown_required" ValidationGroup="Group1" Display="Dynamic" InitialValue="-1" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-2">
                            <label class="form-label">Is Unique</label>
                            <asp:DropDownList ID="DropDown_unique" Class="form-control" runat="server" AutoPostBack="false" required="true" ValidationGroup="Group1">
                                <asp:ListItem Value="-1" Text="--select--" Selected="true" disabled="disabled"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDown_unique" ValidationGroup="Group1" Display="Dynamic" InitialValue="-1" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="card-footer text-center bg-light border-0">
                    <asp:Button type="button" ID="BtnColSubmit" runat="server" CssClass="btn btn-light-primary me-2" Text="Save" OnClick="BtnColumn_Save" ValidationGroup="Group1" />
                    <asp:Button type="button" ID="BtnClear" runat="server" CssClass="btn btn-light-secondary" Text="Clear" OnClick="BtnColumn_Clear" />
                </div>
            </div>
            <!-- Create Column Code Start -->


            <!-- DataTable Start -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body">
                            <div>
                                Toggle column :  <a class="toggle-vis toggle-anchor" data-column="0">ClientMasterID</a> - <a class="toggle-vis toggle-anchor" data-column="1">ClientName</a> - <a class="toggle-vis toggle-anchor" data-column="2">Action</a> 
                            </div>
                            <div class="table-responsive dt-responsive">
                                <asp:GridView ID="GridView" runat="server" CssClass="tabledetail table table-striped table-bordered display" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                       <%-- <asp:BoundField DataField="ClientMasterID" HeaderText="ClientMasterID" SortExpression="ClientMasterID" />
                                        <asp:BoundField DataField="ClientName" HeaderText="ClientName" SortExpression="ClientName" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="BtnViewReport" CssClass="me-2" runat="server" CommandName="View" CommandArgument='<%# Eval("ClientMasterID")%>' data-bs-toggle="tooltip" data-bs-placement="bottom" title="Edit"><i class="fa-solid fa-pen-nib"></i></asp:LinkButton>
                                                <asp:LinkButton ID="Button_invoice" runat="server" CommandName="Update" CommandArgument='<%# Eval("ClientMasterID")%>' data-bs-toggle="tooltip" data-bs-placement="bottom" title="Update"><i class="fa-solid fa-trash-can"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- DataTable End -->

        </div>
    </div>


    <%--datatable script start--%>
    <script>
        $(document).ready(function () {
            var table = $(".tabledetail").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();


            $('a.toggle-vis').on('click', function (e) {
                e.preventDefault();

                // Get the column API object
                var column = table.column($(this).attr('data-column'));

                // Toggle the visibility
                column.visible(!column.visible());
            });
        });
    </script>
    <%--datatable script end--%>
</asp:Content>
