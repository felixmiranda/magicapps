
<#-- 
 
 crea una clase para un aspx para la tabla  ${table}...
 Author : Luis Molina...
 
 -->
<#-- variables used internally by the generator... -->
<#assign nameFile="listado_${table}">
<#assign extensionFile="aspx.designer.cs">
<#assign languageGenerated="c#">
<#assign description="c#">
<#assign targetDirectory="${table}_dir">
<#assign appliesToAllTables="true">
<#-- END variables used internally by the generator... -->


//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.1433
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ${project}.${table}_dir {
    
    
    /// <summary>
    /// Clase listado_${table}.
    /// </summary>
    /// <remarks>
    /// Clase generada automáticamente.
    /// </remarks>
    public partial class listado_${table} {
        
     /// <summary>
        /// Control RepeaterBarraNavegacion.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Repeater RepeaterBarraNavegacion;
        
        /// <summary>
        /// Control Label1.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label Label1;
        
        /// <summary>
        /// Control Panel1.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Panel Panel1;
        
        /// <summary>
        /// Control txtBusqueda.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox txtBusqueda;
        
        /// <summary>
        /// Control btnBuscar.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button btnBuscar;
        
        /// <summary>
        /// Control Label2.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Label Label2;
        
        /// <summary>
        /// Control Repeater1.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Repeater Repeater1;
       		<#list table.getRelations() as relation>
			#if ($relation.ParentTable() == "categorias"+ $relation.ChildTable())		 
        /// <summary>
        /// Control Repeater1.
        /// </summary>
        /// <remarks>
        /// Campo generado automáticamente.
        /// Para modificar, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
        /// </remarks>
        protected global::System.Web.UI.WebControls.Repeater Repeater2;
						#end			
				#end 	
    }
}
