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
        <div class="col-md-5">
            <div align="left">
                <h2>
                    <asp:Label ID="inputLb" runat="server" Text="Input Text"></asp:Label>
                </h2>
            </div>
            <p>
                put input box here
            </p>
        </div>
        <div class="col-md-5">
            <h2>
                <asp:Label ID="outputLb" runat="server" Text="Output Text"></asp:Label>
            </h2>
            <p>
                put output box here
            </p>
        </div>
        <div class="col-md-2">
            <h2>
                <asp:Label ID="settingsLb" runat="server" Text="Settings"></asp:Label>
            </h2>
            <p>
                put buttons and sliders here
            </p>
        </div>
    </div>
</asp:Content>
