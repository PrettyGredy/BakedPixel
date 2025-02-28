using System.Collections.Generic;

namespace Saver
{
    [System.Serializable]
    public class InventoryDataSave
    {
        public List<InventoryItemSave> Items = new List<InventoryItemSave>();

        public struct InventoryItemSave
        {
            public string Name;            
            public int Type;
            public int StackSize;
        }
    }
}