using Inventory.Item;
using UnityEngine;

namespace Inventory.ShowStats
{
    public class ShowHeadStatsCommand: IShowStatsCommand
    {
        private InventoryHeadItem _headItem;
        
        public ShowHeadStatsCommand(InventoryHeadItem headItem)
        {
            _headItem = headItem;
        }
        
        public void Execute(StatsView statsView)
        {
            statsView.gameObject.SetActive(true);

            string stats = $"+{_headItem.HeadProtection} к защите головы, весит {_headItem.Weight}кг";
            
            statsView.ShowStats(_headItem.Icon, _headItem.Name, stats);
        }
    }
}