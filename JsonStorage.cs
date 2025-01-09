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
            string json = JsonSerializer.Serialize(items, JsonOptions);
            await File.WriteAllTextAsync(FilePath, json);
        }

        public static async Task<List<SavedItem>> LoadItemsAsync()
        {
            if (!File.Exists(FilePath))
                return new List<SavedItem>();

            string json = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<SavedItem>>(json) ?? new List<SavedItem>();
        }
    }
}