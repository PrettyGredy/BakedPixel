using Inventory.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.ShowStats
{
    public class ShowWeaponStatsCommand: IShowStatsCommand
    {
        private InventoryWeaponItem _weaponItem;

        
        public ShowWeaponStatsCommand(InventoryWeaponItem weaponItem)
        {
            _weaponItem = weaponItem;
        }
        
        public void Execute(StatsView statsView)
        {
            statsView.gameObject.SetActive(true);

            string stats = $"стреляет патронами {_weaponItem.AmmoType}, вес {_weaponItem.Weight}кг, наносит {_weaponItem.Damage} урона за выстрел";
            
            statsView.ShowStats(_weaponItem.Icon, _weaponItem.Name, stats);
        }
    }
}