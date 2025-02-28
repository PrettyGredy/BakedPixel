using UnityEngine;

namespace Inventory.Item.ItemSO
{
    [CreateAssetMenu(fileName = "Item_", menuName = "Inventory/Torso", order = 0)]
    public class InventoryItemSOTorso : InventoryItemSO
    {
        public int TorsoProtection;
    }
}