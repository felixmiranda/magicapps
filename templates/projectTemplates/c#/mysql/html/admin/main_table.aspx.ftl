<#-- 
 
 crea una clase para un listado_...aspx para la tabla  ${table}...
 Author : Pablo Garcia Muñoz...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="main_${table}">
<#assign extensionFile="aspx">
<#assign languageGenerated="c#">
<#assign description="description">
<#assign targetDirectory="${table}_dir">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->

<%@ Page Language="C#" MasterPageFile="~/admin/master/masterAdmin.Master" AutoEventWireup="true"  CodeBehind="main_${table}.aspx.cs" Inherits="${project}.${table}_dir.main_${table}" Title="Página sin título" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	<div id="contenido">
	    <asp:Repeater ID="RepeaterBarraNavegacion" runat="server">
        <ItemTemplate>
            ><a href="<%#Eval("url")%>"><%#Eval("nombre")%></a>
        </ItemTemplate>
    </asp:Repeater>			
				<!--barra titulos-->
				<div class="titulos">
					<div class="itemTit">
					  <h2 class="textoTit">
                          ${table}</h2>
					</div>
				</div>
				<!--barra titulos-->
				
			 <div class="addCategorias">
				 
				<ul  class="pestCat">
					<li><a href="../${table}_dir/main_${table}.aspx" class="add">Nuevo ${table}</a></li>
					<li><a href="../${table}_dir/listado_${table}.aspx" class="mod" >Listado ${table}</a></li>
       		<#list table.getRelations() as relation>
			#if ($relation.ParentTable() == "categorias"+ $relation.ChildTable())		
					<li><a href="../${relation.getParentTable()}_dir/main_${relation.getParentTable()}.aspx" class="addCat">Nuevo ${relation.getParentTable()}</a></li>
					<li><a href="../${relation.getParentTable()}_dir/listado_${relation.getParentTable()}.aspx" class="modCat" >Listado ${relation.getParentTable()}</a></li>
			
				#end			
				#end 	
 
				</ul>
			 
				</div>
				
				<!--subseccion 1-->
					<div class="subseccion">
					<div class="titSubseccion">
					  <h3 class="itemh3">
                          Rellene los datos</h3>
					</div>
					
		 	
#set ($count = 0)
#foreach( $field in $table.GetArrayOfFields )
  #if (!$field.isKey())
     
     
              #if ($field.type.toString() == "_integer")
                #if ($field.isForeignKey() )				
					<div class="lineaForm">
						<label for="${field}">				
						<span class="etiqueta">${field.getTargetName()}: </span>
						<asp:DropDownList ID="cmb${field}" runat="server">
						</asp:DropDownList>
					
					</label>
					</div>		
            #else
			    #if ($field != "idportal")	
				<div class="lineaForm">
                <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:TextBox ID="txt${field}"   runat="server"></asp:TextBox>
                    </label>
					</div>		
				#end	
            #end

                
                 #end 
              #if ($field.type.toString() == "_string")
			  	<div class="lineaForm">
                   <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
							<asp:TextBox ID="txt${field}"   runat="server"></asp:TextBox>
						                     
                    </label>
						</div>		
                 #end 
			#if ($field.type.toString() == "_bigString")
			  	<div class="lineaForm">
                   <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
						   <FTB:FreeTextBox ID="txt${field}" runat="server" Language="es-ES">
						   </FTB:FreeTextBox>						                       
                    </label>
						</div>		
                 #end 
              #if ($field.type.toString() == "_date")
			  	<div class="lineaForm">
                 <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                         <ew:CalendarPopup ID="${field}" runat="server" >
                         </ew:CalendarPopup>
                    </label>
						</div>		
                 #end 
              #if ($field.type.toString() == "_boolean")
			  	<div class="lineaForm">
                  <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:CheckBox ID="ck${field}"   runat="server" />
                    </label>
						</div>		
                 #end 
				#if ($field.type.toString() == "_image")
					<div class="lineaForm">
						<span class="etiqueta">${field.getTargetName()}
						</span>
                            <asp:Image ID="img${field}" runat="server" Visible="False" Width="40px" />
                            <asp:Button ID="btnborrarimagen${field}" runat="server" CssClass="boton" OnClick="btnborrarimagen${field}_Click"
                                Text="Borrar imagen" Visible="False" />
                            <span class="zonacampo">
                             <label for="FileUploadImagen${field}"><asp:FileUpload ID="FileUploadImagen${field}" runat="server" Width="328px" CssClass="textstandar" /></label>
                            </span>
                            <br />
                            <br />
                            <asp:Label ID="lblinfo${field}" CssClass="camporojo" runat="server" Text=""></asp:Label>
                    </div>
				#end 
				#if ($field.type.toString() == "_document")
					<div class="lineaForm">
						<span class="etiqueta">${field.getTargetName()}
						</span>
                            <asp:Label ID="lbl${field}" runat="server" Visible="False" />
                            <asp:Button ID="btnborrar${field}" runat="server" CssClass="boton" OnClick="btnborrar${field}_Click"
                                Text="Borrar documento" Visible="False" />
                            <span class="zonacampo">
                             <label for="FileUpload${field}">
								<asp:FileUpload ID="FileUpload${field}" runat="server" Width="328px" CssClass="textstandar" />
						     </label>
                            </span>
                            <br />
                            <br />
                            <asp:Label ID="lblinfo${field}" CssClass="camporojo" runat="server" Text=""></asp:Label>
                    </div>
				#end 				
              <#default>
			  	<div class="lineaForm">
                 <label for="${field}">
                        <span class="etiqueta">${field.getTargetName()}: </span>
                        <asp:TextBox ID="txt${field}"  runat="server"></asp:TextBox>
                    </label>
						</div>		
      
    #set ($count = $count + 1 )
 #end
#end 			
			
			
    <asp:Panel ID="PanelAviso" visible="false" runat="server">
					     <div class="aviso">
            
                        <p>    <asp:Label ID="lblinfo" Visible="false"  runat="server" Text=""></asp:Label></p>
 
						</div>
						</asp:Panel>
					
					</div><!--subsecciones-->
					
					
			 
					<!--botones formulario-->
					<div class="botonesSub">
						<span>
							 <asp:Button ID="butModificar" runat="server" CssClass="boton" OnClick="butModificar_Click" Text="Modificar" />
						</span>
						<span>
							 <asp:Button ID="butCancelar" runat="server" CssClass="boton" OnClick="butCancelar_Click" Text="Cancelar" />
						</span>
					</div>
					<!--botones formulario-->
				
				</div> 
</asp:Content>
