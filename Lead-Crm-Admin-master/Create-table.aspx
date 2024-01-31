<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Create-table.aspx.cs" Inherits="Hotel_ERP_UI.Create_table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.13.5/css/jquery.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pc-container">
        <div class="pc-content">
            <!-- BreadCrumb Start -->
            <div class="page-header">
                <div class="page-block">
                    <div class="row align-items-center">
                        <div class="col-md-12">
                            <ul class="breadcrumb">
                                <li class="breadcrumb-item"><a href="../navigation/index.html">Home</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0)">Create Table</a></li>
                            </ul>
                        </div>
                        <div class="col-md-12">
                            <div class="page-header-title">
                                <h2 class="mb-0">Create Table</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- BreadCrumb End -->

            <!-- Create Table Code Start -->
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Create Table</h4>
                        </div>
                        <div class="card-body">
                            <div class="row align-items-center">
                                <div class="form-group col-md-3">
                                    <label class="form-label">Client Name</label>
                                    <asp:DropDownList ID="DropDown_clientname" Class="form-control" runat="server" AutoPostBack="false" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDown_clientname" ValidationGroup="Group1" Display="Dynamic" InitialValue="0" ErrorMessage="Select any option" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group col-md-3">
                                    <label class="form-label">Table Name</label>
                                    <asp:TextBox ID="Text_tablename" class="form-control" type="Text" runat="server" placeholder="Enter Table Name" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Text_tablename" ValidationGroup="Group1" Display="Dynamic" ErrorMessage="Field Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group col-md-3">
                                    <label class="form-label">Alias Name</label>
                                    <asp:TextBox ID="Text_aliasname" class="form-control" type="Text" runat="server" placeholder="Enter Table Alias Name" ValidationGroup="Group1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Text_aliasname" ValidationGroup="Group1" Display="Dynamic" ErrorMessage="Field Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group col-md-3">
                                    <label class="form-label">Alias Name</label>
                                    <asp:TextBox ID="Text_url" class="form-control" type="Text" runat="server" placeholder="Enter Table Url" ValidationGroup="Group1" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Text_url" ValidationGroup="Group1" Display="Dynamic" ErrorMessage="Field Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-lg-4">
                                    <asp:Button type="button" ID="ButtonSubmit" runat="server" CssClass="btn btn-light-primary me-2" Text="Submit" OnClick="BtnTable_Create" ValidationGroup="Group1"/>
                                    <asp:Button type="button" ID="ButtonClear" runat="server" CssClass="btn btn-light-secondary" Text="Clear" OnClick="BtnTable_Clear" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Create Table Code End -->

            <!-- DataTable Start -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="table-responsive dt-responsive">
                                <asp:GridView ID="GridView" runat="server" CssClass="tabledata table table-striped table-bordered" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="ClientName" HeaderText="ClientName" SortExpression="ClientName" />
                                        <asp:BoundField DataField="ClientMasterID" HeaderText="ClientMasterID" SortExpression="ClientMasterID" />
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
            $('.tabledata').DataTable();
        });
    </script>
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <%--datatable script end--%>
</asp:Content>
