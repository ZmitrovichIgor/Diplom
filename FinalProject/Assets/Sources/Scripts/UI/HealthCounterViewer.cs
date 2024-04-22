using TMPro;
using UnityEngine;

public class HealthCounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Rocket _rocket;
    
    private void Awake()
    {
        _rocket.OnHeathChange += CurrentHealth;
    }

    private void CurrentHealth(int amount)
    {
        _counter.text = $"{amount.ToString()}";
    }
}
