<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<VentanaTuristica.Model.Imagene>>" %>

    <%  if (Model != null)
        { %>
        
        <div class="fbCycler" style="width: 900px; height:450px">
         <% foreach (var item in Model)
            { %>

                <div id="contenido">
                    <p class="floatbox" data-fb-options="modal:false disableScroll:true width:250 scrolling:no enableDragMove:false enableDragResize:false cornerRadius:4 padding:12 colorTheme:white cycleInterval:8">
                        <img class="fbTooltip" src='<%=Url.Action("Show", "Imagene", new {id = item.IdImagen})%>' alt="<%: item.Descripcion %>" style="width:900px"/>
                    </p>
                </div>
                    
            <%} %>
        <%} %>

        </div>
        
