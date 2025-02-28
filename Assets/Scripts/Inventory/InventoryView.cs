using System;
using System.Collections.Generic;
using Inventory.Cell;
using Inventory.ShowStats;
using UnityEngine;
using Zenject;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private GameObject _content;
        [SerializeField] private StatsView _statsView;
        [SerializeField] private Transform _dragContainer;

        private InventoryManager _inventoryManager;
        private InventoryConfigSO _config;
        private List<CellView> _cellsView = new List<CellView>();
        
        public StatsView StatsView => _statsView;
        public Transform DragContainer => _dragContainer;
        public InventoryManager InventoryManager => _inventoryManager;
        
        [Inject]
        public void Construct(InventoryConfigSO config, InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
            DrawCell(config);
            
            inventoryManager.OnInventoryChanged += RedrawCell;
        }

        private void OnDisable()
        {
            _inventoryManager.OnInventoryChanged -= RedrawCell;
        }

        private void DrawCell(InventoryConfigSO config)
        {
            _config = config;

            for (int i = 0; i < _config.CellCount; i++)
            {
               GameObject cellObj= Instantiate(_config.CellPrefab, _content.transform);
               CellView cellView = cellObj.GetComponent<CellView>();

               if (i >= _config.UnBlockCellCount)
               {
                   cellView.SetLock();
               }
               
               _cellsView.Add(cellView);
            }

            RedrawCell();
        }

        private void RedrawCell()
        {
            foreach (var cell in _cellsView)
            {
                cell.ClearCell();
            }
            
            var items = _inventoryManager.Data.Items;

            for (int i = 0; i < items.Count; i++)
            {
                _cellsView[i].Draw(items[i]);
            }
        }
    }
}