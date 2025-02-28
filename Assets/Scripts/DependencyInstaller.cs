using Inventory;
using Inventory.ShowStats;
using Zenject;

public class DependencyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Bootstrap>().AsSingle().NonLazy();
        Container.Bind<InventoryManager>().AsSingle().NonLazy();
        Container.Bind<StatsView>().FromComponentInHierarchy().AsSingle().Lazy();
    }
}
