using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public Action<int> OnCoinsChange;
    [field: SerializeField] public int CoinsQuantity { get; private set; }
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Shop _shop;
    
    private void Awake()
    {
        _rocket.OnCoinsTrigger += CurrentCoins;
    }

    private void CurrentCoins(int amount)
    {
        CoinsQuantity += amount;
        OnCoinsChange?.Invoke(CoinsQuantity);
    }
}
