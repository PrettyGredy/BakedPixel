using Inventory.ShowStats;
using UnityEngine;

namespace Inventory.Item
{
    public class InventoryHeadItem : InventoryItem
    {
        public int HeadProtection { get; private set; }

        public InventoryHeadItem(string name, ItemType type, Sprite icon, float weight, int currentStackSize, int maxStack, int headProtection):
            base(name, type, icon, weight, currentStackSize, maxStack)
        {
            HeadProtection = headProtection;
        }
        
        public override IShowStatsCommand GetShowStatsCommand()
        {
            return new ShowHeadStatsCommand(this);
        }
    }
}