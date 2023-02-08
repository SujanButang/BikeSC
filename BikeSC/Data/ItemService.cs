
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BikeSC.Data
{
    internal class ItemService
    {
        private static void SaveAll(List<ItemsModel> items)
        {
            string appDataDirectoryPath = Utils.GetAppDirectoryPath();
            string GetAppItemsFilePath = Utils.GetAppItemsFilePath();
            if (!Directory.Exists(appDataDirectoryPath))
            {
                Directory.CreateDirectory(appDataDirectoryPath);
            }
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(GetAppItemsFilePath, json);
        }

        
        public static List<ItemsModel> WriteData(string name, int quantity, string createdBy, DateTime date)
        {

            List<ItemsModel> items = ReadData();
            items.Add(
                new ItemsModel
                {
                    Name = name,
                    Quantity = quantity,
                    CreatedBy = createdBy,
                    Date = DateTime.Now,
                }
            );
            SaveAll(items);
            return items;
        }

       
        public static List<ItemsModel> ReadData()
        {
            string appItemsFilePath = Utils.GetAppItemsFilePath();

            if (!File.Exists(appItemsFilePath))
            {
                return new List<ItemsModel>();
            }
            var json = File.ReadAllText(appItemsFilePath);
            return JsonSerializer.Deserialize<List<ItemsModel>>(json);
        }

        
        public static List<ItemsModel> Update(Guid id, string name, int quantity, string createdBy, DateTime date)
        {
            List<ItemsModel> items = ReadData();
            ItemsModel itemsToUpdate = items.FirstOrDefault(x => x.Date == date);

            if (itemsToUpdate == null)
            {
                throw new Exception("Todo not found.");
            }
            itemsToUpdate.Name = name;
            itemsToUpdate.Quantity = quantity;
            itemsToUpdate.CreatedBy = createdBy;
            itemsToUpdate.Date = date;
            SaveAll(items);
            return items;
        }

        
      
        public static void DeleteByItemId(Guid userId)
        {
            string _filePath = "D:\\AD\\BikeSC\\items1.json";
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
        public static List<ItemsModel> Delete(Guid id)
        {
            List<ItemsModel> items = ReadData();
            ItemsModel item = items.FirstOrDefault(x => x.Id == id);

            if (items == null)
            {
                throw new Exception("Item not found.");
            }

           
            items.Remove(item);
            SaveAll(items);
            return items;
        }

        public static List <ItemsModel> TakeOut(Guid id,string createdBy,string approvedBy, int quantity)
        {
            List<ItemsModel> items = ReadData();
            ItemsModel item = items.FirstOrDefault(x => x.Id == id);
            item.Quantity = item.Quantity - quantity;
            Update(item.Id, item.Name, item.Quantity, item.CreatedBy, item.Date);
            TakenOutService.TakeOutUpdate(id, item.Name, quantity, createdBy,approvedBy, DateTime.Now);
            return items;
           
        }
        
    }
}
