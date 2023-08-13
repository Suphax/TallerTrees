using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace TallerTrees
{
    public class TallerTreesSystem : ModSystem
    {
        public override void Load() {
            base.Load();
            config = ModContent.GetInstance<TallerTreesConfig>();
            Terraria.IL_WorldGen.GrowTree += new ILContext.Manipulator(WorldGen_GrowTree);

            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMin = config.GemTreesMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMax = config.GemTreesMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMin = config.GemTreesMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMax = config.GemTreesMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMin = config.GemTreesMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMax = config.GemTreesMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMin = config.GemTreesMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMax = config.GemTreesMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMin = config.GemTreesMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMax = config.GemTreesMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMin = config.GemTreesMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMax = config.GemTreesMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMin = config.GemTreesMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMax = config.GemTreesMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMin = config.SakuraTreeMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMax = config.SakuraTreeMaximumHeight;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMin = config.WillowTreeMinimumHeight;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMax = config.WillowTreeMaximumHeight;
        }

        public override void Unload() {
            base.Unload();
            config = null;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMax = 12;
        }

        private void WorldGen_GrowTree(ILContext il) {
            try
            {
                ILCursor c = new ILCursor(il);
                c.GotoNext(MoveType.After, i => i.MatchLdcI4(5));
                c.EmitDelegate((int min) => config.StandardTreesMinimumHeight);
                c.GotoNext(MoveType.After, i => i.MatchLdcI4(17));
                c.EmitDelegate((int max) => config.StandardTreesMaximumHeight + 1);
            }
            catch
            {
                MonoModHooks.DumpIL(ModContent.GetInstance<TallerTrees>(), il);
            }
        }

        internal static TallerTreesConfig config;
    }
}
