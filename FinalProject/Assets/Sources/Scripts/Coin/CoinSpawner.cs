using System.Collections;
using UnityEngine;
using Zenject;

public class CoinSpawner : MonoBehaviour, IPause
{
    [SerializeField] private Rocket _rocket;
    
    private Coin _coin;
    private float _spawnTime = 3f;
    private float _maxX = 6f;
    private float _minX = -6f;
    private float _addedDistance = 10f;
    private Coroutine _spawnRoutine;
    private PauseService _pauseService;
    
    [Inject]
    public void Constructor(PauseService pauseService)
    {
        _pauseService = pauseService;
    }
    
    private void Awake()
    {
        _coin = Resources.Load<Coin>("Coin");
        _pauseService.AddPause(this);
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnTime);
        Vector2 randomPosition = new Vector2(Random.Range(_minX, _maxX), _rocket.transform.position.y + _addedDistance);
        Instantiate(_coin, randomPosition, Quaternion.identity);
        _spawnRoutine = null;
        _spawnRoutine = StartCoroutine(Spawn());
    }
    
    public void Pause()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
    }

    public void Resum()
    {
        if (_spawnRoutine == null)
        {
            _spawnRoutine = StartCoroutine(Spawn());    
        }
    }
}

