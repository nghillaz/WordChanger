<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WordChanger._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div align="center">
            <h1>
                <asp:Label ID="title" runat="server" Text="Word Changer" Font-Size="Larger" Font-Names="Impact"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div align="left">
                <h2>
                    <asp:Label ID="inputLb" runat="server" Text="Input Text" Font-Names="Impact"></asp:Label>
                </h2>
            </div>
            <div style="width:100%; white-space:nowrap">
                <asp:TextBox ID="inputBox"
                    Wrap ="true"
                    runat="server" 
                    BorderStyle="Ridge" 
                    TextMode="MultiLine" 
                    BorderColor="Black" Font-Size="16pt" 
                    style="width:100%; resize:none"
                    EnableViewState="False" ToolTip="putchyowords here"></asp:TextBox>
            </div>
            
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="Submit_Button" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40px" Width="85px" />
        </div>
        <div class="col-md-5">
            <h2>
                <asp:Label ID="outputLb" runat="server" Text="Output Text" Font-Names="Impact"></asp:Label>
            </h2>
            <asp:Panel ID="dropDownPanel" runat="server" EnableViewState="true">
            </asp:Panel>
            <p>
                <p id="dropDownPar" runat = "server" >
           </p>
                <asp:Button ID="getFinal" runat="server" Text="Get Final" OnClick="Final_Button" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
            </p>
        </div>
        <div class="col-md-3">
            <div align="center">
                <h2>
                    <asp:Label ID="settingsLb" runat="server" Text="Output Options" Font-Names="Impact"></asp:Label>
                </h2>
                <p>
                    <asp:Button ID="userSelection" runat="server" Text="User Selection" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="105"/>
                    <br />
                    <br />
                    <asp:Button ID="lengthen" runat="server" Text="Lengthen" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
                    <br />
                    <br />
                    <asp:Button ID="shorten" runat="server" Text="Shorten" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
                    <br />
                    <br />
                    <asp:Button ID="randomize" runat="server" Text="Randomize" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
                    <br />
                    <br />
                    <asp:Button ID="Reset" runat="server" Text="Reset" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
