using BepInEx;
using HarmonyLib;

namespace RocketAutomationMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
            foreach (var method in harmony.GetPatchedMethods())
            {
                Logger.LogInfo($"[{PluginInfo.PLUGIN_GUID}] patched {method.FullDescription()}");
            }
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
