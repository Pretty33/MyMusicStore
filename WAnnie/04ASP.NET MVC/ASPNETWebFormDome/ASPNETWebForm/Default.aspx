﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="49px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="162px">

    </asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server" Height="155px" Width="235px">
    </asp:GridView>
    <br />
</asp:Content>
