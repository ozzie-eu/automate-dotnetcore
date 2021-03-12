using System;
using ClosedXML.Excel;

namespace save_csv_to_excel
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) 
            {
                Console.WriteLine("usage: dotnet run <target CSV file>");
            } 
            else
            {
                string[] lines = System.IO.File.ReadAllLines(args[0]);

                IXLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("CSV Data");

                for (int i = 1; i <= lines.Length; i++)
                {
                    string line = lines[i-1];
                    string[] data = line.Split(';');

                    for (int j = 1; j <= data.Length; j++) 
                    {
                        worksheet.Cell(i,j).Value = data[j-1];
                    }
                }

                workbook.SaveAs("import.xlsx");
            }
            
        }
    }
}
