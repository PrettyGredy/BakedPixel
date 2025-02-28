using Inventory.Cell;
using UnityEngine;

namespace Inventory.Interaction
{
    [RequireComponent(typeof(InteractionCellHandler), typeof(CellView))]
    public abstract class InteractionProvider : MonoBehaviour
    {
        protected InteractionCellHandler interaction;
        protected CellView cellView;

        private void Awake()
        {
            interaction = GetComponent<InteractionCellHandler>();
            cellView = GetComponent<CellView>();
        }
    }
}