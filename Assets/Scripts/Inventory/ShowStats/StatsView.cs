using Inventory.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.ShowStats
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _textHeading;
        [SerializeField] private Text _textStats;
        
        private IShowStatsCommand _statsCommand;
        private InventoryItem _item;

        public void Init(IShowStatsCommand statsCommand)
        {
            _statsCommand = statsCommand;
            _statsCommand.Execute(this);
        }

        public void ShowStats(Sprite icon, string textHeading, string textStats)
        {
            _icon.sprite = icon;
            _textHeading.text = textHeading;
            _textStats.text = textStats;
        }
    }
}