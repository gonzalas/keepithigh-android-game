using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartSettings : MonoBehaviour
{
    public TextMeshProUGUI highScore;


    void Update()
    {
        highScore.text = PlayerPrefs.GetInt("Highest Score", 0).ToString();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
