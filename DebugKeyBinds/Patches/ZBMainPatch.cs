using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace AetharNet.Mods.ZumbiBlocks2.DebugKeyBinds.Patches;

[HarmonyPatch(typeof(ZBMain))]
public static class ZBMainPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(ZBMain.Update))]
    public static IEnumerable<CodeInstruction> ReplaceKeyBinds(IEnumerable<CodeInstruction> instructions)
    {
        var getKeyDownMethod = AccessTools.Method(typeof(Input), nameof(Input.GetKeyDown), [typeof(KeyCode)]);
        var getDebugKeyDownMethod = AccessTools.Method(typeof(DebugController), nameof(DebugController.GetDebugKeyDown));
        
        return new CodeMatcher(instructions)
            .MatchForward(useEnd: false, [
                new CodeMatch(OpCodes.Ldc_I4, (int)Constants.ConsoleKey),
                new CodeMatch(OpCodes.Call, getKeyDownMethod)
            ])
            .SetOperandAndAdvance((int)DebugKeyBinds.ConsoleKey)
            .MatchForward(useEnd: false, [
                new CodeMatch(OpCodes.Ldc_I4, (int)Constants.StatisticKey),
                new CodeMatch(OpCodes.Call, getKeyDownMethod)
            ])
            .SetOperandAndAdvance((int)DebugKeyBinds.StatisticsKey)
            .MatchForward(useEnd: false, [
                new CodeMatch(OpCodes.Ldc_I4, (int)Constants.CanvasKey),
                new CodeMatch(OpCodes.Call, getDebugKeyDownMethod)
            ])
            .SetOperandAndAdvance((int)DebugKeyBinds.CanvasKey)
            .MatchForward(useEnd: false, [
                new CodeMatch(OpCodes.Ldc_I4, (int)Constants.WeaponsSheetKey),
                new CodeMatch(OpCodes.Call, getKeyDownMethod)
            ])
            .SetOperandAndAdvance((int)DebugKeyBinds.WeaponsSheetKey)
            .InstructionEnumeration();
    }
}
