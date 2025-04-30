using UnityEngine;

public class Treasure : MonoBehaviour
{
    public LayerMask ship;
    public ParticleSystem collected;
    public int coinAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z), 0.1f, ship))
        {
            Destroy(Instantiate(collected.gameObject, gameObject.transform.position, gameObject.transform.rotation), 2.0f);
            PlayerAbilities.coins += coinAmount;
            Destroy(gameObject);
        };
    }
}
