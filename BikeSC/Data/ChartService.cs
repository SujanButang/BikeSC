using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSC.Data
{
    internal class ChartService
    {
        public static Dictionary< string,double> GetData()
        {
            
            List < TakenOutModel > takenOut = TakenOutService.ReadTakenOutData();
            Dictionary< string,double> takenOutDictionary = new Dictionary<string,double>();
           foreach (var item in takenOut)
            {
                if (takenOutDictionary.ContainsKey(item.Name)){
                    takenOutDictionary[item.Name] = takenOutDictionary[item.Name]+item.Quantity;
                }
                else
                {
                    takenOutDictionary[item.Name] = item.Quantity;
                }
            }
            return takenOutDictionary;
        }
        

       
    }
}
