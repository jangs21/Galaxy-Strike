using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"We Hit {other.gameObject.name}!"); //this is called string interpolation //Debug.Log("Hit " + other.name);
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
