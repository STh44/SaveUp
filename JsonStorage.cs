using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using SaveUp.Models;

namespace SaveUp.Utils
{
    public static class JsonStorage
    {
        private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "items.json");
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public static async Task SaveItemsAsync(List<SavedItem> items)
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    // Erstelle die Datei, falls sie nicht existiert
                    using (FileStream fs = File.Create(FilePath))
                    {
                        // Leere Datei erstellen
                    }
                }

                string json = JsonSerializer.Serialize(items, JsonOptions);
                await File.WriteAllTextAsync(FilePath, json);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error saving items: {ex.Message}");
            }
        }

        public static async Task<List<SavedItem>> LoadItemsAsync()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<SavedItem>();

                string json = await File.ReadAllTextAsync(FilePath);
                return JsonSerializer.Deserialize<List<SavedItem>>(json) ?? new List<SavedItem>();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Error loading items: {ex.Message}");
                return new List<SavedItem>();
            }
        }
    }
}


