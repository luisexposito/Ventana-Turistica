<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
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
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style=" padding:50px">
    <h2>Mail</h2>

           
            
            

<form action="../../_gdForm/webformmailer.asp" method="POST">
<input type="hidden" name="subject" value="Submission" />
<input type="hidden" name="redirect" value="../../" />
         <div class="editor-label">
                    Email:    
         </div>
         <div class="editor-field">
              <input type="text" name="email" />
         </div>

<div class="editor-label">
                   Comentarios:  
         </div>
          <div class="editor-field">
             <textarea name="comments" cols="40" rows="10">
Escriba sus comentarios aqui.</textarea>
         </div>

 
<input type="submit" name="submit" value="Enviar"/>
<input type="hidden" name="form_order" value="alpha"/> <input type="hidden" name="form_interval" value="default"/> <input type="hidden" name="form_format" value="html"/> </form>
</div>
</asp:Content>
