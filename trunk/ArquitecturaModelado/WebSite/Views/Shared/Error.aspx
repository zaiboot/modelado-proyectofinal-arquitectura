<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZAP.Model.OperationResult<ZAP.Model.BaseModel>>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Sorry, an error occurred while processing your request.
    </h2>
    <p>
<%= this.Model.ErrorMessage %>
</p>
<p>
    The report id is: <%= this.Model.Id %>.
</p>
</asp:Content>
