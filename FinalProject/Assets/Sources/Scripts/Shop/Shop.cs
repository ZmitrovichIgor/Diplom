using System;
using UnityEngine;
using Zenject;

public class Shop : MonoBehaviour, IPause
{
    public Action OnLifeBuy;
    public Action OnSpeedBuy;
    public Action OnFuelBuy;
    
    [field: SerializeField] public int LifePrice { get; private set; }
    [field: SerializeField] public int SpeedPrice { get; private set; }
    [field: SerializeField] public int FuelPrice { get; private set; }
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _shopPanel; 
    [SerializeField] private Rocket _rocket;
    
    private PauseService _pauseService;

    [Inject]
    public void Constructor(PauseService pauseService)
    {
        _pauseService = pauseService;
    }

    private void Awake()
    {
        _pauseService.AddPause(this);
    }
    
    public void BuyingLife(int amount)
    {
        if (_wallet.CoinsQuantity >= LifePrice)
        {
            _rocket.MaxHealth += amount;
            _wallet.CoinsQuantity -= LifePrice;
            OnLifeBuy?.Invoke();
            _wallet.OnCoinsChange?.Invoke(_wallet.CoinsQuantity);
            _rocket.OnHeathChange?.Invoke(_rocket.MaxHealth);
        }
    }
    
    public void BuyingSpeed(float amount)
    {
        if (_wallet.CoinsQuantity >= SpeedPrice)
        {
            _rocket.Speed += amount;
            _wallet.CoinsQuantity -= SpeedPrice;
            OnSpeedBuy?.Invoke();
            _wallet.OnCoinsChange?.Invoke(_wallet.CoinsQuantity);
        }   
    }
    
    public void BuyingFuel(int amount)
    {
        if (_wallet.CoinsQuantity >= FuelPrice)
        {
            _rocket.MaxFuel += amount;
            _wallet.CoinsQuantity -= FuelPrice;
            OnFuelBuy?.Invoke();
            _wallet.OnCoinsChange?.Invoke(_wallet.CoinsQuantity);
            _rocket.OnFuelChange?.Invoke(_rocket.MaxFuel);
        }
    }
    
    public void ResumPause()
    {
        _pauseService.IsPause = false;
        _shopPanel.SetActive(false);
    }
    
    public void Pause()
    {
        _shopPanel.SetActive(true);   
    }

    public void Resum()
    {
    }
}
