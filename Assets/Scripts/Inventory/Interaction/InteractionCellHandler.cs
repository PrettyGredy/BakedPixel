using System;
using DG.Tweening;
using Inventory.Cell;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.Interaction
{
    public class InteractionCellHandler : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
    {
        [SerializeField] private Transform _dragItem;
        private Camera _camera;
        private CellView _cellView;
        private Transform _currentParent;
        private Transform _dragContainer;

        private ScrollRect _scrollRect;
        private Vector3 _currentPos;
        private bool _readyToDrag;
        private bool _isDragStart;
        private bool _isDraggingItem;
        private Tween _holdTween;

        public Action OnDragStart;
        public Action OnDragEnd;
        public Action<PointerEventData> OnDragEndInPointer;
        public Action OnReturnToOrigin;
        public Action OnDraged;
        
        public Action OnClickUp;
        public Action OnClick;
        public Action OnClickDown;
        public Action OnSwipe;
        public Action OnHold;

        private void Start()
        {
            _scrollRect = GetComponentInParent<ScrollRect>();
            _dragContainer = GetComponentInParent<InventoryView>().DragContainer;
            _cellView = GetComponent<CellView>();
            _camera = Camera.main;
        }

        //======== Handlers ========
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_cellView.State == CellState.Busy)
            {
                _currentPos = transform.position;
                StartHold();
            }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isDragStart)
            {
                return;
            }
            
            EndHold();
            OnClick?.Invoke();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isDragStart = true;

            if (_readyToDrag)
            {
                //перетаскивание
                _isDraggingItem = true;
                _scrollRect.enabled = false;
                PutContainer(true);
            }
            else
            {
                //пролистывание
                _isDraggingItem = false;
                _scrollRect.OnBeginDrag(eventData);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            
            if (_isDraggingItem)
            {
                PointerMove(eventData);
            }
            else
            {
                _scrollRect.OnDrag(eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragStart = false;

            if (_isDraggingItem)
            {
                PutContainer(false);
                OnDragEnd?.Invoke();
                OnDragEndInPointer?.Invoke(eventData);
            }
            else
            {
                _scrollRect.OnEndDrag(eventData);
            }

            _scrollRect.enabled = true;
        }
        //==========================

        private void PointerMove(PointerEventData eventData)
        {
            Vector2 localPoint = _camera.ScreenToWorldPoint(eventData.position);
            _dragItem.transform.position = localPoint;
        }

        private void PutContainer(bool enable)
        {
            if (enable)
            {
                _currentParent = transform;
                _dragItem.transform.SetParent(_dragContainer);
                _dragItem.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            }
            else
            {
                _dragItem.transform.DOMove(_currentPos, 0.4f).OnComplete(() =>
                {
                    _dragItem.localScale = new Vector3(1, 1, 1);
                    _dragItem.transform.SetParent(_currentParent);
                    OnReturnToOrigin?.Invoke();
                });
            }
        }

        private void StartHold()
        {
            _holdTween?.Kill();
            _holdTween = DOVirtual.DelayedCall(1f, () =>
            {
                Debug.Log($"_readyToDrag true");
                _dragItem.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                _readyToDrag = true;
                _holdTween = null;
            });
        }

        private void EndHold()
        {
            _holdTween?.Kill();
            _readyToDrag = false;
            _dragItem.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}