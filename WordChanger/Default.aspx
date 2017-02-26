<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WordChanger._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div align="center">
            <h1 style="vertical-align: middle">
                &nbsp;<img src="Switchasaurus.png" style="width: 704px; height: 108px" /></h1>
        </div>
    </div>
    <asp:Panel runat="server" BackColor =" LightGreen" Height ="20px" Width="100%"></asp:Panel>
    <div class="row">
        <div class="col-md-3">
            <div align="left">
                <h2>
                    <asp:Label ID="inputLb" runat="server" Text="1. Input Text" Font-Names="Impact"></asp:Label>
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
                    EnableViewState="False" ToolTip="putchyowords here" Height="300px"></asp:TextBox>
            </div>
            
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="Submit_Button" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40px" Width="85px" />
        </div>
        <div class="col-md-3">
            <h2>
                <asp:Label ID="outputLb" runat="server" Text="2. Make your Changes" Font-Names="Impact"></asp:Label>
            </h2>
            <asp:Panel ID="dropDownPanel" runat="server" EnableViewState="true">
            </asp:Panel>
            <p>
                <p id="dropDownPar" runat = "server" >
           </p>
            </p>
        </div>
        <div class="col-md-2">
            <div align="center">
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="userSelection" onclick="Final_Button" runat="server" Text="User Selection" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="105"/>
                        <br />
                        <br />
                        <asp:Button ID="lengthen" onclick="Longest_Button" runat="server" Text="Lengthen" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
                        <br />
                        <br />
                        <asp:Button ID="shorten" onclick="Smallest_Button" runat="server" Text="Shorten" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
                        <br />
                        <br />
                        <asp:Button ID="randomize" onclick="Randomize_Button" runat="server" Text="Randomize" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
                        <br />
                        <br />
                        <asp:Button ID="Reset" onclick="Reset_Session" runat="server" Text="Reset" BackColor="#44C767" BorderStyle="Solid" Font-Names="Arial" ForeColor="White" BorderWidth="1" BorderColor="#18AB29" Height="40" Width="85"/>
            </div>
        </div>
        <div class="col-md-4">
            <h2>
                <asp:Label ID="Final" runat="server" Text="3. Final" Font-Names="Impact"></asp:Label>
            </h2>
            <p>
                <asp:TextBox ID="FinalOutputLabel"
                    Wrap ="true"
                    runat="server" 
                    BorderStyle="None" 
                    TextMode="MultiLine" 
                    BorderColor="Black" Font-Size="20pt" 
                    style="width:100%; resize:none"
                    EnableViewState="False" ToolTip="putchyowords here" Height="300px" ReadOnly="True"></asp:TextBox>
            </p>
        </div>
    </div>
</asp:Content>
