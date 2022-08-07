namespace Minisavestates {
	class Editor {

		public static Dictionary<string, int> charmIDs = new Dictionary<string, int>() {
			["gathering swarm"] = 1,
			["swarm"] = 1,
			["wayward compass"] = 2,
			["compass"] = 2,
			["grubsong"] = 3,
			["stalwart shell"] = 4,
			["baldur shell"] = 5,
			["fury of the fallen"] = 6,
			["fury"] = 6,
			["quick focus"] = 7,
			["lifeblood heart"] = 8,
			["lifeblood core"] = 9,
			["defender's crest"] = 10,
			["defenders crest"] = 10,
			["dcrest"] = 10,
			["crest"] = 10,
			["flukenest"] = 11,
			["flukes"] = 11,
			["fluke"] = 11,
			["thorns of agony"] = 12,
			["thorns"] = 12,
			["mark of pride"] = 13,
			["mop"] = 13,
			["steady body"] = 14,
			["sb"] = 14,
			["heavy blow"] = 15,
			["sharp shadow"] = 16,
			["spore shroom"] = 17,
			["spore"] = 17,
			["shroom"] = 17,
			["longnail"] = 18,
			["shaman stone"] = 19,
			["shaman"] = 19,
			["soul catcher"] = 20,
			["catcher"] = 20,
			["soul eater"] = 21,
			["eater"] = 21,
			["glowing womb"] = 22,
			["fragile heart"] = 23,
			["heart"] = 23,
			["unbreakable heart"] = 23,
			["fragile greed"] = 24,
			["greed"] = 24,
			["unbreakable greed"] = 24,
			["fragile strength"] = 25,
			["strength"] = 25,
			["unbreakable strength"] = 25,
			["nailmaster's glory"] = 26,
			["nailmasters glory"] = 26,
			["nmg"] = 26,
			["joni's blessing"] = 27,
			["jonis blessing"] = 27,
			["jonis"] = 27,
			["joni's"] = 27,
			["shape of unn"] = 28,
			["unn"] = 28,
			["hiveblood"] = 29,
			["dreamwielder"] = 30,
			["dwielder"] = 30,
			["dashmaster"] = 31,
			["dm"] = 31,
			["quickslash"] = 32,
			["qs"] = 32,
			["spell twister"] = 33,
			["twister"] = 33,
			["deep focus"] = 34,
			["grubberfly's elegy"] = 35,
			["grubberflys elegy"] = 35,
			["elegy"] = 35,
			["void heart"] = 36,
			["kingoul"] = 36,
			["sprintmaster"] = 37,
			["dreamshield"] = 38,
			["dshield"] = 38,
			["weaversong"] = 39,
			["weavers"] = 39,
			["grimmchild"] = 40,
			["grimm"] = 40
		};
		public static Savestate user = new Savestate();

		static void Main() {

			Console.WriteLine(user.ToString());

			while (true) {
				var cmd = ParseCommand(Console.ReadLine().ToLower().Split(' '), user);
				if (cmd == true) {
					Environment.Exit(0);
				}
			}

		}

		private static bool ParseCommand(string[] v, Savestate save) {
			try {
				switch (v[0]) {

					case "save":
						save.Save();
						break;

					case "exit":
					case "quit":
						save.Save();
						return true;

					// charms
					case "equip":
						EquipCharm(string.Join(' ', v[1..]));
						break;
					case "remove":
					case "unequip":
						RemoveCharm(string.Join(' ', v[1..]));
						break;

					case "set":
						SetValue(v[1..]);
						break;

					case "give":
						SetTrue(v[1..]);
						break;

					case "take":
						SetFalse(v[1..]);
						break;

					case "check":
						CheckValue(v[1..]);
						break;

					default:
						break;
				}
			}
			catch {
				Console.WriteLine("Invalid syntax");
			}
			return false;

		}

		private static void SetFalse(string[] strings) {
			var v = string.Join('\u0000', strings);
			var value = false;
			switch (v) {
				case "claw":
				case "mantisclaw":
				case "walljump":
				case "wallcling":
					user.SetValue("canWallJump", value);
					break;
				case "wings":
				case "doublejump":
				case "monarchwings":
					user.SetValue("hasDoubleJump", value);
					break;
				case "ismas":
				case "ismastear":
				case "isma's":
				case "isma'stear":
				case "acidswim":
				case "acidarmour":
					user.SetValue("hasAcidArmour", value);
					break;
				case "dgate":
				case "dreamgate":
					user.SetValue("hasDreamGate", value);
					break;
				case "dnail":
				case "dreamnail":
					user.SetValue("hasDreamNail", value);
					user.SetValue("hasDreamGate", value);
					break;
				case "dash":
				case "mothwingcloak":
				case "cloak":
					user.SetValue("canDash", value);
					user.SetValue("hasDash", value);
					break;
				case "shadecloak":
				case "shadowdash":
					user.SetValue("hasShadowDash", value);
					break;
				case "lantern":
				case "lumaflylantern":
				case "lamp":
					user.SetValue("hasLantern", value);
					break;
				case "cdash":
				case "crystaldash":
				case "crystalheart":
				case "cheart":
					user.SetValue("canSuperDash", value);
					user.SetValue("hasSuperDash", value);
					break;
				case "greatslash":
				case "gslash":
					user.SetValue("hasUpwardSlash", value);
					user.SetValue("hasAllNailArts", value);
					break;
				case "cycloneslash":
				case "cyclone":
					user.SetValue("hasCycloneSlash", value);
					user.SetValue("hasAllNailArts", value);
					break;
				case "dashslash":
				case "dslash":
				case "dascheslasche":
				case "thatonenailart":
					user.SetValue("hasDashSlash", value);
					user.SetValue("hasAllNailArts", value);
					break;
				case "trampass":
				case "tram":
				case "pass":
					user.SetValue("hasTramPass", value);
					break;
				case "shopkey":
				case "shopkeeper'skey":
				case "shopkeeperskey":
				case "slykey":
					user.SetValue("hasSlyKey", value);
					break;
				case "citycrest":
				case "crest":
					user.SetValue("hasCityKey", value);
					break;
				case "elegantkey":
				case "ekey":
					user.SetValue("hasWhiteKey", value);
					break;
				case "lovekey":
					user.SetValue("hasLoveKey", value);
					break;
				case "brand":
				case "king'sbrand":
				case "kingsbrand":
					user.SetValue("hasKingsBrand", value);
					break;

				// spells, i know these aren't bools but meh
				case "vs":
				case "vengefulspirit":
				case "fireball":
					user.SetValue("fireballLevel", 0);
					break;
				case "shadesoul":
					user.SetValue("fireballLevel", 1);
					break;

				case "dive":
				case "desolatedive":
				case "ddive":
					user.SetValue("quakeLevel", 0);
					break;
				case "descendingdark":
				case "ddark":
					user.SetValue("quakeLevel", 1);
					break;

				case "wraiths":
				case "howlingwraiths":
					user.SetValue("screamLevel", 0);
					break;
				case "shriek":
				case "abyssshriek":
					user.SetValue("screamLevel", 1);
					break;

				default:
					if (user.dat.ContainsKey(v)) {
						user.dat[v] = false;
					}
					else {
						Console.WriteLine($"Could not parse {v}");
					}
					break;
			}

		}

		private static void SetTrue(string[] strings) {
			var v = string.Join('\u0000', strings);
			var value = true;
			switch (v) {
				case "claw":
				case "mantisclaw":
				case "walljump":
				case "wallcling":
					user.SetValue("canWallJump", value);
					break;
				case "wings":
				case "doublejump":
				case "monarchwings":
					user.SetValue("hasDoubleJump", value);
					break;
				case "ismas":
				case "ismastear":
				case "isma's":
				case "isma'stear":
				case "acidswim":
				case "acidarmour":
					user.SetValue("hasAcidArmour", value);
					break;
				case "dgate":
				case "dreamgate":
					user.SetValue("hasDreamGate", value);
					user.SetValue("hasDreamNail", value);
					break;
				case "dnail":
				case "dreamnail":
					user.SetValue("hasDreamNail", value);
					break;
				case "dash":
				case "mothwingcloak":
				case "cloak":
					user.SetValue("canDash", value);
					user.SetValue("hasDash", value);
					break;
				case "shadecloak":
				case "shadowdash":
					user.SetValue("hasShadowDash", value);
					break;
				case "lantern":
				case "lumaflylantern":
				case "lamp":
					user.SetValue("hasLantern", value);
					break;
				case "cdash":
				case "crystaldash":
				case "crystalheart":
				case "cheart":
					user.SetValue("canSuperDash", value);
					user.SetValue("hasSuperDash", value);
					break;
				case "greatslash":
				case "gslash":
					user.SetValue("hasUpwardSlash", value);
					user.SetValue("hasNailArt", value);
					break;
				case "cycloneslash":
				case "cyclone":
					user.SetValue("hasCycloneSlash", value);
					user.SetValue("hasNailArt", value);
					break;
				case "dashslash":
				case "dslash":
				case "dascheslasche":
				case "thatonenailart":
					user.SetValue("hasDashSlash", value);
					user.SetValue("hasNailArt", value);
					break;
				case "trampass":
				case "tram":
				case "pass":
					user.SetValue("hasTramPass", value);
					break;
				case "shopkey":
				case "shopkeeper'skey":
				case "shopkeeperskey":
				case "slykey":
					user.SetValue("hasSlyKey", value);
					break;
				case "citycrest":
				case "crest":
					user.SetValue("hasCityKey", value);
					break;
				case "elegantkey":
				case "ekey":
					user.SetValue("hasWhiteKey", value);
					break;
				case "lovekey":
					user.SetValue("hasLoveKey", value);
					break;
				case "brand":
				case "king'sbrand":
				case "kingsbrand":
					user.SetValue("hasKingsBrand", value);
					break;

				// spells, i know these aren't bools but meh
				case "vs":
				case "vengefulspirit":
				case "fireball":
					user.SetValue("fireballLevel", 1);
					break;
				case "shadesoul":
					user.SetValue("fireballLevel", 2);
					break;

				case "dive":
				case "desolatedive":
				case "ddive":
					user.SetValue("quakeLevel", 1);
					break;
				case "descendingdark":
				case "ddark":
					user.SetValue("quakeLevel", 2);
					break;

				case "wraiths":
				case "howlingwraiths":
					user.SetValue("screamLevel", 1);
					break;
				case "shriek":
				case "abyssshriek":
					user.SetValue("screamLevel", 2);
					break;

				default:
					if (user.dat.ContainsKey(v)) {
						user.dat[v] = false;
					}
					else {
						Console.WriteLine($"Could not parse {v}");
					}
					break;
			}
		}

		private static void SetValue(string[] v) {
			switch (string.Join('\u0000', v[0..^1])) {

				case "nail":
				case "naildmg":
					user.SetValue("nailDamage", int.Parse(v[1]));
					break;
				case "lifeblood":
				case "bluehp":
					user.SetValue("healthBlue", int.Parse(v[1]));
					break;
				case "hp":
				case "health":
					user.SetValue("health", int.Parse(v[1]));
					break;
				case "maxhp":
				case "maxhealth":
					user.SetValue("maxHealth", int.Parse(v[1]));
					break;
				case "geo":
					user.SetValue("geo", int.Parse(v[1]));
					break;
				case "essence":
					user.SetValue("dreamOrbs", int.Parse(v[1]));
					break;
				case "soul":
					var soul = int.Parse(v[1]);
					var res = soul > 100 ? soul % 99 : 0;
					user.SetValue("MPCharge", soul);
					user.SetValue("MPReserve", res);
					break;
				case "vessels":
					var x = int.Parse(v[1]);
					x = x >= 3 ? 3 : x;
					x *= 33;
					user.SetValue("MPReserveMax", x);
					break;

				default:
					Console.WriteLine($"Could not parse {v[0]}");
					return;
			}
		}

		private static void CheckValue(string[] v) {
			throw new NotImplementedException();
		}

		private static void EquipCharm(string v) {

			if (charmIDs.ContainsKey(v)) {
				var id = charmIDs[v];
				user.SetValue($"gotCharm_{id}", true);
				user.SetValue($"equippedCharm_{id}", true);

				Console.WriteLine($"Equipped {v} ({id})");
			}

			else {
				Console.WriteLine($"Unknown charm {v}");
				return;
			}

		}

		private static void RemoveCharm(string v) {

			if (charmIDs.ContainsKey(v)) {
				var id = charmIDs[v];
				user.SetValue($"equippedCharm_{id}", false);

				Console.WriteLine($"Unequipped {v}");
			}

			else {
				Console.WriteLine($"Unknown charm {v}");
				return;
			}

		}


	}
}