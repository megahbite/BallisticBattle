using UnityEngine;

public class PlayerHit : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameState.instance.playerHealth -= 10;
        }
    }
}
