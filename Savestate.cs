using Newtonsoft.Json;

namespace Minisavestates {
	class Savestate {

		static string dir = Directory.GetCurrentDirectory();
		public Dictionary<string, dynamic> dat;

		public Savestate() {
			Environment.CurrentDirectory = dir;

			string json = File.ReadAllText("minisavestates-saved.json");

			dat = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
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

			string json = JsonConvert.SerializeObject(dat, Formatting.Indented);

			File.WriteAllText("minisavestates-saved.json", json);

			Console.WriteLine("Saved file");
		}

	}
}