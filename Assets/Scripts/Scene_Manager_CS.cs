using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Manager_CS : MonoBehaviour
{
    public int BGM_Index;


    private void Start()
    {
        if (GameObject.Find("Audio_Manager"))
        {
            GameObject.Find("Audio_Manager").GetComponent<Audio>().Check_Music();
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Quizscene()
    {
        SceneManager.LoadScene("Quiz");
    }
    public void GoIntro()
    {
        SceneManager.LoadScene("Main");
    }
}
