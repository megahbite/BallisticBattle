using UnityEngine;

public class GameStateLoader : MonoBehaviour {

    public GameObject gameState;

    private void Awake()
    {
        if (GameState.instance == null) Instantiate(gameState);
    }
}
