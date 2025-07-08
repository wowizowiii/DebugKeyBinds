using HarmonyLib;

namespace AetharNet.Mods.ZumbiBlocks2.DebugKeyBinds.Patches;

[HarmonyPatch(typeof(DeveloperConsole))]
public static class DeveloperConsolePatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(DeveloperConsole.Init))]
    public static void FixKeyCodeDisplay(DeveloperConsole __instance)
    {
        var keycodeDisplay = __instance.transform.GetChild(0).GetChild(0).GetComponent<DirectKeycodeDisplay>();
        keycodeDisplay.keyCode = DebugKeyBinds.ConsoleKey;
    }
}
