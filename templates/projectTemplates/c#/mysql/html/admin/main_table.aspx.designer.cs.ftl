<#-- 
 
 crea una clase para un aspx para la tabla  ${table}...
 Author : Pablo Garcia Mu�oz...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="main_${table}">
<#assign extensionFile="aspx.designer.cs">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="${table}_dir">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->



//------------------------------------------------------------------------------
// <auto-generated>
//     Este c�digo fue generado por una herramienta.
//     Versi�n del motor en tiempo de ejecuci�n:2.0.50727.1433
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el c�digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ${project}.${table}_dir {
    
    
    /// <summary>
    /// Clase main_${table}.
    /// </summary>
    /// <remarks>
    /// Clase generada automáticamente.
    /// </remarks>
    public partial class main_${table} {
        
        

#set ($count = 0)
#foreach( $field in $table.GetArrayOfFields )
  #if (!$field.isKey())

   
     
     
              #if ($field.type.toString() == "_integer")
                #if ( $field.isForeignKey())
                   /// <summary>
                    /// Control cmb${field}.
                    /// </summary>
                    /// <remarks>
                    /// Campo generado autom�ticamente.
                    /// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
                    /// </remarks>
                    protected global::System.Web.UI.WebControls.DropDownList cmb${field};
                #else
                    /// <summary>
                    /// Control txt${field}.
                    /// </summary>
                    /// <remarks>
                    /// Campo generado automáticamente.
                    /// Para modificar, mueva la declaraci�n del campo del archivo del diseñador al archivo de c�digo subyacente.
                    /// </remarks>
                    protected global::System.Web.UI.WebControls.TextBox txt${field};
                #end

                
                 #end 
              #if ($field.type.toString() == "_string")
                   /// <summary>
                    /// Control txt${field}.
                    /// </summary>
                    /// <remarks>
                    /// Campo generado automáticamente.
                    /// Para modificar, mueva la declaraci�n del campo del archivo del diseñador al archivo de c�digo subyacente.
                    /// </remarks>
                    #if ( $field.size() >= 251)>
					   protected global::FreeTextBoxControls.FreeTextBox txt${field};
					#else
						protected global::System.Web.UI.WebControls.TextBox txt${field};
					 #end
					
                 #end 
              #if ($field.type.toString() == "_date")
                   /// <summary>
					/// Control ${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::eWorld.UI.CalendarPopup ${field};
		
		
                 #end 
              #if ($field.type.toString() == "_bigString")
                   /// <summary>
					/// Control ${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::FreeTextBoxControls.FreeTextBox txt${field};
		
		
                 #end 				 
              #if ($field.type.toString() == "_boolean")
                   /// <summary>
                    /// Control ck{field}.
                    /// </summary>
                    /// <remarks>
                    /// Campo generado autom�ticamente.
                    /// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
                    /// </remarks>
                    protected global::System.Web.UI.WebControls.CheckBox ck${field};
                 #end 
               #if ($field.type.toString() == "_image")
                   //// <summary>
					/// Control img${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.Image img${field};
					
					/// <summary>
					/// Control btnborrarimagen${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.Button btnborrarimagen${field};
					
					/// <summary>
					/// Control FileUploadImagen${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.FileUpload FileUploadImagen${field};
					
					/// <summary>
					/// Control lblinfo${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.Label lblinfo${field};
                 #end 
               #if ($field.type.toString() == "_document")
                   //// <summary>
					/// Control lbl${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.Label lbl${field};
					
					/// <summary>
					/// Control btnborrar${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.Button btnborrar${field};
					
					/// <summary>
					/// Control FileUpload${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.FileUpload FileUpload${field};
					
					/// <summary>
					/// Control lblinfo${field}.
					/// </summary>
					/// <remarks>
					/// Campo generado autom�ticamente.
					/// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
					/// </remarks>
					protected global::System.Web.UI.WebControls.Label lblinfo${field};
                 #end 				 
               <#default>
                    /// <summary>
                    /// Control txt${field}.
                    /// </summary>
                    /// <remarks>
                    /// Campo generado automáticamente.
                    /// Para modificar, mueva la declaraci�n del campo del archivo del diseñador al archivo de c�digo subyacente.
                    /// </remarks>
                   	protected global::System.Web.UI.WebControls.TextBox txt${field};					
      
    #set ($count = $count + 1 )
 #end
#end 

         /// <summary>
        /// Control PanelAviso.
        /// </summary>
        /// <remarks>
        /// Campo generado autom�ticamente.
        /// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Panel PanelAviso;
		
        /// <summary>
        /// Control lblinfo.
        /// </summary>
        /// <remarks>
        /// Campo generado autom�ticamente.
        /// Para modificar, mueva la declaraci�n del campo del archivo del dise�ador al archivo de c�digo subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label lblinfo;
        
        
        /// <summary>
        /// Control butModificar.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaraci�n del campo del archivo del diseñador al archivo de c�digo subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button butModificar;
    }
}
