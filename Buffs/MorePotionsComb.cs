using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
	public class MorePotionsComb : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
		return ModLoader.GetMod("MorePotions") != null;
		}
		
		public override void SetDefaults()
		{
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.SetDefault("More Potions Combination");
			Description.SetDefault("Grants most buffs from More Potions *potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация More Potioins");
            Description.AddTranslation(GameCulture.Russian, "Даёт большинство баффов от зелий мода More Potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("CouragePotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("DawnPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("DuskPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("DiamondSkinPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("EnhancedRegenerationPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("GladiatorsPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SoulbindingElixerPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("RangersDroughtPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SpeedPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SummonersDroughtPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SwiftHandsPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("WarriorsDroughtPotionBuff")] = true;
				if (ModLoader.GetMod("MorePotions") != null)
				{
				MorePotionsBoosts(player, ref buffIndex);
				}
		}
		
		private void MorePotionsBoosts(Player player, ref int buffIndex)
        {
            MorePotions.MorePotionsPlayer MorePotionsPlayer = player.GetModPlayer<MorePotions.MorePotionsPlayer>(MorePotions);
			MorePotions.GetBuff("CouragePotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("DawnPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("DuskPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("DiamondSkinPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("EnhancedRegenerationPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("GladiatorsPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("SoulbindingElixerPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("RangersDroughtPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("SpeedPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("SummonersDroughtPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("SwiftHandsPotionBuff").Update(player, ref buffIndex);
			MorePotions.GetBuff("WarriorsDroughtPotionBuff").Update(player, ref buffIndex);
        }
		private readonly Mod MorePotions = ModLoader.GetMod("MorePotions");
	}
}
