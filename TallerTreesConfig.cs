using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TallerTrees
{
	public class TallerTreesConfig : ModConfig
	{
        public override ConfigScope Mode => ConfigScope.ServerSide;

		public override void OnChanged()
		{
			base.OnChanged();
			if (StandardTreesMinimumHeight > StandardTreesMaximumHeight)
			{
				StandardTreesMinimumHeight = StandardTreesMaximumHeight;
			}
			if (GemTreesMinimumHeight > GemTreesMaximumHeight)
			{
				GemTreesMinimumHeight = GemTreesMaximumHeight;
			}
			if (SakuraTreeMinimumHeight > SakuraTreeMaximumHeight)
			{
				SakuraTreeMinimumHeight = SakuraTreeMaximumHeight;
			}
			if (WillowTreeMinimumHeight > WillowTreeMaximumHeight)
			{
				WillowTreeMinimumHeight = WillowTreeMaximumHeight;
			}
		}

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(5)]
        public int StandardTreesMinimumHeight;

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(16)]
		public int StandardTreesMaximumHeight;

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(7)]
		public int GemTreesMinimumHeight;

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(12)]
		public int GemTreesMaximumHeight;

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(7)]
		public int SakuraTreeMinimumHeight;

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(12)]
		public int SakuraTreeMaximumHeight;

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(7)]
		public int WillowTreeMinimumHeight;

		[Range(1, 127)]
		[ReloadRequired]
		[DefaultValue(12)]
		public int WillowTreeMaximumHeight;
	}
}