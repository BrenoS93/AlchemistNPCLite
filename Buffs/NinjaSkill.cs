using Terraria;
using System.Linq;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class NinjaSkill : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ninja");
			Description.SetDefault("Now you have Ninja abilities");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Ниндзя");
			Description.AddTranslation(GameCulture.Russian, "Теперь вы обладаете способностями Ниндзя");

            DisplayName.AddTranslation(GameCulture.Chinese, "忍者");
            Description.AddTranslation(GameCulture.Chinese, "你现在拥有忍者的能力");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;
			player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
				RedemptionBoost(player);
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
				CalamityBoost(player);
				}
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>(Calamity);
			CalamityPlayer.throwingDamage += 0.05f;
            CalamityPlayer.throwingCrit += 5;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.05f;
            RedemptionPlayer.druidCrit += 5;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.05f;
            ThoriumPlayer.symphonicCrit += 5;
			ThoriumPlayer.radiantBoost += 0.05f;
            ThoriumPlayer.radiantCrit += 5;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
