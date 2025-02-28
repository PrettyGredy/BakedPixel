using System.Collections.Generic;
using Inventory;
using Inventory.InventoryLoadStrategy;
using Inventory.Item;
using Inventory.Item.ItemSO;
using Saver;
using UnityEngine;
using Zenject;

public class Bootstrap
{
    private InventoryManager _inventoryManager;

    [Inject]
    public void Construct(InventoryManager inventoryManager, List<InventoryItemSO> itemsSO, InventoryConfigSO config)
    {
        InventoryItemFactory.Instance.Init(itemsSO);

        _inventoryManager = inventoryManager;
        
        IInventoryLoadStrategy strategy;
        
        var inventoryDataSave = SaveSystem.LoadData();
        
        if (inventoryDataSave != null)
        {
            strategy = new SaveLoadInventoryStrategy(itemsSO, inventoryDataSave, config.UnBlockCellCount);
        }
        else
        {
            strategy = new EmptyInventoryStrategy(config.UnBlockCellCount);
        }

        _inventoryManager.Init(strategy);
    }
}
