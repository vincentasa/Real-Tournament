using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerDamage : MonoBehaviour
{
    public VolumeProfile globalVolume;
    public Health health;
    public float lowHpLimit = 0.5f;

    public float maxVignetteValue = 0.5f;
    //public Color vignetteColor = new Color(0.67f, 0, 0);
    public float maxAberrationValue = 1.0f;
    public float maxGainValue = 0.4f;

    Vignette vig;
    ChromaticAberration chr;
    LiftGammaGain lgg;

    private void Start()
    {
        health.onDamage.AddListener(UpdateCamera);
        health.onDie.AddListener(ResetCamera);

        if (globalVolume.TryGet(out Vignette vignette))
        {
            vig = vignette;
            //vig.color.value = vignetteColor;
            vig.active = false;
        }
        if (globalVolume.TryGet(out ChromaticAberration aberration))
        {
            chr = aberration;
            chr.active = false;
        }
        if (globalVolume.TryGet(out LiftGammaGain liftgammagain))
        {
            lgg = liftgammagain;
            lgg.active = false;
        }
    }

    void UpdateCamera()
    {
        if ((float)health.hp / health.maxHp <= lowHpLimit)
        {
            /*if (globalVolume.TryGet<Vignette>(out Vignette vig))
            {
                vig.active = true;
                vig.intensity.value = lowHpLimit - (float)health.health / health.maxHealth;
            }*/
            vig.active = true;
            vig.intensity.value = (lowHpLimit - (float)health.hp / health.maxHp) / lowHpLimit * maxVignetteValue;
            chr.active = true;
            chr.intensity.value = (lowHpLimit - (float)health.hp / health.maxHp) / lowHpLimit * maxAberrationValue;
            lgg.active = true;
            lgg.gain.Override(new Vector4(1f, 1f, 1f, - ((lowHpLimit - (float)health.hp / health.maxHp) / lowHpLimit * (1f - maxGainValue))));
        } 
    }

    void ResetCamera()
    {
        vig.active = false;
        chr.active = false;
        lgg.active = false;
    }
}