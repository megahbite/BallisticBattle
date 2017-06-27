using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Big ol' singleton that keeps tabs on the current state of the player (for display) and health of both actors (for win/lose conditions)
/// 
/// Theoretically if there were more levels it would track the players score and current level.
/// </summary>
public class GameState : MonoBehaviour {

    /// <summary>
    /// The single instance.
    /// </summary>
    public static GameState instance = null;

    private float currentPlayerAngle = float.NaN;
    private float currentPlayerPower = float.NaN;

    public int playerHealth = 20;
    public int aiHealth = 20;

    private Text angleText = null;
    private Text powerText = null;

    private static Color highlightColor = new Color(1f, 0.28f, 0.28f);
    private static Color defaultColor = new Color(0.8f, 0.8f, 0.8f);

    public float CurrentPlayerAngle
    {
        get { return currentPlayerAngle; }

        set
        {
            currentPlayerAngle = value;
            if (angleText != null)
                angleText.text = string.Format("{0:f2}°", value);
        }
    }

    public float CurrentPlayerPower
    {
        get { return currentPlayerPower; }

        set
        {
            currentPlayerPower = value;
            if (powerText != null)
                powerText.text = string.Format("{0:f2}N", value);
        }
    }

    public void HighlightAngle()
    {
        if (angleText != null)
            angleText.color = highlightColor;
        if (powerText != null)
            powerText.color = defaultColor;
    }

    public void HighlightPower()
    {
        if (powerText != null)
            powerText.color = highlightColor;
        if (angleText != null)
            angleText.color = defaultColor;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        var angleTextObject = GameObject.FindGameObjectWithTag("AngleText");
        if (angleTextObject != null)
            angleText = angleTextObject.GetComponent<Text>();
        var powerTextObject = GameObject.FindGameObjectWithTag("PowerText");
        if (powerTextObject != null)
            powerText = powerTextObject.GetComponent<Text>();
    }

    private void LateUpdate()
    {
        // Did we lose?
        if (playerHealth <= 0 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            SceneManager.LoadScene(1);
            return; // If somehow both bullets land simutaneously, favour the AI (sorry player)
        }

        //Did we win?
        if (aiHealth <= 0 && SceneManager.GetActiveScene().buildIndex != 2)
            SceneManager.LoadScene(2);
    }
}
