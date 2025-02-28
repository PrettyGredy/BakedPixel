using Inventory.Cell;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "Create inventory config", order = 0)]
    public class InventoryConfigSO : ScriptableObject
    {
        public GameObject CellPrefab;
        public CellView CellView;
        public int CellCount;
        public int UnBlockCellCount;
        public int UnBlockPrice;
    }
}