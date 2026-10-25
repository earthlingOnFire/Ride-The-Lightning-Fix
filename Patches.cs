using UnityEngine;
using HarmonyLib;

namespace RideTheLightningFix;

[HarmonyPatch]
public static class Patches {

  [HarmonyPrefix]
  [HarmonyPatch(typeof(LightningStrikeExplosive), "Start")]
  private static void FixReflectedLightningStrike(LightningStrikeExplosive __instance) {
    GameObject reflected = __instance.reflected;
    RevolverBeam beam = reflected.GetComponent<RevolverBeam>();
    beam.hitterOverride = "lightningbolt";
  }

  [HarmonyPostfix]
  [HarmonyPatch(typeof(RevolverBeam), "GetHitterName")]
  private static void FixGetHitterName(RevolverBeam __instance, ref string __result) {
    if (__instance.hitterOverride == "lightningbolt") {
      __instance.hitterOverride = "";
    }
  }

}
