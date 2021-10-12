using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public Text ScoreText;
    public Text TimerText;

    private float scorevalue;
    public float totalcoins;
    public float timeleft;
    public int timeRemaining;

    private float TimerValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeleft % 60);
        TimerText.text = "Timer : " + timeRemaining.ToString();

        if (scorevalue == totalcoins)
        {
            if (timeleft <= TimerValue)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        else if (timeleft <= 0)
        {
            SceneManager.LoadScene("GameLose");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Its working");
            scorevalue += 10;
            ScoreText.text = "Coin: " + scorevalue;
            Destroy(collision.gameObject);
            if (scorevalue == 60)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("It worked!");
            SceneManager.LoadScene("GameLose");
        }
    }
}
