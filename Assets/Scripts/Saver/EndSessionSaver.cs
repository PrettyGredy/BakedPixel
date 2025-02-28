using Inventory;
using UnityEngine;
using Zenject;

namespace Saver
{
    public class EndSessionSaver : MonoBehaviour
    {
        private InventoryManager _inventoryManager;
        
        [Inject]
        public void Construct(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }
        
        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private void OnDestroy()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return;
#endif
            SaveGame();
        }
        
        private void SaveGame()
        {
            InventoryDataSave dataSave = new InventoryDataSave();
            
            for (int i = 0; i < _inventoryManager.Data.Items.Count; i++)
            {
                var temp = _inventoryManager.Data.Items[i];

                InventoryDataSave.InventoryItemSave itemSave = new InventoryDataSave.InventoryItemSave();
                
                itemSave.Name = temp.Name;
                itemSave.Type = (int)temp.Type;
                itemSave.StackSize = temp.CurrentStackSize;
            
                dataSave.Items.Add(itemSave);
            }
            
            SaveSystem.SaveData(dataSave);
        }
    }
}