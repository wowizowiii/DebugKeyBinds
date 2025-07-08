using HarmonyLib;
using TMPro;

namespace AetharNet.Mods.ZumbiBlocks2.DebugKeyBinds.Patches;

[HarmonyPatch(typeof(WeaponsTable))]
public static class WeaponsTablePatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(WeaponsTable.Awake))]
    public static void FixTitleText(WeaponsTable __instance)
    {
        var titleText = __instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        titleText.text = titleText.text.Replace(Constants.WeaponsSheetKey.ToString(), DebugKeyBinds.WeaponsSheetKey.ToString());
    }
}
