using UnityEngine;

/// <summary>
/// Sits on the main camera and instantiates the GameState singleton.
/// </summary>
public class GameStateLoader : MonoBehaviour {

    public GameObject gameState;

    private void Awake()
    {
        if (GameState.instance == null) Instantiate(gameState);
    }
}
