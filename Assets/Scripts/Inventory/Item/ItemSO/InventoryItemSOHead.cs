using UnityEngine;

namespace Inventory.Item.ItemSO
{
    [CreateAssetMenu(fileName = "Item_", menuName = "Inventory/Head", order = 0)]
    public class InventoryItemSOHead : InventoryItemSO
    {
        public int HeadProtection;
    }
}