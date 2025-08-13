using UnityEngine;

public enum WeaponType
{
    Knife = 0,
    Gun = 1,
    Bomb = 2,
}

public class WeaponManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseWeapon(WeaponType weapon)
    {
        if(weapon == WeaponType.Knife)
        {
            // Âñ·¯.
        }
        else if(weapon == WeaponType.Gun)
        {
            // ½÷.
        }
        else if(weapon == WeaponType.Bomb)
        {
            // ÅÍ¶ß·Á.
        }
    }
}
