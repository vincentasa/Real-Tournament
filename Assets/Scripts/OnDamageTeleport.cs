using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageTeleport : MonoBehaviour
{
    private Vector3 randomPos;
    public Health health;
    private void Start()
    {
        randomPos = new Vector3(2.58f, 1, Random.Range(1.3f, 9.59f));
        health.onDamage.AddListener(Teleport);
    }
    public void Teleport()
    {
        transform.position = randomPos;
        randomPos = new Vector3(2.58f, 1, Random.Range(1.3f, 9.59f));
    }
}
