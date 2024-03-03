using UnityEngine;

public class BurstMod : MonoBehaviour
{
    public Weapon weapon;
    public bool isBursting;

    public void Burst()
    {
        isBursting = !isBursting;

        if (isBursting)
        {
            weapon.bulletsPerShot = 3;
            weapon.spreadAngle = 5;
            weapon.isAutomatic = false;
        }
        else
        {
            weapon.bulletsPerShot = 1;
            weapon.spreadAngle = 0;
            weapon.isAutomatic = true;
        }
    }
}