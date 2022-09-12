<%@ Page Title="" Language="C#" MasterPageFile="~/Donar.Master" AutoEventWireup="true" CodeBehind="ListAllDonationsForDonar.aspx.cs" Inherits="BloodBank.UI.DonarDashboard.ListAllDonationsForDonar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DonarContent" runat="server">
    <div class="container-fluid">
        <div class="modal fade" id="EditModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Edit Request</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="EditReqId" runat="server" />
                                <label>Patient Name:</label>
                                <asp:TextBox class="form-control mb-2" ID="EditPatientName" runat="server" Type="string"></asp:TextBox>
                                <label>Patient PhoneNo:</label>
                                <asp:TextBox class="form-control mb-2" ID="EditPatientPhoneNo" runat="server" Type="string"></asp:TextBox>
                                <label>Select BloodGroup :</label><br />
                                <asp:DropDownList class="form-control w-100" ID="EditBloodGroup" runat="server">
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                    <asp:ListItem>A+</asp:ListItem>
                                    <asp:ListItem>A-</asp:ListItem>
                                    <asp:ListItem>B+</asp:ListItem>
                                    <asp:ListItem>B-</asp:ListItem>
                                    <asp:ListItem>AB+</asp:ListItem>
                                    <asp:ListItem>AB-</asp:ListItem>
                                </asp:DropDownList>
                                <label>Select Hospital :</label><br />
                                <asp:DropDownList class="form-control w-100" ID="EditHospitalDropDownList" runat="server" OnSelectedIndexChanged="EditHospitalDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />
                                <label>Select Your Slot :</label>
                                <asp:DropDownList class="form-control w-100" ID="EditSlotId" runat="server"></asp:DropDownList><br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="CloseModal" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="SaveEditChanges" class="btn btn-primary" runat="server" Text="Save changes" OnClick="SaveEditChanges_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="h4 mt-3 mb-3">Donar Dashboard :</div>
        <asp:LinkButton class="ml-3 mb-3 lead btn btn-primary" runat="server" Style="cursor: pointer; color: dodgerblue" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight1" aria-controls="offcanvasRight" data-toggle="modal" data-target="#AddBloodReq">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-plus-square-fill" viewBox="0 0 16 16">
                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3a.5.5 0 0 1 1 0z" />
            </svg>
            <span class="text-light">Request Donation</span>
        </asp:LinkButton>

        <div class="modal fade" id="AddBloodReq" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel runat="server" ID="AddReqOuterModal" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel1">New Donation Request</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <label>Patient Name:</label>
                                <asp:TextBox class="form-control mb-2" ID="AddPatientName" runat="server" Type="string"></asp:TextBox>
                                <label>Patient PhoneNo:</label>
                                <asp:TextBox class="form-control mb-2" ID="AddPatientPhoneNo" runat="server" Type="string"></asp:TextBox>
                                <label>Select BloodGroup :</label><br />
                                <asp:DropDownList class="form-control w-100" ID="AddBloodGroup" runat="server">
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                    <asp:ListItem>A+</asp:ListItem>
                                    <asp:ListItem>A-</asp:ListItem>
                                    <asp:ListItem>B+</asp:ListItem>
                                    <asp:ListItem>B-</asp:ListItem>
                                    <asp:ListItem>AB+</asp:ListItem>
                                    <asp:ListItem>AB-</asp:ListItem>
                                </asp:DropDownList>

                                <label>Select Hospital :</label><br />
                                <asp:DropDownList class="form-control w-100" ID="AddHospitalDropDownList" runat="server" OnSelectedIndexChanged="AddHospitalDropDownList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
                                <label>Select Your Slot :</label>
                                <asp:DropDownList class="form-control w-100" ID="AddSlotId" runat="server"></asp:DropDownList><br />

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button ID="CreateBloodReq" Class="btn btn-primary" runat="server" Text="Request" OnClick="CreateBloodReq_Click" />
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
        </div>


        <asp:ListView ID="DonarListView" runat="server" OnItemDataBound="DonarListView_ItemDataBound">
            <EmptyDataTemplate>
                <div class="mt-1 h2 text-center">You haven't made any Requests Yet</div>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table" id="itemPlaceHolderContainer" runat="server">
                    <thead>
                        <tr>
                            <th>Patient Name          
                            </th>
                            <th>Patient PhoneNo
                            </th>
                            <th>Blood Group
                            </th>
                            <th>Status
                            </th>
                            <th>Hospital Info
                            </th>
                            <th>Slot Info
                            </th>
                            <th>Actions
                            </th>
                        </tr>

                    </thead>
                    <tr id="itemPlaceHolder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#DataBinder.Eval(Container,"DataItem.PatientName") %>           
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.PatientPhoneNo") %>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.BloodGroup") %>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.Status") %>
                    </td>
                    <td>
                        <asp:Label ID="DonarHospitalInfo" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="DonarSlotInfo" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton class=" btn btn-primary" ID="EditBloodReq" OnClick="EditBloodReq_Click" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ReqId")%>'>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                                <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" />
                            </svg>
                                 
                        </asp:LinkButton>
                        <asp:LinkButton ID="DeleteBloodReq" class=" ml-2 btn btn-danger" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ReqId")%>' OnClick="DeleteBloodReq_Click">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                                <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z" />
                            </svg>        
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

        <hr class="my-3" />
        <asp:ListView ID="OthersListView" runat="server" OnItemDataBound="OthersListView_ItemDataBound">
            <EmptyDataTemplate>
                <div class="mt-5 h2 text-center">No Data</div>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table" id="itemPlaceHolderContainer" runat="server">
                    <thead>
                        <tr>
                            <th>Patient Name          
                            </th>
                            <th>Patient PhoneNo
                            </th>
                            <th>Blood Group
                            </th>
                            <th>Status
                            </th>
                            <th>Hospital Info
                            </th>
                            <th>Slot Info
                            </th>
                            <th>Actions
                            </th>
                        </tr>

                    </thead>
                    <tr id="itemPlaceHolder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#DataBinder.Eval(Container,"DataItem.PatientName") %>           
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.PatientPhoneNo") %>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.BloodGroup") %>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.Status") %>
                    </td>
                    <td>
                        <asp:Label ID="DonateHospitalInfo" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="DonateSlotInfo" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton class=" btn btn-primary" ID="Donate" OnClick="Donate_Click" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ReqId")%>'>
                            <span class="text-light">Donate</span>     
                        </asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </div>
</asp:Content>
