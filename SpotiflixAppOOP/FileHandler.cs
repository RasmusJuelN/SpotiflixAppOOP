using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace SpotiflixAppOOP
{
    internal class FileHandler
    {
        // Saves data to the .json file
        public void SaveData(string path, object data)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);

        }


        // Loads data from the .json file and returns it
        public T? LoadData<T>(string path)
        {
            string load = File.ReadAllText(path);
            T? data = JsonSerializer.Deserialize<T>(load);
            return data;
        }
    }
}
