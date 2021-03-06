﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site4.Master" Inherits="System.Web.Mvc.ViewPage<VentanaTuristica.Model.Servicio>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar Servicio
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Editar Servicio</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nombre) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nombre) %>
                <%: Html.ValidationMessageFor(model => model.Nombre) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Descripcion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Descripcion) %>
                <%: Html.ValidationMessageFor(model => model.Descripcion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Idioma) %>
            </div>
            <div class="editor-field">
                <%: Html.DisplayFor(model => model.Idioma)%>
                <%: Html.ValidationMessageFor(model => model.Idioma) %>
            </div>
            <input type="hidden" name="FkIdServicio" value="<%: Model.FkIdServicio %>" />
            <input type="hidden" name="IdServicio" value="<%: Model.IdServicio %>" />
            <input type="hidden" name="Idioma" value="<%: Model.Idioma %>" />
            <div>
                <input type="submit" value="Actualizar" />
            </div>

    <% } %>
    <br />
        <table>
            <td><a title="Servicios" href="<%=Url.Action("Index")%>">
                <img src="<%=Url.Content("~/Content/atras.png")%>" height="25px" width="25px" /></a></td>
            <td><%: Html.ActionLink("Servicios", "Index")%></td>
        </table>
    </fieldset>
</asp:Content>

