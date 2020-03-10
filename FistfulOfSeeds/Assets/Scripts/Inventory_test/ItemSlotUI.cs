using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DapperDino.item
{
	public class ItemSlotUI : MonoBehaviour, IDropHandler
	{
		[SerializeField] protected Image itemIconImage = null;

		public int SlotIndex { get; private set; }

		public abstract HotbarItem SlotItem { get; set; }

		private void OnEnable() => UpdateSlotUI();

		protected virtual void Start()
		{
			SlotIndex = transorm.GetSiblingIndex();
			UpdateSlotUI();
		}

		public abstract void OnDrop(PointerEventData eventData);
		public abstract void UpdateSlotUI();
		protected virtual void EnableSlotUI(bool enable) => itemIconImage.enabled = enable; 
	}
}

 