<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<VentanaTuristica.Model.Blog>>" %>
<%@ Import Namespace="Resources" %>
<script runat="server">

    protected override void InitializeCulture()
    {
        base.InitializeCulture();
        if (Session["culture"] != null)
        {
            
            Culture = Session["culture"].ToString();
            UICulture = Session["culture"].ToString();
            
        }
        else
        {
            Session["culture"] = "es-MX";
            Culture = Session["culture"].ToString();
            UICulture = Session["culture"].ToString();
        }
    }
    
</script>

    <ul id="nav">         
        <li><%: Html.ActionLink( ResourceEmpresa.Home, "Index", "Home")%>
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

     