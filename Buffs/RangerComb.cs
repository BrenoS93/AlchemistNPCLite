using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class RangerComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ranger Combination");
			Description.SetDefault("Combination of Archery, Ammo Reservation, Wrath, Rage buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Стрелка");
			Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Лучника, Экономии Боеприпасов, Гнева и Ярости");
            DisplayName.AddTranslation(GameCulture.Chinese, "射手药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：箭术, 弹药储备, 暴怒, 怒气");
        }
		public override void Update(Player player, ref int buffIndex)
		{
            player.thrownDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
			player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
			player.ammoPotion = true;
			player.archery = true;
			player.buffImmune[16] = true;
			player.buffImmune[112] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
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
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
			CalamityPlayer.throwingDamage += 0.1f;
            CalamityPlayer.throwingCrit += 10;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.1f;
            RedemptionPlayer.druidCrit += 10;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.1f;
            ThoriumPlayer.symphonicCrit += 10;
			ThoriumPlayer.radiantBoost += 0.1f;
            ThoriumPlayer.radiantCrit += 10;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
