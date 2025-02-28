using System.Collections.Generic;
using Inventory.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.Interaction
{
    //Не успел красиво продумать связи для этого класса, сделал очевидным вариантом.
    //При наличии большего времени смог бы улучшить
    public class DragDropSwapProvider : InteractionProvider
    {
        private GraphicRaycaster raycaster;
        private InventoryView _inventoryView;

        private void OnEnable()
        {
            _inventoryView = GetComponentInParent<InventoryView>();
            raycaster = GetComponentInParent<GraphicRaycaster>();
            
            interaction.OnDragEndInPointer += FindItem;
        }

        private void OnDisable()
        {
            interaction.OnDragEndInPointer -= FindItem;
        }

        private void FindItem(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            
            raycaster.Raycast(eventData, results);
            
            foreach (RaycastResult result in results)
            {
                if (result.gameObject != gameObject)
                {
                    if (result.gameObject.TryGetComponent(out CellView cellV))
                    {
                        if (cellV.State == CellState.Lock)
                        {
                            return;
                        }
                        
                        _inventoryView.InventoryManager.Data.Swap(cellView.InventoryItem, cellV.InventoryItem);
                        _inventoryView.InventoryManager.OnInventoryChanged?.Invoke();
                    }
                }
            }
        }
    }
}