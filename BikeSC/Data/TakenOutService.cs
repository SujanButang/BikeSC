using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeSC.Data
{
    public class TakenOutService
    {
        private static void SaveTakeOutItems(List<TakenOutModel> takenOut)
        {
            string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string GetAppItemsTakenOutFilePath = Utils.GetAppItemsTakenOutFilePath();
            if (!Directory.Exists(appDataDirectoryPath))
            {
                Directory.CreateDirectory(appDataDirectoryPath);
            }
            var json = JsonSerializer.Serialize(takenOut);
            File.WriteAllText(GetAppItemsTakenOutFilePath, json);
        }
        public static List<TakenOutModel> WriteTakenOutData(string name, int quantity, string takenBy,string approvedBy, DateTime date)
        {

            List<TakenOutModel> items = ReadTakenOutData();
            items.Add(
                new TakenOutModel
                {
                    Name = name,
                    Quantity = quantity,
                    TakenBy = takenBy,
                    ApprovedBy = approvedBy,
                    Date = DateTime.Now,
                }
            );
            SaveTakeOutItems(items);
            return items;
        }
        public static List<TakenOutModel> ReadTakenOutData()
        {
            string appItemsTakenOutFilePath = Utils.GetAppItemsTakenOutFilePath();

            if (!File.Exists(appItemsTakenOutFilePath))
            {
                return new List<TakenOutModel>();
            }
            var json = File.ReadAllText(appItemsTakenOutFilePath);
            
            return JsonSerializer.Deserialize<List<TakenOutModel>>(json);
        }

       
        public static List<TakenOutModel> TakeOutUpdate(Guid id, string name, int quantity, string takenBy,string approvedBy, DateTime date)
        {
            List<TakenOutModel> items = ReadTakenOutData();
            TakenOutModel item = items.FirstOrDefault(x => x.Id == id);
            WriteTakenOutData(name, quantity, takenBy,approvedBy, date);
            return items;
        }
    }
}
