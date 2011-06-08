<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site4.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Upload
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Fotos</h2>

<form action="" method="post" enctype="multipart/form-data">
<label>Imagen 1</label><br />
<input type="file" style=" width:500px" name="files" id="file1"/><br /><br />
<label>Imagen 2</label><br />
<input type="file" style=" width:500px" name="files" id="file2" /><br /><br />
<label>Imagen 3</label><br />
<input type="file" style=" width:500px" name="files" id="file3"/><br /><br />
<label>Imagen 4</label><br />
<input type="file" style=" width:500px" name="files" id="file4"/><br /><br />
<label>Imagen 5</label><br />
<input type="file" style=" width:500px" name="files" id="file5" /><br /><br />
<label>Imagen 6</label><br />
<input type="file" style=" width:500px" name="files" id="file6"/><br /><br />
<label>Imagen 7</label><br />
<input type="file" style=" width:500px" name="files" id="file7"/><br /><br />
<label>Imagen 8</label><br />
<input type="file" style=" width:500px" name="files" id="file8" /><br /><br />
<label>Imagen 9</label><br />
<input type="file" style=" width:500px" name="files" id="file9"/><br /><br />
<label>Imagen 10</label><br />
<input type="file" style=" width:500px" name="files" id="file10"/><br /><br />
<label>Imagen 11</label><br />
<input type="file" style=" width:500px" name="files" id="file11" /><br /><br />
<label>Imagen 12</label><br />
<input type="file" style=" width:500px" name="files" id="file12"/><br /><br />
<label>Imagen 13</label><br />
<input type="file" style=" width:500px" name="files" id="file13"/><br /><br />
<label>Imagen 14</label><br />
<input type="file" style=" width:500px" name="files" id="file14" /><br /><br />
<label>Imagen 15</label><br />
<input type="file" style=" width:500px" name="files" id="file15"/><br /><br />
<div class="editor-label">
    <input type="submit" value="Cargar" />
</div>
            
</form>

</asp:Content>


