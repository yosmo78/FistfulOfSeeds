using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DapperDino.Items
{
	public class InventoryItemDragHandler : ItemDragHandler
	{
		public override OnPointerUp(PointerEventData eventData)
		{
			if(eventData.button == PointerEventData.InputButton.Left)
			{
				base.OnPointerUp(eventData);

				if(eventData.hovered.Count == 0)
				{
					// destroy item or drop item
				}
			}
		}
	}
}	

