﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

using System.Text.RegularExpressions;

// http://msdn.microsoft.com/en-us/library/microsoft.web.management.databasemanager.indextype.aspx
// http://tom-shelton.net/index.php/2009/02/21/exploring-sql-server-schema-information-with-adonet/
// http://www.dotnetbips.com/articles/bcd9065e-94af-4063-8360-f916571f9872.aspx

class dbMySql
{
    public MySql.Data.MySqlClient.MySqlConnection conexion;
    public MySql.Data.MySqlClient.MySqlCommand miComando;
    public MySql.Data.MySqlClient.MySqlDataReader miLector;



    public string test(string cadconexion)
    {
        MySqlConnection conexion = null;
        try
        {
            conexion = new MySqlConnection(cadconexion);
            miComando = new MySqlCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();
            return "";
        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return ep.Message;
        }
        finally
        {
            conexion.Close();
        }
    }   // test


    public List<table> getTables(string cadconexion, string database)
    {
        MySql.Data.MySqlClient.MySqlConnection conexion = null;
        try
        {
            List<table> lista = new List<table>();

            conexion = new MySql.Data.MySqlClient.MySqlConnection(cadconexion);
            miComando = new MySqlCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = conexion.GetSchema("Tables", new String[] { null, database, null, null });


            foreach (System.Data.DataRow rowDatabase in dt.Rows)
            {
                table tab = new table();
                tab.Name = rowDatabase["table_name"].ToString();
                tab.TargetName = tab.Name;
                lista.Add(tab);

            }

            return lista;


        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return null;
        }
        finally
        {
            conexion.Close();
        }
    }   // getTables



