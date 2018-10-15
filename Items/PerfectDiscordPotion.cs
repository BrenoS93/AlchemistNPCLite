using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPCLite.Items
{
    public class PerfectDiscordPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perfect Discord Potion");
			Tooltip.SetDefault("[c/00FF00:Unique Explorer's potion]"
            + "\nAllows to teleport on cursor position by hotkey"
            + "\nBehaves exactly like Rod of Discord"
            + "\nNON-CALAMITY BUFF POTION");
            DisplayName.AddTranslation(GameCulture.Russian, "Превосходное Зелье Раздора");
            Tooltip.AddTranslation(GameCulture.Russian, "[c/00FF00:Уникальное Зелье Исследовательницы]\nПозволяет телепортироваться на курсор при нажатии горячей клавиши\nПри применении ведёт себя аналогично Жезлу Раздора\nЗелье не из Каламити мода");

            DisplayName.AddTranslation(GameCulture.Chinese, "真·混乱药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "[c/00FF00:特调探险者药剂]\n允许使用快捷键传送到鼠标位置"
            + "\n效果等同于混乱法杖"
            + "\n非灾厄Buff药剂");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("TrueDiscordBuff");           //this is where you put your Buff
            item.buffTime = 36000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
