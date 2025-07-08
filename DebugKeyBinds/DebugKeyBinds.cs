using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace AetharNet.Mods.ZumbiBlocks2.DebugKeyBinds;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class DebugKeyBinds : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.DebugKeyBinds";
    public const string PluginAuthor = "wowi";
    public const string PluginName = "DebugKeyBinds";
    public const string PluginVersion = "0.1.0";

    internal new static ManualLogSource Logger;

    private static ConfigEntry<KeyCode> configConsole;
    private static ConfigEntry<KeyCode> configStatistics;
    private static ConfigEntry<KeyCode> configCanvas;
    private static ConfigEntry<KeyCode> configWeaponsSheet;
    
    public static KeyCode ConsoleKey => configConsole.Value;
    public static KeyCode StatisticsKey => configStatistics.Value;
    public static KeyCode CanvasKey => configCanvas.Value;
    public static KeyCode WeaponsSheetKey => configWeaponsSheet.Value;
    
    private void Awake()
    {
        Logger = base.Logger;
        
        configConsole = Config.Bind("KeyBinds", "Console", Constants.ConsoleKey, "Developer Console");
        configStatistics = Config.Bind("KeyBinds", "Statistics", Constants.StatisticKey, "Connection Details & FPS");
        configCanvas = Config.Bind("KeyBinds", "Canvas", Constants.CanvasKey, "(Debug Only) Toggle Game UI");
        configWeaponsSheet = Config.Bind("KeyBinds", "WeaponsSheet", Constants.WeaponsSheetKey, "Weapons Statistics Screen");
        
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginGUID);
    }
}
