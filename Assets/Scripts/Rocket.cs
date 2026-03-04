using UnityEngine;
using UnityEngine.UIElements;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rocketSpeed;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionStrength;
    [SerializeField] private float explosionUpwardsModifier;
    [SerializeField] private LayerMask playerLayer;

    private Collider[] buffer = new Collider[50];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * rocketSpeed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        Explode();
        GameObject.Destroy(this.gameObject);
        
    }

    private void Explode()
    {
        int targetNum = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, buffer);
        for (int i = 0; i < targetNum; i++)
        {
            Debug.Log("loop running");
            if (buffer[i].gameObject.layer.Equals(3))
            {
                buffer[i].attachedRigidbody.AddExplosionForce(explosionStrength, transform.position, explosionRadius, explosionUpwardsModifier);
            }
        }
    }
}
