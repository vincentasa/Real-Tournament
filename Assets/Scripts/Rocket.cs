using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20;
    public GameObject explosionPrefab;

    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        var health = other.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.Damage(10);
        }

        Destroy(gameObject);
        //transform.forward = other.contacts[0].normal;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}