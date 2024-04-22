using TMPro;
using UnityEngine;

public class ShopViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsQuantity;
    [SerializeField] private TextMeshProUGUI _fuelPrice;
    [SerializeField] private TextMeshProUGUI _speedPrice;
    [SerializeField] private TextMeshProUGUI _lifePrice;
    [SerializeField] private TextMeshProUGUI _maxFuel;
    [SerializeField] private TextMeshProUGUI _maxSpeed;
    [SerializeField] private TextMeshProUGUI _maxLife;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Shop _shop;
    [SerializeField] private Rocket _rocket;
    
    private void OnEnable()
    {
        _coinsQuantity.text = $"Your coins : {_wallet.CoinsQuantity.ToString()}";
        _fuelPrice.text = $"Price : {_shop.FuelPrice.ToString()}";
        _speedPrice.text = $"Price : {_shop.SpeedPrice.ToString()}";
        _lifePrice.text = $"Price : {_shop.LifePrice.ToString()}";
        _maxFuel.text = $"Max fuel : {_rocket.MaxFuel.ToString()}";
        _maxSpeed.text = $"Current speed : {_rocket.Speed.ToString()}";   
        _maxLife.text = $"LIfes : {_rocket.MaxHealth.ToString()}";
    }

    private void Awake()
    {
        _shop.OnLifeBuy += UpdateViewLife;
        _shop.OnSpeedBuy += UpdateViewSpeed;
        _shop.OnFuelBuy += UpdateViewFuel;
    }

    private void UpdateViewFuel()
    {
        _maxFuel.text = $"Max fuel : {_rocket.MaxFuel.ToString()}";
        _coinsQuantity.text = $"Your coins : {_wallet.CoinsQuantity.ToString()}";
    }
    
    private void UpdateViewSpeed()
    {
        _maxSpeed.text = $"Current speed : {_rocket.Speed.ToString()}";
        _coinsQuantity.text = $"Your coins : {_wallet.CoinsQuantity.ToString()}";
    }
    
    private void UpdateViewLife()
    {
        _maxLife.text = $"LIfes : {_rocket.MaxHealth.ToString()}";
        _coinsQuantity.text = $"Your coins : {_wallet.CoinsQuantity.ToString()}";
    }
}
