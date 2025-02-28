using Inventory.ShowStats;
using UnityEngine;

namespace Inventory.Item
{
    public abstract class InventoryItem
    {
        public string Name { get; protected set; }
        public ItemType Type { get; protected set; }
        public Sprite Icon { get; protected set; }
        
        public float Weight { get; protected set; }

        public int MaxStackSize { get; protected set; }
        
        public int CurrentStackSize { get; protected set; }
        
        public bool IsFullStack { get; protected set; }
        public bool IsEmptyStack { get; protected set; }

        protected InventoryItem(string name, ItemType type, Sprite icon, float weight, int currentStackSize, int maxStack)
        {
            Name = name;
            Type = type;
            Icon = icon;
            Weight = weight;
            CurrentStackSize = currentStackSize;
            MaxStackSize = maxStack;
            
            if (CurrentStackSize >= MaxStackSize)
            {
                CurrentStackSize = MaxStackSize;
                IsEmptyStack = false;
                IsFullStack = true;
            }
            
            if (currentStackSize <= 0)
            {
                CurrentStackSize = 0;
                IsEmptyStack = true;
                IsFullStack = false;
            }
        }
        
        public void AddInStack()
        {
            IsEmptyStack = false;
            CurrentStackSize++;
            
            if (CurrentStackSize >= MaxStackSize)
            {
                CurrentStackSize = MaxStackSize;
                IsFullStack = true;
            }
        }
        
        public void RemoveInStack()
        {
            IsFullStack = false;
            CurrentStackSize--;
            
            if (CurrentStackSize <= 1)
            {
                IsEmptyStack = true;
                CurrentStackSize = 0;
            }
        }

        public abstract IShowStatsCommand GetShowStatsCommand();
    }
}