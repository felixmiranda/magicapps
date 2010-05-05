<#-- 
 
 crea una clase para c# para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="listado_${table}">
<#assign extensionFile="aspx">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="main_${table}">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... --> 

<%@ Page Language="C#" MasterPageFile="~/portal/master/masterWeb.Master" AutoEventWireup="true" CodeBehind="listado_${table}.aspx.cs" Inherits="${project}.portal.main_${table}.listado_${table}" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			 <div class="titulo"><h2>${table}</h2></div>
			<div class="general">
 					<p>Consultar el listado de las ${table} distribuidas en la provincia:</p>
					<ul class="list${table}">
					  <asp:Repeater ID="Repeater1" runat="server">
                         <ItemTemplate>
                          <li>  <a  class="asoc" href="ficha_${table}.aspx?id=<%#Eval("${table.getKey()}")%>"><%#Eval("${table.getKey()}")%></a></li>
                         </ItemTemplate>
                        </asp:Repeater>                          
					</ul>
					

 

		 
			  
			</div>
			
</asp:Content>
