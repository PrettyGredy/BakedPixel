using Inventory.Item;
using UnityEngine;

namespace Inventory.ShowStats
{
    public class ShowAmmoStatsCommand: IShowStatsCommand
    {
        private InventoryAmmoItem _ammoItem;

        public ShowAmmoStatsCommand(InventoryAmmoItem ammoItem)
        {
            _ammoItem = ammoItem;
        }
        
        public void Execute(StatsView statsView)
        {
            statsView.gameObject.SetActive(true);

            string stats = $"Вес каждого {_ammoItem.Weight}кг";
            
            statsView.ShowStats(_ammoItem.Icon, _ammoItem.Name, stats);
        }
    }
}