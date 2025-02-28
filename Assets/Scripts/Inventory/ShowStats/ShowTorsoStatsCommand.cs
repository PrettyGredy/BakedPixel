using Inventory.Item;
using UnityEngine;

namespace Inventory.ShowStats
{
    public class ShowTorsoStatsCommand: IShowStatsCommand
    {
        private InventoryTorsoItem _torsoItem;

        public ShowTorsoStatsCommand(InventoryTorsoItem torsoItem)
        {
            _torsoItem = torsoItem;
        }
        
        public void Execute(StatsView statsView)
        {
            statsView.gameObject.SetActive(true);

            string stats = $"+{_torsoItem.TorsoProtection} к защите торса, весит {_torsoItem.Weight}кг";
            
            statsView.ShowStats(_torsoItem.Icon, _torsoItem.Name, stats);
        }
    }
}