using SimpleJson;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class Requirements
{
    public static readonly Dictionary<string, Dictionary<string, int>> hammerCreatorShopItems = new Dictionary<string, Dictionary<string, int>>();
    public static readonly Dictionary<string, string> craftingStationRequirements = new Dictionary<string, string>();

    public static void LoadRequirements()
    {
        string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(basePath, "MissingPieces/requirements.json");
        if (!File.Exists(filePath))
        {
            ZLog.Log("File requirements.json not found!");
            return;
        }
        string json;
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new StreamReader(fileStream))
            {
                json = reader.ReadToEnd();
            }
        }

        JsonArray array = SimpleJson.SimpleJson.DeserializeObject<JsonArray>(json);

        foreach (JsonObject obj in array)
        {
            string name = obj["name"].ToString();
            string craftingStation = obj["craftingstation"].ToString();

            Dictionary<string, int> requirements = new Dictionary<string, int>();

            JsonObject requirementsJson = (JsonObject)obj["requirements"];

            foreach (string key in requirementsJson.Keys)
            {
                requirements[key] = int.Parse(requirementsJson[key].ToString());
            }

            craftingStationRequirements[name] = craftingStation;
            hammerCreatorShopItems[name] = requirements;
        }
    }
}