    public List<field> getFields(string cadconexion, string database, string table)
    {
        MySqlConnection conexion = null;
        try
        {

            //   ' ESTO SERIA PARA LA TABLA COMMENTS
            //' PARA SACARLO CON SQL...
            // SELECT *, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS  where table_name = 'cars'

            List<field> lista = new List<field>();

            // Retrieve a list of primary keys for a table.
            //List<String> primaryKeys = getKeys(cadconexion, table);

            conexion = new MySqlConnection(cadconexion);
            miComando = new MySqlCommand("");
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = conexion.GetSchema("Columns", new String[] { null, database, table, null });

            foreach (System.Data.DataRow row in dt.Rows)
            {
                field fi = new field();
                fi.Name = row[3].ToString();
                fi.targetName = row[3].ToString();

                string tipo = null;
                tipo = row[7].ToString();
                switch (tipo)
                {
                    case "text":
                        fi.type = field.fieldType._text;
                        break;

                    case "mediumtext":
                        fi.type = field.fieldType._text;
                        break;

                    case "char":
                        fi.type = field.fieldType._string;
                        break;

                    case "nchar":
                        fi.type = field.fieldType._string;
                        break;

                    case "varchar":
                        fi.type = field.fieldType._string;
                        break;

                    case "nvarchar":
                        fi.type = field.fieldType._string;
                        break;
                    case "binary":
                        fi.type = field.fieldType._string;
                        break;

                    case "varbinary":
                        fi.type = field.fieldType._string;
                        break;


                    case "mediumint":
                        fi.type = field.fieldType._integer;
                        break;

                    case "smallint":
                        fi.type = field.fieldType._integer;
                        break;

                    case "int":
                        fi.type = field.fieldType._integer;
                        break;

                    case "numeric":
                        fi.type = field.fieldType._integer;
                        break;

                    case "tinyint":
                        fi.type = field.fieldType._boolean;
                        break;

                    case "boolean":
                        fi.type = field.fieldType._boolean;
                        break;
                    case "bool":
                        fi.type = field.fieldType._boolean;
                        break;

                    case "bit":
                        fi.type = field.fieldType._boolean;
                        break;

                    case "bigint":
                        fi.type = field.fieldType._double;
                        break;

                    case "double":
                        fi.type = field.fieldType._double;
                        break;

                    case "float":
                        fi.type = field.fieldType._double;
                        break;

                    case "smalldatetime":
                        fi.type = field.fieldType._date;
                        break;

                    case "datetime":
                        fi.type = field.fieldType._date;
                        break;

                    case "date":
                        fi.type = field.fieldType._date;
                        break;

                    case "timestamp":
                        fi.type = field.fieldType._date;
                        break;

                    default:
                        fi.type = field.fieldType._string;
                        break;
                }

                fi.targetType = fi.type;


                fi.allowNulls = sf.boolean(row["IS_NULLABLE"]);
                fi.size = sf.entero(row["CHARACTER_MAXIMUM_LENGTH"]);


                // if the size is > 250 and type is string....
                if (fi.size >= 250)
                {
                    switch (tipo)
                    {
                        case "mediumtext":
                            fi.type = field.fieldType._text;
                            fi.targetType = field.fieldType._text;
                            break;

                        case "char":
                            fi.type = field.fieldType._text;
                            fi.targetType = field.fieldType._text;
                            break;

                        case "nchar":
                            fi.type = field.fieldType._text;
                            fi.targetType = field.fieldType._text;
                            break;

                        case "varchar":
                            fi.type = field.fieldType._text;
                            fi.targetType = field.fieldType._text;
                            break;

                        case "nvarchar":
                            fi.type = field.fieldType._text;
                            fi.targetType = field.fieldType._text;
                            break;
                    }
                }


                //     fi.comment = sf.Cadena(tbl.Rows(i)!COLUMN_COMMENT);
                fi.defaultValue = sf.cadena(row["COLUMN_DEFAULT"]);


                //try
                //{
                //    if (primaryKeys.Contains(fi.Name))
                //    {
                //        fi.isKey = true;
                //        // fi.autoNumber = true;
                //    }
                //}
                //catch (Exception)
                //{


                //}

                //fi.autoNumber = sf.boolean(row["COLUMN_KEY"]);
                //   fi.isKey = sf.boolean(row["COLUMN_KEY"]);
                fi.decimals = sf.entero(row["NUMERIC_PRECISION"]);

                // // Retrieve the column's default value.
                // fi.defaultValue = ((row["COLUMN_DEFAULT"] as DBNull)
                //     != null) ? "Null" : row["COLUMN_DEFAULT"].ToString();
                // // Retrieve the column's precision.
                // //column.Precision = ((row["NUMERIC_PRECISION"] as DBNull)
                // //    != null) ? 0 : Int32.Parse(row["NUMERIC_PRECISION"].ToString());
                // // Retrieve the column's scale.
                //// column.Scale = ((row["NUMERIC_SCALE"] as DBNull) != null) ? 0 : Int32.Parse(row["NUMERIC_SCALE"].ToString());
                // // Specify if the column is a primary key.
                // fi.isKey = primaryKeys.Contains(row["COLUMN_NAME"].ToString());
                // // Specify that the column is not an identity column.
                // //column.IsIdentity = false;
                // // Retrieve the column length.
                // fi.size = ((OleDbType)Int32.Parse(row["DATA_TYPE"].ToString()) != OleDbType.WChar) ? -1 : Int32.Parse(row["CHARACTER_MAXIMUM_LENGTH"].ToString());
                // // Append the column to the list.



                //fi.size = sf.Entero(tbl.Rows(i)!CHARACTER_MAXIMUM_LENGTH)
                //     fi.comment = sf.Cadena(tbl.Rows(i)!COLUMN_COMMENT)
                //fi.allowNulls = sf.boolean(row["IS_NULLABLE"]);//tbl.Rows(i)!IS_NULLABLE)
                //     fi.defaultValue = sf.Cadena(tbl.Rows(i)!COLUMN_DEFAULT)
                //     fi.autoNumber = sf.boolean(tbl.Rows(i)!COLUMN_KEY)
                //     fi.decimals = sf.Entero(tbl.Rows(i)!NUMERIC_PRECISION)

                lista.Add(fi);

            }

            return lista;


        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return null;
        }
        finally
        {
            conexion.Close();
        }
    }  // getFields


