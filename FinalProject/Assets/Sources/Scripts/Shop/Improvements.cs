using UnityEngine;

public class Improvements : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Rocket _rocket;
    
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
    
}
