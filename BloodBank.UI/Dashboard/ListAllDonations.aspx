<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListAllDonations.aspx.cs" Inherits="BloodBank.UI.Dashboard.ListAllDonations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="container-fluid">
        <h4 class="my-3">List of All Donations Made!!!</h4>
        <asp:ListView ID="DonationsListView" runat="server" OnItemDataBound="DonationsListView_ItemDataBound">
            <EmptyDataTemplate>
                <div class="mt-1 h2 text-center">No Donations Yet</div>
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
                        <asp:Label ID="DonationHospitalInfo" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="DonationSlotInfo" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton class=" btn btn-primary" ID="OpenDonation" OnClick="OpenDonation_Click" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ReqId")%>'>
                             <span class="">Open</span>     
                        </asp:LinkButton>
                        <asp:LinkButton ID="CloseDonation" class=" ml-2 btn btn-danger" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ReqId")%>' OnClick="CloseDonation_Click">
                             <span class="">Close</span>                                       
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
