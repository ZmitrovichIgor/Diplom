using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMovement : MonoBehaviour, IPause
{
    private Rigidbody2D _rigidbody;
    private Rocket _rocket;
    private float _yMax = 7f;
    private float _yMin = -7f;
    private PauseService _pauseService;

    [Inject]
    public void Constructor(PauseService pauseService)
    {
        _pauseService = pauseService;
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rocket = GetComponent<Rocket>();
        _pauseService.AddPause(this);
    }
    
    private void Update()
    {
        if (_pauseService.IsPause)
            return;
        Movement();
    }
    
    private void StratFlight()
    {
        _pauseService.Resum();
        _rigidbody.velocity = Vector2.up;
        _rocket.IsFly = true;
        StartCoroutine(_rocket.FuelCounter());
    }
    
    private void Movement()
    {
        if (Input.GetKey(KeyCode.Space) && (!_rocket.IsFly))
        {
            StratFlight();
        }
        if (_rocket.IsFly)
        {
            transform.position = new Vector2(Math.Clamp(transform.position.x, _yMin, _yMax), transform.position.y);
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _rocket.Speed, _rigidbody.velocity.y);
        }
    }
    
    public void Pause()
    {
        transform.position = new Vector2(0, 1.45f);
        _rigidbody.velocity = Vector2.zero;
    }

    public void Resum()
    {
    }
}
