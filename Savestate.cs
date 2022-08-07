using static Newtonsoft.Json.Formatting;
using static Newtonsoft.Json.JsonConvert;

namespace Minisavestates {
	class Savestate {

		static string dir = Directory.GetCurrentDirectory();
		public Dictionary<string, dynamic> dat;

		public Savestate() {
			Environment.CurrentDirectory = dir;

			string json = File.ReadAllText("minisavestates-saved.json");

			dat = DeserializeObject<Dictionary<string, dynamic>>(json);
		}

		public void SetValue(string key, dynamic value) {
			dat["savedPlayerData"][key] = value;
			Console.WriteLine($"Setting {dat["savedPlayerData"]} to {dat["savedPlayerData"][key]} ({dat["savedPlayerData"][key].GetType()})");
		}

		public void CheckValue(string key) {
			Console.WriteLine($"{dat["savedPlayerData"]} : {dat["savedPlayerData"][key]} ({dat["savedPlayerData"][key].GetType()})");
		}

		public override string ToString() {
			var output = "";
			foreach (KeyValuePair<string, dynamic> pair in dat) {
				output += $"{pair.Key} : {pair.Value} ({pair.Value.GetType()})\n";
				//output += $"{pair.Value.GetType()}\n";


			}

			return output;
		}

		public void Save() {
			Environment.CurrentDirectory = dir;

			string json = SerializeObject(dat, Indented);

			File.WriteAllText("minisavestates-saved.json", json);

			Console.WriteLine("Saved file");
		}

	}
}