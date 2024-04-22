using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Rocket : MonoBehaviour, IPause
{
    public Action<int> OnCoinsTrigger;
    public Action<int> OnFuelChange;
    public Action<int> OnHeathChange;
    
    [field: SerializeField] public int CurrentFuel { get; set; }
    [field: SerializeField] public int MaxFuel { get; set; }
    [field: SerializeField] public int CurrentHealth { get; set; }
    [field: SerializeField] public int MaxHealth { get; set; }
    [field: SerializeField] public float Speed { get; set; } = 2;
    [field: SerializeField] public bool IsFly { get; set; }
    [field: SerializeField] public float HightReached { get; set; }

    private Coroutine _fuelRoutine;
    private PauseService _pauseService;

    [Inject]
    public void Constructor(PauseService pauseService)
    {
        _pauseService = pauseService;
    }
    
    private void Awake()
    {
        CurrentFuel = MaxFuel;
        CurrentHealth = MaxHealth;
        OnFuelChange?.Invoke(CurrentFuel);
        OnHeathChange?.Invoke(CurrentHealth);
        _pauseService.AddPause(this);
    }
    
    public IEnumerator FuelCounter()
    {
        if (CurrentFuel > 0)
        {
            yield return new WaitForSeconds(1);
            --CurrentFuel;
            OnFuelChange?.Invoke(CurrentFuel);
            HightReached = gameObject.transform.position.y;
            _fuelRoutine = StartCoroutine(FuelCounter());   
        }
        else
        {
            StopCoroutine(_fuelRoutine);
            _pauseService.Pause();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Coin coin))
        {
            OnCoinsTrigger?.Invoke(coin.Value);
        }
        if (collider.gameObject.TryGetComponent(out Fuel fuel))
        {
            CurrentFuel += fuel.Amount;
            OnFuelChange?.Invoke(CurrentFuel);
        }
        if (collider.gameObject.TryGetComponent(out Meteorite meteorite))
        {
            --CurrentHealth;
            OnHeathChange?.Invoke(CurrentHealth);
            if (CurrentHealth == 0)
            {
                StopCoroutine(_fuelRoutine);
                _pauseService.Pause();
            }
            StartCoroutine(InvulnerabilityCounter(gameObject.layer, collider.gameObject.layer));
        }
    }
    
    private IEnumerator InvulnerabilityCounter(int playerLayer, int obstacleLayer)
    {
        Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, true);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, false);
    }
    
    public void Pause()
    {
        IsFly = false;
        OnFuelChange?.Invoke(MaxFuel);
    }

    public void Resum()
    {
        HightReached = 0;
        CurrentFuel = MaxFuel;
        CurrentHealth = MaxHealth;
        OnFuelChange?.Invoke(CurrentFuel);
        OnHeathChange?.Invoke(CurrentHealth);   
    }
}
