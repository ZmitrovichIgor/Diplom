using System.Collections;
using UnityEngine;
using Zenject;

public class FuelSpawner : MonoBehaviour, IPause
{
    [SerializeField] private Rocket _rocket;

    private Fuel _fuel;
    private float _spawnTime = 15f;
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
        _fuel = Resources.Load<Fuel>("Fuel");
        _pauseService.AddPause(this);
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnTime);
        Vector2 randomPosition = new Vector2(Random.Range(_minX, _maxX), _rocket.transform.position.y + _addedDistance);
        Instantiate(_fuel, randomPosition, Quaternion.identity);
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
