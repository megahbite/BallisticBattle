using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public static GameState instance = null;
    private float currentPlayerAngle = float.NaN;
    public int playerHealth = 20;

    private GameObject angleText = null;

    public float CurrentPlayerAngle
    {
        get { return currentPlayerAngle; }

        set
        {
            currentPlayerAngle = value;
            var text = angleText.GetComponent<Text>();
            if (text != null)
                text.text = string.Format("{0:f2}°", value);
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        angleText = GameObject.FindGameObjectWithTag("AngleText");
    }
}
