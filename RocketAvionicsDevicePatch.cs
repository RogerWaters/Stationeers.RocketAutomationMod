using Assets.Scripts.Objects.Motherboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using Objects.Rockets;

namespace RocketAutomationMod
{
    [HarmonyPatch(typeof(RocketAvionicsDevice))]
    internal class RocketAvionicsDevicePatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(RocketAvionicsDevice.CanLogicWrite))]
        public static void CanLogicWrite(LogicType logicType, ref bool __result)
        {
            if (logicType == LogicType.ClearMemory)
            {
                __result = true;
            }
        }

        [HarmonyPatch(nameof(RocketAvionicsDevice.SetLogicValue))]
        [HarmonyPostfix]
        public static void SetLogicValue(LogicType logicType, double value)
        {
            if (logicType == LogicType.ClearMemory)
            {
                SpaceMapNode node = SpaceMapCode.Get((ulong)value);
                if (node == null || !node.IsAccessible || node.NodeType != NodeType.Generated)
                {
                    return;
                }
                //check no rocket connected to node
                if (node.RocketsHere.Count > 0)
                {
                    return;
                }

                foreach (Rocket rocket in Rocket.AllRockets)
                {
                    if (rocket.TargetNode == node)
                    {
                        return;
                    }
                }
                node.DeRegister();
            }
        }
    }
}
