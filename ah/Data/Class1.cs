using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ah.Data
{
    public class Prueba
    {
        static public double max = 0;

        public static async void Write(double max)
        {
            try
            {
                var datos = new Dictionary<string, double>
                {
                    ["Record"] = max
                };

                var jsonString = JsonSerializer.Serialize(datos);

                var path = Path.Combine(FileSystem.AppDataDirectory, "Saves.json");

                await File.WriteAllTextAsync(path, jsonString);

            }
            catch
            {
                //No existe
            }
        }


        public static async void Read()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "Saves.json");

            if (File.Exists(path))
            {
                var jsonString = await File.ReadAllTextAsync(path);
                var datos = JsonSerializer.Deserialize<Dictionary<string, double>>(jsonString);
                max = datos["Record"];
            }
            else
            {
                //El archivo no existe
            }
        }
    }
}
