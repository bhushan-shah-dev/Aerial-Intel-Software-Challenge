using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SoybeanRainfall.DAL
{
    public class DataRepository
    {
        private static DataRepository _instance = null;
        
        private DataRepository()
        {
            string currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string soybeanDataFilePath = currentDir + "/SoybeanData.json";

            dynamic jsonData;
            using (StreamReader sr = new StreamReader(soybeanDataFilePath))
            {
                string json = sr.ReadToEnd();
                jsonData = JsonConvert.DeserializeObject(json);
            }

            Data = new List<DataItem>();
            foreach(dynamic item in jsonData.data)
            {
                Data.Add(new DataItem
                {
                    StateANSI = item["state_ansi"],
                    StateAlpha = item["state_alpha"],
                    StateName = item["state_name"],
                    CountyANSI = item["county_ansi"],
                    CountyName = item["county_name"],
                    ProduceValue = Int32.Parse(item["Value"].ToString(), System.Globalization.NumberStyles.AllowThousands)
                });
            }
        }

        public static DataRepository Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataRepository();
                }
                return _instance;
            }
        }

        public List<DataItem> Data { get; set; }
    }
}
