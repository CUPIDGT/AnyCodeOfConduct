using System;
using BepInEx;
using UnityEngine;
using UnityEngine.UI;
using Utilla;
using System.Threading.Tasks;
using AnyCodeOfConductConfig = AnyCodeOfConduct.Scripts.Config;

namespace AnyCodeOfConduct
{
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		Text COCText;
		Text CodeOfConductText;

		async void Start()
		{
			Utilla.Events.GameInitialized += OnGameInitialized;

			await Task.Delay(500);

			CodeOfConductText.text = AnyCodeOfConductConfig.HeaderText.Value;
			COCText.text = AnyCodeOfConductConfig.BodyText.Value;
		}

		void OnEnable()
		{
			CodeOfConductText.text = AnyCodeOfConductConfig.HeaderText.Value;
			COCText.text = AnyCodeOfConductConfig.BodyText.Value;

			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			CodeOfConductText.text = "GORILLA CODE OF CONDUCT";
			COCText.text = "-NO RACISM, SEXISM, HOMOPHOBIA, TRANSPHOBIA, OR OTHER BIGOTRY\r\n-NO CHEATS OR MODS\r\n-DO NOT HARASS OTHER PLAYERS OR INTENTIONALLY MAKE THEM UNCOMFORTABLE\r\n-DO NOT TROLL OR GRIEF LOBBIES BY BEING UNCATCHABLE OR BY ESCAPING THE MAP. TRY TO MAKE SURE EVERYONE IS HAVING FUN\r\n-IF SOMEONE IS BREAKING THIS CODE, PLEASE REPORT THEM\r\n-PLEASE BE NICE GORILLAS AND HAVE A GOOD TIME";

			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			CodeOfConductText = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>();
			COCText = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>();
			AnyCodeOfConductConfig.Initalize();
		}
	}
}
