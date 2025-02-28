using Inventory.ShowStats;

namespace Inventory.Interaction
{
    public class ShowStatsProvider : InteractionProvider
    {
        private StatsView _statsView;
        
        private void OnEnable()
        {
            _statsView = GetComponentInParent<InventoryView>().StatsView;
            interaction.OnClick += ShowStars;
        }

        private void OnDisable()
        {
            interaction.OnClick -= ShowStars;
        }

        private void ShowStars()
        {
            if (cellView.InventoryItem == null)
            {
                return;
            }
            
            _statsView.Init(cellView.InventoryItem.GetShowStatsCommand());
        }
    }
}