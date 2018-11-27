﻿using ReLogic.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;
using AlchemistNPCLite.NPCs;

namespace AlchemistNPCLite.Interface
{
	class ShopChangeUIO : UIState
	{
		public UIPanel OperatorShopsPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			OperatorShopsPanel = new UIPanel();
			OperatorShopsPanel.SetPadding(0);
			OperatorShopsPanel.Left.Set(575f, 0f);
			OperatorShopsPanel.Top.Set(275f, 0f);
			OperatorShopsPanel.Width.Set(260f, 0f);
			OperatorShopsPanel.Height.Set(130f, 0f);
			OperatorShopsPanel.BackgroundColor = new Color(73, 94, 171);

			OperatorShopsPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
			OperatorShopsPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			UIText text = new UIText("Materials/Boss Drops");
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(90, 0f);
			text.Height.Set(22, 0f);
			text.OnClick += new MouseEvent(PlayButtonClicked1);
			OperatorShopsPanel.Append(text);
			
			UIText text2 = new UIText("Vanilla Treasure Bags");
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(70, 0f);
			text2.Height.Set(22, 0f);
			text2.OnClick += new MouseEvent(PlayButtonClicked2);
			OperatorShopsPanel.Append(text2);
			
			UIText text3 = new UIText("Modded Treasure Bags #1");
			text3.Left.Set(35, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(120, 0f);
			text3.Height.Set(22, 0f);
			text3.OnClick += new MouseEvent(PlayButtonClicked3);
			OperatorShopsPanel.Append(text3);
			
			UIText text4 = new UIText("Modded Treasure Bags #2");
			text4.Left.Set(35, 0f);
			text4.Top.Set(100, 0f);
			text4.Width.Set(120, 0f);
			text4.Height.Set(22, 0f);
			text4.OnClick += new MouseEvent(PlayButtonClicked4);
			OperatorShopsPanel.Append(text4);
			
			Texture2D buttonPlayTexture = ModLoader.GetTexture("Terraria/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnClick += new MouseEvent(PlayButtonClicked1);
			OperatorShopsPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnClick += new MouseEvent(PlayButtonClicked2);
			OperatorShopsPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnClick += new MouseEvent(PlayButtonClicked3);
			OperatorShopsPanel.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonPlayTexture);
			playButton4.Left.Set(10, 0f);
			playButton4.Top.Set(100, 0f);
			playButton4.Width.Set(22, 0f);
			playButton4.Height.Set(22, 0f);
			playButton4.OnClick += new MouseEvent(PlayButtonClicked4);
			OperatorShopsPanel.Append(playButton4);

			Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(230, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			OperatorShopsPanel.Append(closeButton);
			base.Append(OperatorShopsPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop1 = true;
			Operator.Shop3 = false;
			Operator.Shop4 = false;
			Operator.Shop5 = false;
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop1 = false;
			Operator.Shop3 = true;
			Operator.Shop4 = false;
			Operator.Shop5 = false;
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop1 = false;
			Operator.Shop3 = false;
			Operator.Shop4 = true;
			Operator.Shop5 = false;
		}
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
		{
			Operator.Shop1 = false;
			Operator.Shop3 = false;
			Operator.Shop4 = false;
			Operator.Shop5 = true;
		}

		private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuOpen);
			visible = false;
		}

		Vector2 offset;
		public bool dragging = false;
		private void DragStart(UIMouseEvent evt, UIElement listeningElement)
		{
			offset = new Vector2(evt.MousePosition.X - OperatorShopsPanel.Left.Pixels, evt.MousePosition.Y - OperatorShopsPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			OperatorShopsPanel.Left.Set(end.X - offset.X, 0f);
			OperatorShopsPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (OperatorShopsPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				OperatorShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
				OperatorShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
