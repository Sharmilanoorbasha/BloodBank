<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListAllHospitals.aspx.cs" Inherits="BloodBank.UI.Dashboard.ListAllHospitals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="modal fade" id="SlotsInfoModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitle">Avaliable Slots</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="ModalUpdatePanel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ListView ID="ModalListView" runat="server">
                                <EmptyDataTemplate>
                                    <div class="mt-1 h2 text-center">No Slots Avaliable</div>
                                </EmptyDataTemplate>
                                <LayoutTemplate>
                                    <table class="table" id="itemPlaceHolderContainer" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Slot Time      
                                                </th>
                                            </tr>

                                        </thead>
                                        <tr id="itemPlaceHolder" runat="server">
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>

                                    <tr>
                                        <td><%#DataBinder.Eval(Container,"DataItem.SlotTime") %>           
                                        </td>
                                    </tr>
                                </ItemTemplate>

                            </asp:ListView>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="EditModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Edit Hospital</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="EditHospitalName" runat="server" />
                            <label>Area</label>
                            <asp:TextBox class="form-control mb-2" ID="EditArea" runat="server"></asp:TextBox>
                            <label>City</label>
                            <asp:TextBox class="form-control mb-2" ID="EditCity" runat="server"></asp:TextBox>
                            <label>State</label>
                            <asp:TextBox class="form-control mb-2" ID="EditState" runat="server"></asp:TextBox>
                            <label>Pincode</label>
                            <asp:TextBox class="form-control mb-2" ID="EditPincode" type="number" runat="server"></asp:TextBox>
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
    <div class="container">
        <div class="h4 mt-3 mb-3">Hospital Dashboard :</div>
        <asp:LinkButton class="ml-3 mb-3 lead btn btn-primary" runat="server" Style="cursor: pointer; color: dodgerblue" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight1" aria-controls="offcanvasRight" data-toggle="modal" data-target="#AddHospital">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-plus-square-fill" viewBox="0 0 16 16">
                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3a.5.5 0 0 1 1 0z" />
            </svg>
            <span class="text-light">Add Hospital</span>
        </asp:LinkButton>
        <div class="modal fade" id="AddHospital" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel1">Add New Hospital</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <label>Hospital Name</label>
                        <asp:TextBox class="form-control mb-2" ID="AddHospitalName" runat="server" Type="string"></asp:TextBox>
                        <label>Area</label>
                        <asp:TextBox class="form-control mb-2" ID="AddArea" runat="server" Type="string"></asp:TextBox>
                        <label>City</label>
                        <asp:TextBox class="form-control mb-2" ID="AddCity" runat="server" Type="string"></asp:TextBox>
                        <label>State</label>
                        <asp:TextBox class="form-control mb-2" ID="AddState" runat="server" Type="string"></asp:TextBox>
                        <label>Pincode</label>
                        <asp:TextBox class="form-control " ID="AddPincode" type="number" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="CreateHospital" Class="btn btn-primary" runat="server" Text="Add Hospital" OnClick="CreateHospital_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:ListView ID="HospitalListView" runat="server">
            <EmptyDataTemplate>
                <div class="mt-5 h2 text-center">No Hospitals Added</div>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table" id="itemPlaceHolderContainer" runat="server">
                    <thead>
                        <tr>
                            <th>Hospital Name          
                            </th>
                            <th>Area
                            </th>
                            <th>City
                            </th>
                            <th>State
                            </th>
                            <th>Pincode
                            </th>
                            <th>Slots Info
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
                    <td><%#DataBinder.Eval(Container,"DataItem.HospitalName") %>           
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.Area") %>
                    </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.City") %>           
                    </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.State") %>           
                    </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.Pincode") %>           
                    </td>
                    <td>
                        <!-- Button trigger modal -->
                        <asp:LinkButton ID="SlotsInfoBtn" runat="server" class="btn btn-outline-primary"
                            OnClick="SlotsInfoBtn_Click" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.HospitalName")%>'>
                    Slots info</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton class=" btn btn-primary" ID="EditHospital" OnClick="EditHospital_Click" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.HospitalName")%>'>
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                                <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" />
                            </svg>
                                 
                        </asp:LinkButton>
                        <asp:LinkButton ID="DeleteHospital" class=" ml-2 btn btn-danger" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.HospitalName")%>' OnClick="DeleteHospital_Click">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                                <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z" />
                            </svg>        
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
