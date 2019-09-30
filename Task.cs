using CsvHelper;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using ClosedXML.Excel;

namespace l1
{
    public class Task
    {
        public static List<Student> read(string path){
            using (StreamReader reader = new StreamReader(path)){
                using (CsvReader csvReader = new CsvReader(reader)){
                    csvReader.Configuration.Delimiter = ",";
                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.MissingFieldFound = null;
                    var data = csvReader.GetRecords<Student>().ToList();
                    foreach (Student s in data)
                        s.culc();
                    return data;
                }
            }
        }

        public static void writeJSON(Group group, string path){
            string data = JsonConvert.SerializeObject(group);
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(data);
            }
        }

        public static void writeExel(Group group, string path)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");
            worksheet.Cell("A" + 1).Value = "Фамилия";
            worksheet.Cell("B" + 1).Value = "Имя";
            worksheet.Cell("C" + 1).Value = "Отчество";
            worksheet.Cell("D" + 1).Value = "Средняя";
            int i = 0;
            for (i = 0; i < group.st.Count; i++){
                worksheet.Cell("A" + (i + 2)).Value = group.st[i].firstName;
                worksheet.Cell("B" + (i + 2)).Value = group.st[i].lastName;
                worksheet.Cell("C" + (i + 2)).Value = group.st[i].rlyLastName;
                worksheet.Cell("D" + (i + 2)).Value = group.st[i].avg;
            }
            worksheet.Cell("A" + (i + 2)).Value = "Математика";
            worksheet.Cell("A" + (i + 3)).Value = "Физика";
            worksheet.Cell("A" + (i + 4)).Value = "Химия";
            worksheet.Cell("A" + (i + 5)).Value = "Черчение";
            worksheet.Cell("A" + (i + 6)).Value = "Алгоритм";
            worksheet.Cell("A" + (i + 7)).Value = "Средняя группа";
            worksheet.Cell("B" + (i + 2)).Value = group.avgMat;
            worksheet.Cell("B" + (i + 3)).Value = group.avgPhy;
            worksheet.Cell("B" + (i + 4)).Value = group.avgChem;
            worksheet.Cell("B" + (i + 5)).Value = group.avgDraw;
            worksheet.Cell("B" + (i + 6)).Value = group.avgAl;
            worksheet.Cell("B" + (i + 7)).Value = group.avgAvg;
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs("data.xlsx");
        }
    }
}
