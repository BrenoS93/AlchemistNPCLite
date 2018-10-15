using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Items.Misc
{
	public class AlchemistCharmTier4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 4");
			Tooltip.SetDefault("While this is in your inventory, you have a very high chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nMakes potions to not consume if Supreme Calamitas is defeated");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Тир 4");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет очень большой шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nЗелья не будут тратиться, если побеждена Supreme Calamitas");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 4000000;
			item.rare = 12;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).AlchemistCharmTier4 = true;
		((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlchemistCharmTier3");
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
