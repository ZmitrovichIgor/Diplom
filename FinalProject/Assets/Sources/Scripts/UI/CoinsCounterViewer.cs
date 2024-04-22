using TMPro;
using UnityEngine;

public class CoinsCounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Wallet _wallet;

    private void Awake()
    {
        _wallet.OnCoinsChange += CurrentCoins;
    }

    private void CurrentCoins(int amount)
    {
        _counter.text = $"{amount.ToString()}";
    }    
}
