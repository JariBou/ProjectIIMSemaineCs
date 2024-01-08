using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private EntityGold _entityGold;
    [SerializeField] private TextMeshProUGUI _text;
    
    // Update is called once per frame
    private void Update()
    {
        UpdateText(_entityGold.Gold);
    }
    
    private void UpdateText(int goldAmount)
    {
        _text.text = $"Gold: {goldAmount}";
    }
}
