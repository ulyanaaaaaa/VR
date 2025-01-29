using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [field: SerializeField] public Transform Head { get; private set; }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
    
}
