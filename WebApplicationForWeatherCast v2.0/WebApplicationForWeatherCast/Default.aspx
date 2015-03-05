<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplicationForWeatherCast._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <table style="width: 30%;" class="Detailsview_cuerpo" border="1" cellpadding="1" cellspacing="0" >
         <tr>
             <td>
            <asp:Label ID="lblSelectCtry" runat="server" Text="Seleccione la ciudad de su preferencia"></asp:Label>

                 
        </td>

         <td>
            <asp:DropDownList ID="ddlElegirCiudad" runat="server" Width="150px" 
                        AutoPostBack="True" onselectedindexchanged="ddlWeatherCast_SelectedIndexChanged">
                    <asp:ListItem Value="[Elegir]">[Elegir]</asp:ListItem>
                    <asp:ListItem Value="Caracas">Caracas</asp:ListItem>
                    <asp:ListItem Value="Singapur">Singapur</asp:ListItem>
                    <asp:ListItem Value="Santiago">Santiago</asp:ListItem>
                    <asp:ListItem Value="New York">New York</asp:ListItem>
                    <asp:ListItem Value="Osaka">Osaka</asp:ListItem>
                    </asp:DropDownList>

                 
        </td>
             </tr>

        <tr>
             <td>
           
                    <asp:Label ID="lblTime0" runat="server" Text="Fecha"></asp:Label>
                 
        </td>
              <td>
           
                    <asp:Label ID="lbltime" runat="server"></asp:Label>
                 
        </td>
             </tr>

         <tr>
             <td>
           
                    <asp:Label ID="lblTemperatura0" runat="server" Text="Temperatura  Actual"></asp:Label>
                 
        </td>
              <td>
           
                    <asp:Label ID="Temperatura" runat="server"></asp:Label>
                 
        </td>
             </tr>

        
        <tr>
             <td>
           
                    <asp:Label ID="lblTempPromedio0" runat="server" Text="Temperatura Promedio en los Proximos 3 días"></asp:Label>
                 
        </td>
              <td>
           
                    <asp:Label ID="lblTempPromdio" runat="server"></asp:Label>
                 
        </td>
             </tr>

        </table>
    
</asp:Content>
