using System;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace create_simple_docx
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("dotnet run <DOCX filename>");
            } else {
                using (WordprocessingDocument wordDocument =
                    WordprocessingDocument.Create(args[0], WordprocessingDocumentType.Document))
                { 
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                    // Create the document structure and add some text.
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    run.AppendChild(new Text("Create text in body - CreateWordprocessingDocument"));

                    //Add paragraph
                    para = body.AppendChild(new Paragraph());
                    //Add region of text with same formatting
                    run = para.AppendChild(new Run());
                    //Add text
                    run.AppendChild(new Text("Example taken from here: "));  
                    //Add line break
                    run.AppendChild(new Break());

                    //Add hyperlink style to region
                    run = para.AppendChild(new Run(
                                                new RunProperties(
                                                    new RunStyle { Val = "Hyperlink", }, 
                                                    new Underline { Val = UnderlineValues.Single },
                                                    new Color { ThemeColor = ThemeColorValues.Hyperlink })));            
                    //Add hyperlink
                    run.AppendChild(
                            new Hyperlink(new Run(new Text("Microsoft Docs")))
                            {
                                Anchor = "Create a word processing document by providing a file name",
                                DocLocation = "https://docs.microsoft.com/en-us/office/open-xml/how-to-create-a-word-processing-document-by-providing-a-file-name",
                            }
                    );
                
                    run = para.AppendChild(new Run());
                    run.AppendChild(new Break());
                    run.AppendChild(new Text("Back to normal text."));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());
                    run.AppendChild(new Text("Or even a new paragraph!"));
                }
            }
        }
    }
}
