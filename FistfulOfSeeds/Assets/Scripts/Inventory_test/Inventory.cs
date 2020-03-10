using System;
using UnityEngine;

namespace DapperDino.Items
{
	public class Inventory : ScriptableObject
	{
		[SerializeField] private VoidEvent onInventroyItemsUpdated = null;

		public ItemContainer ItemContainer { get; } = new ItemContainer(20);

		public void OnEnable() => ItemContainer.OnItemsUpdated += onInventroyItemsUpdated.Raise;


		public void OnDisable() => ItemContainer.OnItemsUpdated -= onInventroyItemsUpdated.Raise;
	}
}

