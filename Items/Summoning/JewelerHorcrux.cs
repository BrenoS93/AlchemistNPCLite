using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Summoning
{
	public class JewelerHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jeweler Horcrux");
			Tooltip.SetDefault("The piece of Jeweler's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Ювелира");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Ювелира находится внутри");

            DisplayName.AddTranslation(GameCulture.Chinese, "珠宝师魂器");
            Tooltip.AddTranslation(GameCulture.Chinese, "里面有珠宝师的一片灵魂");
        }

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.maxStack = 30;
			item.value = 15000;
			item.rare = 6;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			item.UseSound = SoundID.Item37;
			item.makeNPC = (short)mod.NPCType("Jeweler");
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Jeweler"));
		}

		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Jeweler is spawned.", 255, 255, 255);
		}
	}
}