﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DapperDino.Items
{
	public abstract class InventoryItem : HotbarItem
	{
		[Header("Item Data")]
		[Min(0)] private int sellPrice = 1;
		[Min(1)] private int maxStack = 1;

		public override string ColoredName
		{
			get
			{
				return Name;
			}
		}
		public int SellPrice => sellPrice;

		public int MaxStack => maxStack;
	}
}