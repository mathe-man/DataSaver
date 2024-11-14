using System.IO;
using Newtonsoft.Json;

namespace DataSaver
{
    public static class JsonLoader
    {
        public static T LoadFromFile<T>(string fileName)
        {
            // Read the file content to a variable
            string jsonString = File.ReadAllText(fileName);
            // Deserialize the content
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}