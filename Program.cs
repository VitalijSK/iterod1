using System;
using Newtonsoft.Json;
using CsvHelper.Configuration.Attributes;

namespace l1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args[0] == "-i" && args[2] == "-o" && args[4] == "-f")
                {
                    var data = Task.read(args[1]);
                    Group g = new Group() { st = data };
                    g.result();
                    if (args[5] == "JSON")
                        Task.writeJSON(g, args[3] + ".json");
                    if (args[5] == "Excel")
                        Task.writeExel(g, args[3] + ".xlsm");
                }
                else
                    throw new Exception("bad params");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Работа закончена");
        }
    }
}
