using UnityEngine;

public class TikiPickup : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bob up and down
        transform.position += Vector3.up * Mathf.Sin(Time.time * 2f) * 0.5f * Time.deltaTime;

        // Spin 360
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindFirstObjectByType<TikiManager>().TikiPickedUp();
        Destroy(gameObject);
    }
}
