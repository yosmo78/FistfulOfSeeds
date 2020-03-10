namespace DapperDino.Items
{
	public struct ItemSlot
	{
		public InventoryItem item;
		public int quantity;

		public ItemSlot(InventoryItem item, int quantiy)
		{
			this.item = item;
			this.quantiy = quantiy;
		}	

		public static bool operator ==(ItemSlot a, ItemSlot b) { return a.Equals(b); }

		public static bool operator !=(ItemSlot a, ItemSlot b) { return !a.Equals(b); }  
	}
}

