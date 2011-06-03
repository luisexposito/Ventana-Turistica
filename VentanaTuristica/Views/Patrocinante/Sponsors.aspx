<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<VentanaTuristica.Model.Imagene>>" %>

    <%  if (Model != null)
        {
             %> <div class="slideshow"><%
            
            foreach (var item in Model)
            {%>
               
                  
               
                    <a target="_blank"  href="<%=item.Link %>"><img src='<%=Url.Action("Show", "Patrocinante", new {id = item.IdImagen})%>' width="212px"/></a>
               
                  
               
          <%}%>
              </div>
        <%} %>

