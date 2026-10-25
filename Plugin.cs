using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace RideTheLightningFix;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {	
  public const string PLUGIN_GUID = "com.earthlingOnFire.RideTheLightningFix";
  public const string PLUGIN_NAME = "+RIDE THE LIGHTNING fix";
  public const string PLUGIN_VERSION = "1.0.0";
  public static ManualLogSource logger;

  private void Awake() {
    gameObject.hideFlags = HideFlags.HideAndDontSave;
    logger = Logger;
  }

  private void Start() {
    new Harmony(PLUGIN_GUID).PatchAll();
    logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");
  }

  public static void Log(string msg) {
    logger.LogInfo(msg);
  }
}

