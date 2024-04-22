using TMPro;
using UnityEngine;

public class FuelCounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Rocket _rocket;

    private void Awake()
    {
        _rocket.OnFuelChange += CurrentFuel;
    }

    private void CurrentFuel(int amount)
    {
        _counter.text = $"{amount.ToString()}";
    }
}
