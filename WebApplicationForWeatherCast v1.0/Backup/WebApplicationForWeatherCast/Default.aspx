<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplicationForWeatherCast._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    


            <asp:DropDownList ID="ddlWeatherCast" runat="server" Width="150px" 
                        AutoPostBack="True" onselectedindexchanged="ddlWeatherCast_SelectedIndexChanged">
                    <asp:ListItem>[Elegir]</asp:ListItem>
                    <asp:ListItem Value="Caracas">Caracas</asp:ListItem>
                    <asp:ListItem Value="Singapur">Singapur</asp:ListItem>
                    <asp:ListItem Value="Santiago">Santiago</asp:ListItem>
                    <asp:ListItem Value="New York">New York</asp:ListItem>
                    <asp:ListItem Value="Osaka">Osaka</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="Humedad" runat="server"></asp:Label>
                    <asp:Label ID="MaxTemp" runat="server"></asp:Label>
                    <asp:Label ID="MinTemp" runat="server"></asp:Label>
                    <asp:Label ID="Weather" runat="server"></asp:Label>
                    <asp:Label ID="Temperatura" runat="server"></asp:Label>
                    <asp:Label ID="WindSpeed" runat="server"></asp:Label>
                    <asp:Label ID="TemperaturaPromedio" runat="server"></asp:Label>
    </p>
</asp:Content>
