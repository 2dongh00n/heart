using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Quiz_Manager : MonoBehaviour
{
    public GameObject[] Quiz;
    public GameObject[] Quiz5_Units;
    bool Is_Right_Answer;
    public int Quiz5_Counter;
    public int Quiz5_Right_Answer_Counter;
    public GameObject Quiz_Level_Text_Object;
    public Text Quiz_LevelText;
    int Quiz_Level = 0;
    int Right_Answer_Count = 0;
    bool Switch = false;
    bool Quiz5_Switch = true;
    public GameObject GoodJob1;
    public GameObject GoodJob2;
    public Text 현황;
    public GameObject GoodJob3;
    public GameObject Reset_Button;
    public GameObject GoSummary_Button;
    public GameObject answerTxt;
    public AudioSource audioSource;
    /*public GameObject Basic;
    public GameObject Right;
    public GameObject Wrong;*/

    private void Start()
    {
        audioSource.Play();
        Shuffle();
        Quiz[0].SetActive(true);
        if (Quiz[Quiz_Level].name == "5문")
        {
            GameObject.Find("퀴즈 넘기기 버튼").GetComponent<EventTrigger>().enabled = false;
            GameObject.Find("퀴즈 넘기기 버튼").GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0.75f);
        }
    }

    public void Quiz5_Controll()
    {
        if (Quiz5_Switch)
        {
            if (Quiz5_Counter > 1)
            {
                Quiz5_Switch = false;
                foreach(GameObject A in Quiz5_Units)
                {
                    if (A.GetComponentInChildren<Quiz5_Controller>().Switch != true)
                    {
                        A.GetComponent<EventTrigger>().enabled = false;
                    }
                }
                GameObject.Find("퀴즈 넘기기 버튼").GetComponent<EventTrigger>().enabled = true;
                GameObject.Find("퀴즈 넘기기 버튼").GetComponent<Image>().color = new Color(1,1,1,1);
                if (Quiz5_Right_Answer_Counter == 2)
                {
                    Is_Right_Answer = true;
                }
                else
                {
                    Is_Right_Answer = false;
                }
            }
        }
        else
        {
            Quiz5_Switch = true;
            foreach (GameObject A in Quiz5_Units)
            {
                if (A.GetComponentInChildren<Quiz5_Controller>().Switch != true)
                {
                    A.GetComponent<EventTrigger>().enabled = true;
                }
            }
            GameObject.Find("퀴즈 넘기기 버튼").GetComponent<EventTrigger>().enabled = false;
            GameObject.Find("퀴즈 넘기기 버튼").GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0.75f);
        }
    }

    public void Right_Answer()
    {
        Is_Right_Answer = true;
    }

    public void Wrong_Answer()
    {
        Is_Right_Answer = false;
    }

    public void Reset_Quiz()
    {
        SceneManager.LoadScene("9Quiz");


    }

    public void Shuffle()
    {
        ShuffleArray<GameObject>(Quiz);
    }

    private T[] ShuffleArray<T>(T[] array)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }

    public void Next_Quiz()
    {
        if (Switch)
        {
            Switch = false;
            if (Quiz_Level < 5)
            {
                answerTxt.SetActive(false);
                Is_Right_Answer = false;
                //GameObject.Find("Q").GetComponent<Text>().text = "문제";
                //정오답 새 이미지 기본으로
                //
                /*Right.SetActive(false);
                Wrong.SetActive(false);
                Basic.SetActive(true);*/
                Quiz[Quiz_Level].SetActive(false);
                Quiz_Level++;
                Quiz_LevelText.text = "Q" + (Quiz_Level + 1).ToString()+ ".";
                현황.text = (Quiz_Level + 1).ToString() + "/6";
                Quiz[Quiz_Level].SetActive(true);
                if (Quiz[Quiz_Level].name == "5문")
                {
                    GameObject.Find("퀴즈 넘기기 버튼").GetComponent<EventTrigger>().enabled = false;
                    GameObject.Find("퀴즈 넘기기 버튼").GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0.75f);
                }
            }
            else
            {
                answerTxt.SetActive(false);
                Quiz_Level = 6;
                Quiz[5].SetActive(false);
                Reset_Button.SetActive(true);
                GoSummary_Button.SetActive(true);
                GameObject.Find("현황").SetActive(false);
                GameObject.Find("퀴즈 넘기기 버튼").SetActive(false);
                //버튼없어지게하고 요약하기로가는 새로운버튼이 나오도록
                //GameObject.Find("Q").SetActive(false);
                //Quiz_LevelText.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                //Quiz_LevelText.color = new Color(0,0,0);
                Quiz_LevelText.text = Right_Answer_Count+"/6";
                
                if (Right_Answer_Count > 4)
                {
                    GoodJob3.SetActive(true);
                    GameObject.Find("Baby_Sound").GetComponent<AudioSource>().Play();
                    //5~6문제 정답시
                    /*Right.SetActive(true);
                    Wrong.SetActive(false);
                    Basic.SetActive(false);*/
                }
                else
                {
                    if (Right_Answer_Count > 2)
                    {
                        GoodJob2.SetActive(true);
                        GameObject.Find("Baby_Sound").GetComponent<AudioSource>().Play(); 
                        //3~4문제 정답시
                        /*Right.SetActive(false);
                        Wrong.SetActive(false);
                        Basic.SetActive(true);*/
                    }
                    else
                    {
                        GoodJob1.SetActive(true);
                        GameObject.Find("Failed_Sound").GetComponent<AudioSource>().Play(); 
                        //1~2문제 정답시
                        /*Right.SetActive(false);
                        Wrong.SetActive(true);
                        Basic.SetActive(false);*/
                    }
                }
            } 
        }
        else
        {
            Switch = true;
            if (Quiz_Level < 6)
            {


                //GameObject.Find("Q").GetComponent<Text>().text = "정답";
                GameObject.Find(Quiz[Quiz_Level].name + "Q").SetActive(false);
                GameObject.Find(Quiz[Quiz_Level].name + "설명").SetActive(false);
                GameObject.Find(Quiz[Quiz_Level].name + "답안").GetComponent<Text>().color = new Color(0,0,0, 1);
                GameObject.Find(Quiz[Quiz_Level].name + "답안2").GetComponent<Text>().color = new Color(0,0,0, 1);



                if (Is_Right_Answer)
                {
                    Right_Answer_Count++;
                    Debug.Log("정답");
                    GameObject.Find("Right_Sound").GetComponent<AudioSource>().Play(); 
                    //GameObject.Find("정답여부").SetActive(true);
                    //GameObject.Find("정답여부").GetComponent<Text>().text = "정답이에요!";
                    answerTxt.SetActive(true);
                    answerTxt.GetComponent<Text>().text = "정답이에요!";
                    answerTxt.GetComponent<Text>().color = new Color(0.05f, 0.38f, 0.76f, 1);
                    //Basic.SetActive(false);
                    //Right.SetActive(true);
                    
                    

                }
                else
                {
                    Debug.Log("오답");
                    GameObject.Find("Wrong_Sound").GetComponent<AudioSource>().Play(); 
                    //GameObject.Find("정답여부").SetActive(true);
                    //answerTxt.GetComponent<Text>().text = "아쉬워요!";
                    answerTxt.SetActive(true);
                    answerTxt.GetComponent<Text>().text = "오답이에요!";
                    answerTxt.GetComponent<Text>().color = new Color(0.83f, 0.03f, 0, 1);
                    //Basic.SetActive(false);
                    //Wrong.SetActive(true);
                }
            }
            else
            {
                SceneManager.LoadScene("10Summary");
            }
        }
    }
}
