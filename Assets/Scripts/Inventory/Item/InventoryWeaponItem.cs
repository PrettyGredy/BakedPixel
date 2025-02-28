using Inventory.ShowStats;
using UnityEngine;

namespace Inventory.Item
{
    public class InventoryWeaponItem: InventoryItem
    {
        public ItemType AmmoType { get; private set; }
        public int Damage { get; private set; }

        public InventoryWeaponItem(string name, ItemType type, Sprite icon, float weight, int currentStackSize, int maxStack, ItemType ammoType, int damage):
            base(name, type, icon, weight, currentStackSize, maxStack)
        {
            AmmoType = ammoType;
            Damage = damage;
        }
        
        public override IShowStatsCommand GetShowStatsCommand()
        {
            return new ShowWeaponStatsCommand(this);
        }
    }
}