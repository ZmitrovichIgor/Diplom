using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Shop : MonoBehaviour, IPause
{
    public Action<float> OnLifeBuy;
    public Action<float> OnSpeedBuy;
    public Action<float> OnFuelBuy;
    
    [field: SerializeField] public int LifePrice { get; private set; }
    [field: SerializeField] public float SpeedPrice { get; private set; }
    [field: SerializeField] public float FuelPrice { get; private set; }
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _shopPanel; 
    [SerializeField] private Rocket _rocket;
    [SerializeField] private GameObject _buttonLife;
    [SerializeField] private GameObject _buttonFuel;
    [SerializeField] private GameObject _buttonSpeed;
    
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
        Debug.Log("life");
    }
    
    public void BuyingSpeed(float amount)
    {
        Debug.Log("speed");   
    }
    
    public void BuyingFuel(float amount)
    {
        Debug.Log("fuel");
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
