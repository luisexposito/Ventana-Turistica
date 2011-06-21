<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<VentanaTuristica.Model.Imagene>>" %>

    <%  if (Model != null)
        { %>
        
            <div id="gallery">  
         <%

            int contador = 0;
            foreach (var item in Model)
            { 
                if (contador == 0)
                { %>
                    <a style="opacity: 1;" class="show" ><img class="captify" src='<%=Url.Action("Show", "Imagene", new {id = item.IdImagen})%>' alt="<%: item.Descripcion %>" width="900px" title="" rel=""/></a>
                
                <% } 
                else
                { %>
                    <a style="opacity: 0; " class=""><img class="captify" src='<%=Url.Action("Show", "Imagene", new {id = item.IdImagen})%>' alt="<%: item.Descripcion %>" width="900px" title="" rel=""/></a>
                <%}
                contador++;
            } %>
                <div class="caption" style="width: 950px; opacity: 0; height: 100px; display: block; "><div class="content" style="opacity: 0; "></div></div>
                </div>
                <br class="c" />
        <%} %>