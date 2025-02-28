using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory.Item.ItemSO
{
    //[CreateAssetMenu(fileName = "Item_", menuName = "Inventory/Item", order = 0)]
    public abstract class InventoryItemSO : ScriptableObject
    {
        public string ItemName;
        public ItemType ItemType;
        public Sprite Icon;
        public float Weight;
        public int MaxStackSize;
    }
}