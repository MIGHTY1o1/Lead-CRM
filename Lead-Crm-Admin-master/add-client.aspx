<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="add-client.aspx.cs" Inherits="Hotel_ERP_UI.add_client" %>

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
                                <li class="breadcrumb-item"><a href="javascript: void(0)">Add Client</a></li>
                            </ul>
                        </div>
                        <div class="col-md-12">
                            <div class="page-header-title">
                                <h2 class="mb-0">Add Client</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- BreadCrumb End -->

         
            <!-- Form Start -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h5>Add New Client</h5>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-lg-4">
                                    <label class="form-label">Name:</label>
                                    <asp:TextBox ID="Text_clientname" class="form-control" type="Text" runat="server" placeholder="Enter Client Name"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <label class="form-label">Phone Number:</label>
                                    <asp:TextBox ID="TextBox_clientphone" class="form-control" type="number" runat="server" placeholder="Enter Client Phone No"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <label class="form-label">Email ID:</label>
                                    <asp:TextBox ID="TextBox_clientemail" class="form-control" type="email" runat="server" placeholder="Enter Client Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="card-footer bg-white border-0">
                            <asp:Button type="button" ID="ButtonSubmit" runat="server" CssClass="btn btn-light-primary me-2" Text="Submit" OnClick="BtnClient_Create" />
                            <asp:Button type="button" ID="ButtonClear" runat="server" CssClass="btn btn-light-secondary" Text="Clear" OnClick="BtnClient_Clear" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Form End -->

            <!-- DataTable Start -->
            <div class="row">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body">
                            <%--<div class="pb---20">
                                Toggle column: <a class="toggle-vis toggle-anchor" data-column="0">UserID</a> - <a class="toggle-vis toggle-anchor" data-column="1">ClientMasterID</a> - <a class="toggle-vis toggle-anchor" data-column="2">UserDisplayName</a>
                                - <a class="toggle-vis toggle-anchor" data-column="3">UserName</a> - <a class="toggle-vis toggle-anchor" data-column="4">Password</a> - <a class="toggle-vis toggle-anchor" data-column="5">InsertedTime</a>
                            </div>--%>
                            <div class="table-responsive dt-responsive">
                                <asp:GridView ID="GridView" runat="server" CssClass="clientdetail table table-striped table-bordered" Width="100%" AutoGenerateColumns="false" OnRowDeleting="GridView_RowDeleting" OnRowUpdating="GridView_RowUpdating" DataKeyNames="ClientMasterID">
                                    <Columns>
                                        <asp:BoundField DataField="ClientMasterID" HeaderText="ClientMasterID" SortExpression="ClientMasterID" />
                                        <asp:BoundField DataField="ClientName" HeaderText="ClientName" SortExpression="ClientName" />
                                        <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" SortExpression="MobileNumber" />
                                        <asp:BoundField DataField="EmailID" HeaderText="EmailID" SortExpression="EmailID" />
                                        <asp:BoundField DataField="ActiveStatus" HeaderText="ActiveStatus" SortExpression="ActiveStatus" />

                                        <%--<asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Button ID="btnChangeStatus" runat="server" OnClick="ChangeStatus" Text='<%# Eval("ActiveStatus").ToString() == "YES" ? "Active" : "De Activate"  %>' CssClass='<%# Eval("ActiveStatus").ToString() == "YES" ? "status-active" : "status-deactive" %>' />

                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="BtnViewReport" CssClass="me-2" runat="server" CommandName="View" CommandArgument='<%# Eval("ClientMasterID")%>' data-bs-toggle="tooltip" data-bs-placement="bottom" title="Edit"><i class="fa-solid fa-pen-nib"></i></asp:LinkButton>                                      
                                                <asp:LinkButton ID="Button_invoice"  runat="server" CommandName="Update" CommandArgument='<%# Eval("ClientMasterID")%>' data-bs-toggle="tooltip" data-bs-placement="bottom" title="Update"><i class="fa-solid fa-trash-can"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
    <script type="text/javascript">
        $(document).ready(function () {
            // DataTable with buttons
            var table = $(".clientdetail").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'excel', 'pdf', 'print'
                ]
            });

            // Toggle column visibility on anchor click
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
