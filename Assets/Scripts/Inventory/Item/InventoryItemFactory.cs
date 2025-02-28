using System;
using System.Collections.Generic;
using Inventory.Item.ItemSO;
using UnityEngine;

namespace Inventory.Item
{
    public class InventoryItemFactory
    {
        private static readonly Lazy<InventoryItemFactory> _instance =
            new Lazy<InventoryItemFactory>(() => new InventoryItemFactory());
        
        private List<InventoryItemSO> _itemsSO = new List<InventoryItemSO>();
        private InventoryItemFactory() { }
        
        public static InventoryItemFactory Instance => _instance.Value;

        public void Init(List<InventoryItemSO> items)
        {
            foreach (var item in items)
            {
                _itemsSO.Add(item);
            }
        }
        
        public InventoryItem Create(ItemType type, int currentStackSize = 0)
        {
            InventoryItemSO targetItemSO = GetItemSO(type);
            
            if (targetItemSO == null)
            {
                Debug.LogError("Нет SO для создания!");
                return null;
            }
            
            int stackSize = GetCurrentStackSize(targetItemSO, currentStackSize);
            
            
            switch (type)
            {
                case ItemType.AmmoPistol:
                {
                    if (targetItemSO is InventoryItemSOAmmo ammoItem)
                    {
                        return new InventoryAmmoItem(ammoItem.ItemName, ammoItem.ItemType, ammoItem.Icon, ammoItem.Weight, 
                            stackSize, ammoItem.MaxStackSize);
                    }
                }
                    break;
                case ItemType.AmmoRifle:
                {
                    if (targetItemSO is InventoryItemSOAmmo ammoItem)
                    {
                        return new InventoryAmmoItem(ammoItem.ItemName, ammoItem.ItemType, ammoItem.Icon, ammoItem.Weight, 
                            stackSize, ammoItem.MaxStackSize);
                    }
                }
                    break;
                case ItemType.WeaponPistol:
                {
                    if (targetItemSO is InventoryItemSOWeapon weaponItem)
                    {
                        return new InventoryWeaponItem(weaponItem.ItemName, weaponItem.ItemType, weaponItem.Icon, weaponItem.Weight, stackSize, 
                            weaponItem.MaxStackSize, weaponItem.AmmoType, weaponItem.Damage);
                    }
                }
                    break;
                case ItemType.WeaponRifle:
                {
                    if (targetItemSO is InventoryItemSOWeapon weaponItem)
                    {
                        return new InventoryWeaponItem(weaponItem.ItemName, weaponItem.ItemType, weaponItem.Icon, weaponItem.Weight, stackSize,
                            weaponItem.MaxStackSize, weaponItem.AmmoType, weaponItem.Damage);
                    }
                }
                    break;
                case ItemType.HeadCap:
                {
                    if (targetItemSO is InventoryItemSOHead headItem)
                    {
                        return new InventoryHeadItem(headItem.ItemName, headItem.ItemType, headItem.Icon, headItem.Weight, stackSize,
                            headItem.MaxStackSize, headItem.HeadProtection);
                    }
                }
                    break;
                case ItemType.HeadHelmet:
                {
                    if (targetItemSO is InventoryItemSOHead headItem)
                    {
                        return new InventoryHeadItem(headItem.ItemName, headItem.ItemType, headItem.Icon, headItem.Weight,stackSize, 
                            headItem.MaxStackSize, headItem.HeadProtection);
                    }
                }
                    break;
                case ItemType.TorsoJacket:
                {
                    if (targetItemSO is InventoryItemSOTorso torsoItem)
                    {
                        return new InventoryTorsoItem(torsoItem.ItemName, torsoItem.ItemType, torsoItem.Icon, torsoItem.Weight,stackSize, 
                            torsoItem.MaxStackSize, torsoItem.TorsoProtection);
                    }
                }
                    break;
                case ItemType.TorsoBulletproof:
                {
                    if (targetItemSO is InventoryItemSOTorso torsoItem)
                    {
                        return new InventoryTorsoItem(torsoItem.ItemName, torsoItem.ItemType, torsoItem.Icon, torsoItem.Weight,stackSize, 
                            torsoItem.MaxStackSize, torsoItem.TorsoProtection);
                    }
                }
                    break;
                default:
                {
                    Debug.LogError("Неизвестный тип предмета!");
                }
                    break;
            }
            
            return null;
        }

        private InventoryItemSO GetItemSO(ItemType type)
        {
            if (_itemsSO == null || _itemsSO.Count == 0)
            {
                Debug.LogError("Нет SO для создания!");
                return null;
            }
            
            foreach (var item in _itemsSO)
            {
                if (item.ItemType == type)
                {
                    return item;
                }
            }
            return null;
        }

        private int GetCurrentStackSize(InventoryItemSO itemSo, int value)
        {
            if (value > 0)
            {
                return value;
            }
            
            if (itemSo is InventoryItemSOAmmo ammoItem)
            {
                return ammoItem.MaxStackSize;
            }

            return 1;
        }
    }
}