using UnityEngine;

public class BaseHit : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameObject.CompareTag("Player"))
                GameState.instance.playerHealth -= 10;
            else
                GameState.instance.aiHealth -= 10;
        }
    }
}
