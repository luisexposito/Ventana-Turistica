<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<VentanaTuristica.Model.Imagene>>" %>

    <%  if (Model != null)
        {
             %> <div class="slideshow"><%
            
            foreach (var item in Model)
            {%>
               
                  
               
                    <a target="_blank"  href="<%=item.Link %>"><img src='<%=Url.Action("Show", "Patrocinante", new {id = item.IdImagen})%>' width="212px"/></a>
               
                  
               
          <%}%>
              </div>

            <div class="slideshow"><%
            Random randNum = new Random();
            int val;
            
            foreach (var imagene in Model)
            {
                val = randNum.Next(1000);
                imagene.IdPublicacion = val;
            }
            var a = Model.OrderBy(model => model.IdPublicacion);
            foreach (var item in a)
            {%>
               
                  
               
                    <a target="_blank"  href="<%=item.Link %>"><img src='<%=Url.Action("Show", "Patrocinante", new {id = item.IdImagen})%>' width="212px"/></a>
               
                  
               
          <%}%>
              </div>

            <div class="slideshow"><%
                                       foreach (var imagene in Model)
                                       {
                                           val = randNum.Next(1000);
                                           imagene.IdPublicacion = val;
                                       }
            a = Model.OrderByDescending(model => model.IdPublicacion);
            foreach (var item in a)
            {%>
               
                  
               
                    <a target="_blank"  href="<%=item.Link %>"><img src='<%=Url.Action("Show", "Patrocinante", new {id = item.IdImagen})%>' width="212px"/></a>
               
                  
               
          <%}%>
              </div>

            <div class="slideshow"><%
            foreach (var imagene in Model)
            {
                val = randNum.Next(1000);
                imagene.IdPublicacion = val;
            }
            a = Model.OrderBy(model => model.IdPublicacion);
            foreach (var item in a)
            {%>
               
                  
               
                    <a target="_blank"  href="<%=item.Link %>"><img src='<%=Url.Action("Show", "Patrocinante", new {id = item.IdImagen})%>' width="212px"/></a>
               
                  
               
          <%}%>
              </div>
        <%} %>

