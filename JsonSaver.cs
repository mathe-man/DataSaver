using System.IO;
using Newtonsoft.Json;

namespace DataSaver
{
    public static class JsonSaver
    {
        public static void SaveToFile<T>(T content, string filePath)
        {
            try
            {
                if (File.Exists(filePath))  //Only appen when the file is already existent
                {
                    // Serialize the content into Json format
                    string jsonString = JsonConvert.SerializeObject(content, Formatting.Indented);
                    // Write the json formated content in the specified file
                    File.WriteAllText(filePath, jsonString);
                }
                else                        // if the file doesn't exist, it will be created and the function are recalled
                {
                    FileStream fs = File.Create(filePath);
                    fs.Close();
                    SaveToFile<T>(content, filePath);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(filePath.Remove(filePath.LastIndexOf("/")));
                SaveToFile<T>(content, filePath);
            }
        }
    }
}