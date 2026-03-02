using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private float lifeTime = 25f;
    [SerializeField] private float damage = 25f;

    private Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}