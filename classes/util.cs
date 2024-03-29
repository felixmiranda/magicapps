//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.3603
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.IO;

using System.Text.RegularExpressions;

using System.Media;

public static class util
{

    public static string HomeDirectory
    {
        get { return System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("HOME"), System.String.Empty); }

        
    }

    //$XDG_CONFIG_HOME/f-spot or $HOME/.config/f-spot
    //private static string xdg_config_home = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
    //public static string base_dir = System.IO.Path.Combine (xdg_config_home, "f-spot");

    public static string conf_dir = System.Environment.CurrentDirectory;
    public static string projects_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "projects");
    
    //public static string templates_dir =        System.IO.Path.Combine(System.Environment.CurrentDirectory, System.Configuration.ConfigurationManager.AppSettings["templatesPath"].ToString());
    //public static string projectTemplates_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, System.Configuration.ConfigurationManager.AppSettings["projectTemplatesPath"].ToString());

   // public static string templates_dir =  System.Configuration.ConfigurationManager.AppSettings["templatesPath"].ToString() ;
    //public static string projectTemplates_dir =  System.Configuration.ConfigurationManager.AppSettings["projectTemplatesPath"].ToString() ;

    // volvemos a colocar fijos los directorios de los templates..
    public static string basicTemplates_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "templates\\basic").ToString();
    public static string templates_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "templates").ToString();
    public static string projectTemplates_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "templates\\projectTemplates").ToString();
   
    public static string images_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "images");
    public static string sound_dir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "sounds");

    

    public static project actualProject;


    public static String loadFile(String path)
    {
        try
        {

          //  string apppath = (new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).DirectoryName;

            StreamReader streamReader = new StreamReader(path);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            return text;
        }
        catch (Exception)
        {

            //  throw;
        }
        return "";

    }

    public static String saveTextToFile(String path, string text)
    {
        try
        {
            //if (!path.EndsWith("\\"))
            //    path += "\\";
            
            //StreamWriter streamWriter = new StreamWriter(path,false,System.Text.Encoding.Unicode);
            StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("iso-8859-1"));
            streamWriter.Write(text);
            streamWriter.Close();
            return "";
        }
        catch (Exception exc)
        {
            return exc.Message;
            //  throw;
        }
        return "";

    }


    public static String searchInTemplate(String textOfTemplate, string regex)
    {
        string IPMatchExp = @"<namefile>(?:(?<t>[^<]*))";

        Match theMatch = Regex.Match(textOfTemplate, IPMatchExp);

        if (theMatch.Success)
        {
            return theMatch.Groups[1].Value;
        }
        return "";
    } // searchInTemplate



    // get the variables from the template
    // its useful to knowing where to save the file or if it applies to all tables..
    public static variablesTemplate getVariablesFromTemplate(String textOfTemplate)
    {
        variablesTemplate var = new variablesTemplate();

        string IPMatchExp = @"<nameFile>(?:(?<t>[^<]*))";

        Match theMatch = Regex.Match(textOfTemplate, IPMatchExp);

        // mirar luego si compilando la expresion regular va mas rapido...

        if (theMatch.Success)
            var.namefile = theMatch.Groups[1].Value;

        // extensionFile
        theMatch = Regex.Match(textOfTemplate, "<extensionFile>(?:(?<t>[^<]*))");
        if (theMatch.Success)
            var.extensionFile = theMatch.Groups[1].Value;

        // languageGenerated
        theMatch = Regex.Match(textOfTemplate, "<languageGenerated>(?:(?<t>[^<]*))");
        if (theMatch.Success)
            var.languageGenerated = theMatch.Groups[1].Value;


        // description
        theMatch = Regex.Match(textOfTemplate, "<description>(?:(?<t>[^<]*))");
        if (theMatch.Success)
            var.description = theMatch.Groups[1].Value;

        // targetDirectory
        theMatch = Regex.Match(textOfTemplate, "<targetDirectory>(?:(?<t>[^<]*))");
        if (theMatch.Success)
            var.targetDirectory = theMatch.Groups[1].Value;

        // appliesToAllTables
        theMatch = Regex.Match(textOfTemplate, "<appliesToAllTables>(?:(?<t>[^<]*))");
        if (theMatch.Success)
            var.appliesToAllTables = theMatch.Groups[1].Value;




        return var;
    } // getVariablesFromTemplate


    // delete the variables from the template
    // once readed the variables are not needed..
    public static string deleteVariablesFromTemplate(String textOfTemplate)
    {
        string finalText = textOfTemplate;
        finalText = deleteVariableFromString(finalText, "nameFile");
        finalText = deleteVariableFromString(finalText, "extensionFile");
        finalText = deleteVariableFromString(finalText, "languageGenerated");
        finalText = deleteVariableFromString(finalText, "description");
        finalText = deleteVariableFromString(finalText, "targetDirectory");
        finalText = deleteVariableFromString(finalText, "appliesToAllTables");

        return finalText;
    } // deleteVariablesFromTemplate


    // delete a string from another string..
    public static string deleteVariableFromString(String textOfTemplate, string variable)
    { 
        
        string finalText = textOfTemplate;
        try
        {
            int i = 0;
            int j = 0;
            string initialTag = "<" + variable + ">";
            string endTag = "</" + variable + ">";
            while (finalText.Contains(initialTag))
            {
                i = finalText.IndexOf(initialTag);
                j = finalText.IndexOf(endTag);
                if (i != -1 && j != -1)
                {
                    finalText = finalText.Remove(i, (j - i) + endTag.Length);
                }
                else
                {
                    return textOfTemplate;
                }
                    
            }

        }
        catch (Exception exc)
        {
            return textOfTemplate;   
            
        }      
      
        return finalText;
    } // deleteVariableFromString


    public static string ExtractFilename(string filepath)
    {
        // If path ends with a "\", it's a path only so return String.Empty.
        if (filepath.Trim().EndsWith(@"\"))
            return String.Empty;

        // Determine where last backslash is.
        int position = filepath.LastIndexOf('\\');
        // If there is no backslash, assume that this is a filename.
        if (position == -1)
        {
            // Determine whether file exists in the current directory.
            if (File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filepath))
                return filepath;
            else
                return String.Empty;
        }
        else
        {
            // Determine whether file exists using filepath.
            if (File.Exists(filepath))
                // Return filename without file path.
                return filepath.Substring(position + 1);
            else
                return String.Empty;
        }
    } // extractFileName


    public static string ExtractLastDirectory(string filepath)
    {
        try
        {
            // If path ends with a "\", it's a path only so return String.Empty.
            if (filepath.Trim().EndsWith(@"\"))
                filepath = filepath.Remove(filepath.Length - 1);

            // Determine where last backslash is.
            int position = filepath.LastIndexOf('\\');
            // If there is no backslash, assume that this is a filename.
            if (position == -1)
            {
                return String.Empty;
            }
            else
            {
                return filepath.Substring(position + 1, filepath.Length - position - 1);

            }
        }
        catch (Exception)
        {
            return "";
            throw;
        }
        return "";

    } // extractLastDirectory

    public static void playSimpleSound(string path)
    {
        SoundPlayer simpleSound = new SoundPlayer(path);
        simpleSound.Play();

       

    } // playSimpleSound

    public static long CountLinesInString(string s)
    {
        long count = 1;
        int start = 0;
        while ((start = s.IndexOf('\n', start)) != -1)
        {
            count++;
            start++;
        }
        return count;
    } // CountLinesInString


    public static void copyDirectory(string Src, string Dst)
    {
        String[] Files;

        if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
            Dst += Path.DirectorySeparatorChar;
        if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
        Files = Directory.GetFileSystemEntries(Src);
        foreach (string Element in Files)
        {
            if (Element.IndexOf("svn") <= 0)
            {
                // Sub directories

                if (Directory.Exists(Element))
                    copyDirectory(Element, Dst + Path.GetFileName(Element));
                // Files in directory

                else
                {
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
                }
            }


        }


    }// copyDirectory

}
 
