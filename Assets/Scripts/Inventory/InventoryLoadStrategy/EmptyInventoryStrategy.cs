namespace Inventory.InventoryLoadStrategy
{
    public class EmptyInventoryStrategy: IInventoryLoadStrategy
    {
        private int _inventoryCapacity;
            
        public EmptyInventoryStrategy(int inventoryCapacity)
        {
            _inventoryCapacity = inventoryCapacity;
        }

        public InventoryData LoadInventory()
        {
            return new InventoryData(_inventoryCapacity);
        }
    }
}