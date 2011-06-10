<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<VentanaTuristica.Model.Blog>>" %>

    <ul id="nav">         
        <li><%: Html.ActionLink("Home", "Index", "Home")%>
        </li>     
        <% 
            if (ViewData["todosAnios"] != null)
            {
                int cont = 0;
            foreach (var item in (IEnumerable) ViewData["todosAnios"])
            {%>
                <li><%:Html.ActionLink(item.ToString(), "Principal", "Blog", new { anio = item.ToString() }, null)%>
                    
                <%
                    if (ViewData["todosMeses"] != null)
                {
                    %>
                    <ul>
                    <%
                }

                        IList<IList<string>> mess = (IList<IList<string>>) ViewData["todosMeses"];
                        foreach (var meses in mess[cont])
                        {%>
                    
                        <li><%:Html.ActionLink(meses, "Principal", "Blog", new {anio = item.ToString(), mes = meses},null)%>
                        </li>
                    
                    <%
                }
                cont++;
                        if (ViewData["todosMeses"] != null)
                {
                    %>
                    </ul>
                    <%
                }%>
                </li>
            <%  }
        } %>
    </ul>

     