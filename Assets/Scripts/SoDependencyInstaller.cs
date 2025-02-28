using System.Collections.Generic;
using Inventory;
using Inventory.Item.ItemSO;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "SoInstaller", menuName = "Installers/SoInstaller")]
public sealed class SoDependencyInstaller : ScriptableObjectInstaller
{
    public InventoryConfigSO InventoryConfig;
    public List<InventoryItemSO> Items;

    public override void InstallBindings()
    {
        Container.Bind<InventoryConfigSO>().FromInstance(InventoryConfig).AsSingle();
        Container.Bind<List<InventoryItemSO>>().FromInstance(Items).AsSingle().NonLazy();
    }
}