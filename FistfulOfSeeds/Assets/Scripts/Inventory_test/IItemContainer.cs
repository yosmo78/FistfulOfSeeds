using System;

namespace DapperDino.Items
{
	public class IItemContainer : IItemContainer
	{
		private ItemSlot[]  itemSlots = new ItemSlot[0];

		public Action OnItemsUpdated = delegate { };

		public ItemContainer(int size) => itemSlots = new ItemSlot[size];

		public ItemSlot GetSlotByIndex(int index) => itemSlots[index];

		public ItemSlot AddItem(ItemSlot itemSlot)
		{
			for(int i = 0; i < itemSlots.Length; i++)
			{
				if( itemSlots[i].item != null)
				{
					if(itemSlots[i].item == itemSlot.item)
					{
						int slotRemainingSpace = itemSlot[i].item.MaxStack - itemSlots[i].quantity;

						if(itemSlot.quantity <= slotRemainingSpace)
						{
							itemSlots[i].quantity += itemSlot.quantity;

							itemSlot.quantity = 0;

							OnItemsUpdated.Invoke();

							return itemSlot;
						}
					}
					else if(slotRemainingSpace > 0)
					{
						itemSlots[i].quantity += slotRemainingSpace;

						itemSlot.quantity -= slotRemainingSpace;
					}
				}
			}
		}
	}
}




