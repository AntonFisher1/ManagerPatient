<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ManagePatient._Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="gvDatas" runat="server" ShowFooter="true"
        AutoGenerateColumns="False" DataKeyNames="Id" OnRowCancelingEdit="onCancelEdit" OnRowDeleting="onPatientDelete" OnRowEditing="onPatientEdit" OnRowUpdating="onPatientUpdate">
        <Columns>
            <asp:TemplateField HeaderText="First Name">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lbbFirstName" Text='<%#Bind("FirstName") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtFirstName" Text='<%#Bind("FirstName") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtAddFirstName" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lbbLastName" Text='<%#Bind("LastName") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtLastName" Text='<%#Bind("LastName") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtAddLastName" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lbbPhone" Text='<%#Bind("Phone") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtPhone" Text='<%#Bind("Phone") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtAddPhone" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lbbEmail" Text='<%#Bind("Email") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtEmail" Text='<%#Bind("Email") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtAddEmail" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Notes">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lbbNotes" Text='<%#Bind("Notes") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="txtNotes" Text='<%#Bind("Notes") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox runat="server" ID="txtAddNotes" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table align="center">
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit"
                                    AlternateText="Edit" />
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" AlternateText="Delete" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="50px" />
                <EditItemTemplate>
                    <table align="center">
                        <tr>
                            <td width="17" align="center">
                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update"
                                    AlternateText="Update" ValidationGroup="Update" />
                            </td>
                            <td width="17" align="center">
                                <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel"
                                    AlternateText="Cancel" />
                            </td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <FooterTemplate>
                    <table align="center">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnAdd" runat="server"
                                    AlternateText="Add" ValidationGroup="Add" onClick="onAddPatient"/>
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
