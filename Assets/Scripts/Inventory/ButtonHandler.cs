using System;
using System.Collections.Generic;
using Inventory.Item.Command;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Inventory
{
    public class ButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _btnFire;
        [SerializeField] private Button _btnAddAmmo;
        [SerializeField] private Button _btnAddItem;
        [SerializeField] private Button _btnDeleteItem;

        [SerializeField] private List<ItemType> _types;

        private InventoryManager _inventoryManager;
        private ICommand _fireCommand;
        private ICommand _addAmmoCommand;
        private ICommand _addItemCommand;
        private ICommand _deleteCommand;

        [Inject]
        private void Constuct(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }
        
        private void OnEnable()
        {
            _btnFire.onClick.AddListener(Fire);
            _btnAddAmmo.onClick.AddListener(AddAmmo);
            _btnAddItem.onClick.AddListener(AddItem);
            _btnDeleteItem.onClick.AddListener(DeleteItem);
        }

        private void OnDisable()
        {
            _btnFire.onClick.RemoveAllListeners();
            _btnAddAmmo.onClick.RemoveAllListeners();
            _btnAddItem.onClick.RemoveAllListeners();
            _btnDeleteItem.onClick.RemoveAllListeners();
        }

        private void Fire()
        {
            if (_fireCommand == null) _fireCommand = new FireCommand(_inventoryManager);
            _fireCommand.Execute();
        }
        
        private void AddAmmo()
        {
            if (_addAmmoCommand == null) _addAmmoCommand = new AddAmmoCommand(_inventoryManager);
            _addAmmoCommand.Execute();
        }
        
        private void AddItem()
        {
            if (_addItemCommand == null) _addItemCommand = new AddItemCommand(_inventoryManager);
            _addItemCommand.Execute();
        }
        
        private void DeleteItem()
        {
            if (_deleteCommand == null) _deleteCommand = new DeleteItemCommand(_inventoryManager);
            _deleteCommand.Execute();
        }
    }
}