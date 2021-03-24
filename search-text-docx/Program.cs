using System;
using System.IO;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;

namespace search_text_docx
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
                    Console.WriteLine("Usage: dotnet run <path to folder> <string to search for>");
            else 
                {

                    foreach (string file in Directory.EnumerateFiles(args[0], "*.docx",SearchOption.AllDirectories))
                    {  

                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(file, true))
                        {
                
                        string docText = null;
                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                        {
                            docText = sr.ReadToEnd();
                        }

                        MatchCollection mc = Regex.Matches(docText, args[1], RegexOptions.IgnoreCase);

                        foreach (Match match in mc)
                                Console.WriteLine("Found '{0}' at position {1} in file {2}", match.Value, match.Index,file);

                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                        {
                            sw.Write(docText);
                        }

                    }
                }
            }
        }
    }
}
