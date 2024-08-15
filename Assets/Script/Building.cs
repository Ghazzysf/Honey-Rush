using UnityEngine;

public class Building : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);    
    }
}
