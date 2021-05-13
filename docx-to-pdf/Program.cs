/* 
* TO USE THIS EXAMPLE CODE YOU MUST HAVE LIBREOFFICE PORTABLE VERSION ON YOUR MACHINE
* ALL CREDIT FOR THIS SOLUTION IS DUE TO https://github.com/smartinmedia
* DEVELOPERS OF THE NUGET PACKAGE https://www.nuget.org/packages/DocXToPdfConverter/
*/

using System;
using System.IO;
using System.Reflection;
using DocXToPdfConverter;
using DocXToPdfConverter.DocXToPdfHandlers;

namespace docx_to_pdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string executableLocation = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);

            //Here are the 2 test files as input. They contain placeholders
            string docxLocation = Path.Combine(executableLocation, "Test-Template.docx");

            string locationOfLibreOfficeSoffice =
                @"C:\LibreOfficePortable\LibreOfficePortable.exe";

            var test = new ReportGenerator(locationOfLibreOfficeSoffice);

            //Convert from DOCX to PDF
            test.Convert(docxLocation, Path.Combine(Path.GetDirectoryName(docxLocation), 
            "Test-Template-out.pdf"), null);

        }
    }
}
