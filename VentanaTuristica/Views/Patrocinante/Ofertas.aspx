<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<VentanaTuristica.Model.Imagene>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Ofertas Destacadas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
       <div style=" height:15px"></div>
   <div style=" padding-left:45px">
   <%  if (Model != null)
        {%> <div><%
            
            foreach (var item in Model)
            {%>
                  <a target="_blank"  href="<%=item.Link %>"><img src='<%=Url.Action("Show", "Patrocinante", new {id = item.IdImagen})%>' width="212px"/></a>
          <%}%>
              </div>
        <%}%>

        </div>
        <div style=" height:15px"></div>
 

   

</asp:Content>