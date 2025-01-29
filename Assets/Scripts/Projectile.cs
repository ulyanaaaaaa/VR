using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Weapon _weapon;
    
    public virtual void Init(Weapon weapon)
    {
        _weapon = weapon;
    }

    public virtual void Launch()
    {
        
    }
}
