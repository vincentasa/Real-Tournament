using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammo;
    public int maxAmmo = 10;
    public int clipAmmo;
    public int clipSize = 10;
    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.1f;
    float fireCooldown;
    public float reloadTime = 2;
    public float bulletsPerShot = 1;
    public float spreadAngle = 5;

    public UnityEvent onRightClick;
    public UnityEvent onShoot;
    public UnityEvent onReload;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        
        if(isReloading) return;
        if (clipAmmo <= 0)
        {
            Reload();
            return;
        }
        if(fireCooldown > 0) return;

        onShoot.Invoke();
        clipAmmo--;
        fireCooldown = fireInterval;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            var offsetX = Random.Range(-spreadAngle, spreadAngle);
            var offsetY = Random.Range(-spreadAngle, spreadAngle);
            bullet.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
        }
    }

    public async void Reload()
    {
        if (clipAmmo == clipSize) return;
        if(isReloading) return;

        isReloading = true;

        print ("Reloading...");
        onReload.Invoke();
        await new WaitForSeconds(reloadTime);
        print("Reloaded!");

        isReloading = false;
        //ammo = maxAmmo;
        var ammoNeeded = Mathf.Min(clipSize - clipAmmo, ammo);
        ammo -= ammoNeeded;
        clipAmmo += ammoNeeded;
    }
}