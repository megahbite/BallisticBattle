using System.Linq;
using UnityEngine;

public class HittableObject : MonoBehaviour {

    public GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            var hitPoint = collision.contacts.First().point;
            Instantiate(explosionPrefab, hitPoint, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }


}
