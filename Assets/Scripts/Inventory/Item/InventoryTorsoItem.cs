using Inventory.ShowStats;
using UnityEngine;

namespace Inventory.Item
{
    public class InventoryTorsoItem: InventoryItem
    {
        public float TorsoProtection { get; private set; }

        public InventoryTorsoItem(string name, ItemType type, Sprite icon, float weight, int currentStackSize, int maxStack, float torsoProtection):
            base(name, type, icon, weight, currentStackSize, maxStack)
        {
            TorsoProtection = torsoProtection;
        }
        
        public override IShowStatsCommand GetShowStatsCommand()
        {
            return new ShowTorsoStatsCommand(this);
        }
    }
}