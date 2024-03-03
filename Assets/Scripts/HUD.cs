using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]TMP_Text ammoText;
    [SerializeField]TMP_Text healthText;

    public Weapon weapon;
    public Health health;

    void Start()
    {
        UpdateUI();
        health.onDamage.AddListener(UpdateUI);
    }

    public void UpdateUI()
    {
        healthText.text = health.hp.ToString();

        if (weapon == null)
        {
            ammoText.text = "";
        }
        else
        {
            ammoText.text = weapon.clipAmmo + " / " + weapon.ammo;
        }
    }
}