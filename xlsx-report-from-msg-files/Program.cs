using System;
using MsgReader;
using ClosedXML.Excel;
using System.IO;

namespace xlsx_report_from_msg_files
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 1) 
            {

                IXLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Email Data");

                worksheet.Cell(1,1).Value = "Date";
                worksheet.Cell(1,2).Value = "From";
                worksheet.Cell(1,3).Value = "To";
                worksheet.Cell(1,4).Value = "Cc";
                worksheet.Cell(1,5).Value = "Bcc";
                worksheet.Cell(1,6).Value = "Subject";
                worksheet.Cell(1,7).Value = "TextContent";
                worksheet.Cell(1,8).Value = "Filename";

                int line = 2; 

                foreach (string file in Directory.EnumerateFiles(args[0], "*.msg",SearchOption.AllDirectories))
                {
                
                    using (var msg = new MsgReader.Outlook.Storage.Message(file))
                    {
                            worksheet.Cell(line,1).Value = msg.SentOn;
                            worksheet.Cell(line,2).Value = (!msg.Sender.Email.Equals("") ? msg.Sender.Email : msg.Sender.DisplayName);
                            worksheet.Cell(line,3).Value = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.To, false, false);
                            worksheet.Cell(line,4).Value = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.Cc, false, false);
                            worksheet.Cell(line,5).Value = msg.GetEmailRecipients(MsgReader.Outlook.RecipientType.Bcc, false, false);
                            worksheet.Cell(line,6).Value = msg.Subject;
                            worksheet.Cell(line,7).Value = msg.BodyText;
                            worksheet.Cell(line,7).Style.Alignment.WrapText = false;
                            worksheet.Cell(line,7).Value = file;
                    }

                    line++;
                }

                workbook.SaveAs(Path.Combine(args[0],"report.xlsx"));
            }
            else 
            {
                Console.WriteLine("Usage: dotnet run <path to MSG files>");
            }
        }
    }
}