    // we get extra information for the fields...
    public void getKeys(string cadconexion, table table, String database)
    {
        MySqlConnection conexion = null;
        try
        {
            List<String> lista = new List<String>();
            String sql = null;
            //sql = String.Format("SELECT  table_name, column_name, constraint_name, referenced_table_name, referenced_column_name FROM information_schema.key_column_usage WHERE TABLE_NAME = '{0}' ", table);
            sql = String.Format("SELECT  * FROM information_schema.columns WHERE TABLE_NAME = '{0}' and TABLE_SCHEMA= '{1}'", table.Name, database);

            conexion = new MySqlConnection(cadconexion);
            miComando = new MySqlCommand(sql);
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            MySql.Data.MySqlClient.MySqlDataReader dr = null;
            dr = miComando.ExecuteReader();

            while (dr.Read())
            {
                String tipo = sf.cadena(dr["COLUMN_KEY"]);
                String campo = sf.cadena(dr["COLUMN_NAME"]);
                String comentario = sf.cadena(dr["COLUMN_COMMENT"]);
                String defecto = sf.cadena(dr["COLUMN_DEFAULT"]);
                bool isNullable = sf.boolean(dr["is_nullable"]);
                int maximumLength = sf.entero(dr["character_maximum_length"]);

                switch (tipo)
                {
                    case "PRI":
                        foreach (field fi in table.fields)
                        {
                            if (fi.Name.Equals(campo))
                            {
                                fi.isKey = true;
                                table.keyFields.Add(fi);
                                if (table.GetKey == "")
                                    table.GetKey = campo;
                            }

                        }
                        break;
                    case "MUL":
                        foreach (field fi in table.fields)
                        {
                            if (fi.Name.Equals(campo))
                            {
                                // its not clear that its a foreign key
                                // fi.isForeignKey = true;
                                table.notKeyFields.Add(fi);
                            }

                        }
                        break;
                    default:
                        foreach (field fix in table.fields)
                        {
                            if (fix.Name.Equals(campo))
                            {
                                table.notKeyFields.Add(fix);
                            }
                        }
                        break;
                }

                // ahora rellenamos los valores extra
                foreach (field fi in table.fields)
                {
                    if (fi.Name.Equals(campo))
                    {
                        if (!comentario.Equals(""))
                        {
                            fi.targetName = comentario;

                            fi.comment = comentario;
                            fi.defaultValue = defecto;
                            fi.allowNulls = isNullable;
                            fi.size = maximumLength;

                            // switch comment....
                            if (comentario.Contains("#date#"))
                            {
                                fi.targetType = field.fieldType._date;
                            }
                            if (comentario.Contains("#img#") | comentario.Contains("#image#"))
                            {
                                fi.targetType = field.fieldType._image;
                            }
                            if (comentario.Contains("#audio#"))
                            {
                                fi.targetType = field.fieldType._audio;
                            }
                            if (comentario.Contains("#money#"))
                            {
                                fi.targetType = field.fieldType._money;
                            }
                            if (comentario.Contains("#video#"))
                            {
                                fi.targetType = field.fieldType._video;
                            }
                            if (comentario.Contains("#doc#") | comentario.Contains("#document#"))
                            {
                                fi.targetType = field.fieldType._document;
                            }
                            if (comentario.Contains("#hide#"))
                            {
                                fi.invisible = true;
                                fi.targetType = field.fieldType._hidden;
                            }
                            if (comentario.Contains("#desc#"))
                            {
                                fi.isDescriptionInCombo = true;
                                table.fieldDescription = fi.Name;
                            }


                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#date#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#img#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#image#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#audio#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#money#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#video#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#doc#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#document#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#hide#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#desc#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);



                            // ahora reglas - now validation rules...
                            if (comentario.Contains("#url#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Url));
                            if (comentario.Contains("#email#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Email));

                            if (comentario.Contains("#requerido#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Required));

                            if (comentario.Contains("#requerido#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Required));

                            if (comentario.Contains("#alphaNumeric#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Alphanumeric));

                            if (comentario.Contains("#creditcard#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.CreditCard));

                            if (comentario.Contains("#date#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Date));

                            if (comentario.Contains("#decimal#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Decimal));

                            if (comentario.Contains("#ip#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.IP));

                            if (comentario.Contains("#isUnique#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.IsUnique));

                            if (comentario.Contains("#money#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Money));

                            if (comentario.Contains("#numeric#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Numeric));

                            if (comentario.Contains("#phone#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Phone));

                            if (comentario.Contains("#postal#"))
                                fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Postal));



                            if (comentario.Contains("#between"))
                            {
                                string IPMatchExp = @"#between(?:(?<t>[^#]*))";
                                Match theMatch = Regex.Match(comentario, IPMatchExp);
                                string st = "";
                                if (theMatch.Success)
                                    st = theMatch.Groups[1].Value;
                                if (st.Equals(""))
                                {

                                    fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Between));

                                }


                            }

                            if (comentario.Contains("#comparison"))
                            {
                                string IPMatchExp = @"#comparison(?:(?<t>[^#]*))";
                                Match theMatch = Regex.Match(comentario, IPMatchExp);
                                string st = "";
                                if (theMatch.Success)
                                    st = theMatch.Groups[1].Value;
                                if (st.Equals(""))
                                {

                                    fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Between));

                                }


                            }

                            if (comentario.Contains("#extension"))
                            {
                                string IPMatchExp = @"#extension(?:(?<t>[^#]*))";
                                Match theMatch = Regex.Match(comentario, IPMatchExp);
                                string st = "";
                                if (theMatch.Success)
                                    st = theMatch.Groups[1].Value;
                                if (st.Equals(""))
                                {

                                    fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Between));

                                }


                            }

                            if (comentario.Contains("#minLength"))
                            {
                                string IPMatchExp = @"#minLength(?:(?<t>[^#]*))";
                                Match theMatch = Regex.Match(comentario, IPMatchExp);
                                string st = "";
                                if (theMatch.Success)
                                    st = theMatch.Groups[1].Value;
                                if (st.Equals(""))
                                {

                                    fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Between));

                                }


                            }

                            if (comentario.Contains("#maxLength"))
                            {
                                string IPMatchExp = @"#maxLength(?:(?<t>[^#]*))";
                                Match theMatch = Regex.Match(comentario, IPMatchExp);
                                string st = "";
                                if (theMatch.Success)
                                    st = theMatch.Groups[1].Value;
                                if (st.Equals(""))
                                {

                                    fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Between));

                                }


                            }

                            if (comentario.Contains("#inList"))
                            {
                                string IPMatchExp = @"#inList(?:(?<t>[^#]*))";
                                Match theMatch = Regex.Match(comentario, IPMatchExp);
                                string st = "";
                                if (theMatch.Success)
                                    st = theMatch.Groups[1].Value;
                                if (st.Equals(""))
                                {

                                    fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Between));

                                }


                            }

                            if (comentario.Contains("#regexp"))
                            {
                                string IPMatchExp = @"#regexp(?:(?<t>[^#]*))";
                                Match theMatch = Regex.Match(comentario, IPMatchExp);
                                string st = "";
                                if (theMatch.Success)
                                    st = theMatch.Groups[1].Value;
                                if (st.Equals(""))
                                {

                                    fi.validationRules.Add(new validationRule(validationRule.typeOfValidation.Between));

                                }


                            }


                            //  comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#between(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#url#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#email#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#requerido#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#required#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#alphaNumeric#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#creditcard#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#date#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#decimal#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#ip#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#isUnique#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#money#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#numeric#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#phone#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#postal#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);


                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#comparison(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#between(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#extension(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#minlength(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#maxlength(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#inList(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            comentario = System.Text.RegularExpressions.Regex.Replace(comentario, @"#regexp(?:(?<t>[^#]*))#", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);


                        }




                        if (comentario != "")
                            fi.targetName = comentario.Trim();

                    }





                }

            }




        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");

        }
        finally
        {
            conexion.Close();
        }
    }  // getKeys




    public List<relation> getRelations(string cadconexion, string database)
    {
        MySqlConnection conexion = null;
        try
        {

            List<relation> lista = new List<relation>();


            string sql = @"SELECT * FROM information_schema.key_column_usage
 where constraint_schema = '{0}'
 and referenced_table_name <> ''";

            conexion = new MySqlConnection(cadconexion);
            miComando = new MySqlCommand(string.Format(sql, database));
            miComando.Connection = conexion;
            conexion.ConnectionString = cadconexion;
            conexion.Open();

            // System.Data.DataTable dt = new System.Data.DataTable();
            miLector = miComando.ExecuteReader();

            while (miLector.Read())
            {
                relation rel = new relation();

                //rel.name = sf.cadena(miLector["constraint_name"]) ;

                rel.name = sf.cadena(miLector["table_name"]) + "_" + sf.cadena(miLector["referenced_table_name"]);
                rel.childTable = sf.cadena(miLector["table_name"]);
                rel.childField = sf.cadena(miLector["column_name"]);

                rel.parentTable = sf.cadena(miLector["referenced_table_name"]);
                rel.parentField = sf.cadena(miLector["referenced_column_name"]);

                // if the name of fields its equal...
                if (rel.childField.ToLower().Equals(rel.parentField.ToLower()))
                    rel.relationType = relation.typeOfRelation.hasMany;
                else
                    rel.relationType = relation.typeOfRelation.hasOne;

                lista.Add(rel);
            }
            return lista;


        }
        catch (Exception ep)
        {
            //  lo.tratarError(ep, "Error en dbClass.new", "");
            return null;
        }
        finally
        {
            conexion.Close();
        }
    }   // getRelations







    // -----------------------------------------------------------------------
    // code to copy




    // Public Function getkeys(ByRef conexion As MySql.Data.MySqlClient.SqlConnection, ByVal database As String, ByVal mostrarLog As Boolean)

    //    'Dim db As New SqlServer.WrSqlServerDatabase("192.168.0.135\SQL2005", "svNursingAdmin")
    //    'db.GetTables(New WrCredentials("sa", "xx"), WrVendor.ELEM_OWNER.USER)
    //    'Dim cols As WrColumn()
    //    'cols = db.GetColumns("AllTypes", New WrCredentials("sa", "xx"))


    //    Dim sql As String

    //    For Each tabla As lb.tabla In proyectoActual.tablas

    //        sql = String.Format("SELECT column_name FROM information_schema.key_column_usage WHERE TABLE_NAME = '{0}' AND CHARINDEX('PK', CONSTRAINT_NAME) <> 0", tabla.nombre)
    //        '            sql = String.Format("select s.name as TABLE_SCHEMA, t.name as TABLE_NAME, k.name as CONSTRAINT_NAME, c.name as COLUMN_NAME, ic.key_ordinal AS ORDINAL_POSITION " & _
    //        '"  from sys.key_constraints as k " & _
    //        '"  join sys.tables as t " & _
    //        '"    on t.object_id = k.parent_object_id " & _
    //        '"  join sys.schemas as s " & _
    //        '"    on s.schema_id = t.schema_id " & _
    //        '"  join sys.index_columns as ic " & _
    //        '"    on ic.object_id = t.object_id " & _
    //        '"   and ic.index_id = k.unique_index_id " & _
    //        '"  join sys.columns as c " & _
    //        '"    on c.object_id = t.object_id " & _
    //        '"   and c.column_id = ic.column_id " & _
    //        '" where k.type = 'PK' " & _
    //        '" and t.name like '{0}'", tabla.nombre)

    //        Try
    //            Dim cmd As New SqlClient.SqlCommand()
    //            Dim myReader As SqlClient.SqlDataReader
    //            cmd.Connection = conexion
    //            cmd.CommandType = CommandType.Text



    //            cmd.CommandText = sql
    //            myReader = cmd.ExecuteReader()
    //            Do While myReader.Read()
    //                'MsgBox(myReader.GetString(3))
    //                For Each campo As lb.campo In tabla.campos
    //                    If campo.nombre = myReader.GetString(0) Then
    //                        campo.isKey = True
    //                    End If
    //                Next
    //            Loop


    //            cmd = Nothing
    //            myReader.Close()
    //            myReader = Nothing
    //        Catch ex As Exception

    //        End Try






    //    Next


    //End Function







    //// Retrieve the list of a table's indices.
    //private void GetIndexes(OleDbConnection connection, string tableName, IList<Index> indices)
    //{
    //    String[] restrictions = new string[] { null, null, null, null, tableName };
    //    DataTable schema;
    //    // Open the schema information for the indices.
    //    schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Indexes, restrictions);
    //    // Enumerate the table's indices.
    //    foreach (DataRow row in schema.Rows)
    //    {
    //        // Create a new index.
    //        Index dbIndex = new Index();
    //        // Append the index name.
    //        dbIndex.Name = row["INDEX_NAME"].ToString();
    //        dbIndex.OriginalName = row["INDEX_NAME"].ToString();
    //        // Append the index's uniqueness.
    //        dbIndex.Unique = (bool)row["UNIQUE"];
    //        // Specify the index type. 
    //        dbIndex.IndexType = (bool)row["PRIMARY_KEY"] == true ? IndexType.PrimaryKey : IndexType.Index;
    //        // Create an index column object.
    //        IndexColumn column = new IndexColumn();
    //        column.Name = row["COLUMN_NAME"].ToString();
    //        // Specify whether the index is descending.
    //        column.Descending = (Int32.Parse(row["COLLATION"].ToString()) == 2) ? true : false;
    //        dbIndex.Columns.Add(column);
    //        // Append the index to the list.
    //        indices.Add(dbIndex);
    //    }
    //}

    //// Retrieve the list of a table's foreign keys.
    //private void GetForeignKeys(OleDbConnection connection, string tableName, IList<ForeignKey> foreignKeys)
    //{
    //    String[] restrictions = new string[] { null };
    //    DataTable schema;
    //    // Open the schema information for the foreign keys.
    //    schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions);
    //    // Enumerate the table's foreign keys.
    //    foreach (DataRow row in schema.Rows)
    //    {
    //        ForeignKey dbForeignKey = new ForeignKey();
    //        dbForeignKey.Name = row["FK_NAME"].ToString();
    //        dbForeignKey.OriginalName = row["FK_NAME"].ToString();

    //        dbForeignKey.FKTableName = row["FK_TABLE_NAME"].ToString();
    //        ForeignKeyColumn fkc = new ForeignKeyColumn();
    //        fkc.Name = row["FK_COLUMN_NAME"].ToString();
    //        dbForeignKey.FKColumns.Add(fkc);
    //        dbForeignKey.FKTableSchema = schema.ToString();

    //        dbForeignKey.PKTableName = row["PK_TABLE_NAME"].ToString();
    //        ForeignKeyColumn pkc = new ForeignKeyColumn();
    //        pkc.Name = row["PK_COLUMN_NAME"].ToString();
    //        dbForeignKey.PKColumns.Add(pkc);
    //        dbForeignKey.PKTableSchema = schema.ToString();

    //        foreignKeys.Add(dbForeignKey);
    //    }
    //}






}


