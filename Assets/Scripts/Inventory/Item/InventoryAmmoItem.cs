using Inventory.ShowStats;
using UnityEngine;

namespace Inventory.Item
{
    public class InventoryAmmoItem: InventoryItem
    {
        public InventoryAmmoItem(string name, ItemType type, Sprite icon, float weight, int currentStackSize, int maxStack):
            base(name, type, icon, weight, currentStackSize, maxStack)
        {
        }
        
        public override IShowStatsCommand GetShowStatsCommand()
        {
            return new ShowAmmoStatsCommand(this);
        }

        
    }
}