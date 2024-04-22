using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fuel : MonoBehaviour
{
    [field: SerializeField] public int Amount { get; private set; }

    private int _lifetime = 10;    

    
    private void Awake()
    {
        Amount = Random.Range(3, 5);
    }

    private void Start()
    {
        StartCoroutine(DestroyTic());
    }
    
    private IEnumerator DestroyTic()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Rocket rocket))
        {
            Destroy(gameObject);
        }
    }
    
    public void Delete()
    {
        Destroy(gameObject);    
    }
}
