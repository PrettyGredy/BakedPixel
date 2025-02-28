using UnityEngine;

namespace Inventory.Item.ItemSO
{
    [CreateAssetMenu(fileName = "Item_", menuName = "Inventory/Weapon", order = 0)]
    public class InventoryItemSOWeapon : InventoryItemSO
    {
        public ItemType AmmoType;
        public int Damage;
    }
}