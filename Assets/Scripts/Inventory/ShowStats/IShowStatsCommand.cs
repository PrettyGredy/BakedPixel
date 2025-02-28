namespace Inventory.ShowStats
{
    public interface IShowStatsCommand
    {
        void Execute(StatsView statsView);
    }
}