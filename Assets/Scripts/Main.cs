using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Main : MonoBehaviour
{
    public GameObject logo;
    public GameObject startbutton;
    public GameObject exitbtn;
    public GameObject sd;
    public GameObject sd1;
    public GameObject popup;
    public GameObject backbtn;
    public GameObject a;
    public GameObject b;
    public GameObject Quiz;
    public GameObject Text;
    public GameObject Dodbogi_Text;
    public GameObject tutopop;
    public GameObject light;
    public GameObject image;
    bool start;
    public Sprite yes;
    public Sprite no;
    public Sprite stop;
    public Text stoptext; 
    public int count;
    public int count1;




    public void Startbtn()
    {
        start = true;
        sd.transform.localPosition = new Vector3(0, 0, 3.07f);
        sd.transform.localEulerAngles = new Vector3(0, 0, 0);
        sd1.GetComponent<heart1>().asd();
        sd.GetComponent<heart1>().asd();
        logo.SetActive(false);
        startbutton.SetActive(false);
        exitbtn.SetActive(false);
        backbtn.SetActive(true);
        tutopop.SetActive(true);
        //sd.GetComponent<Draggable>().enabled = true;
        popup.SetActive(true);
        Quiz.SetActive(false);
        a.SetActive(true);
        b.SetActive(true);
        sd.GetComponent<Draggable>().enabled = true;
    }
    public void optionon()
    {
        if (start)
        {
            Resetbtn();
        }
        else
        {
            sd.transform.localPosition = new Vector3(1.84f, 0, 3.07f);
            sd.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void Resetbtn()
    {
        sd.GetComponent<heart1>().asdf();
        sd1.GetComponent<heart1>().asdf();
    }
    public void back()
    {
        start = false;
        light.GetComponent<Light>().color = new Color(1, 1, 1);
        sd.transform.localPosition = new Vector3(1.84f, 0, 3.07f);
        Quiz.SetActive(true);
        sd.SetActive(true);
        sd1.SetActive(false);
        count = 0;
        stoptext.text = "일시정지";
        count1 = 0;
        sd.GetComponent<Animation>().enabled = true;
        sd1.GetComponent<Animation>().enabled = true;
        logo.SetActive(true);
        startbutton.SetActive(true);
        exitbtn.SetActive(true);
        popup.SetActive(false);
        backbtn.SetActive(false);
        a.SetActive(false);
        b.SetActive(false);
        sd1.GetComponent<heart1>().asdf();
        sd1.GetComponent<AudioSource>().enabled = true;
        sd.GetComponent<AudioSource>().enabled = true;
    }

    public void dodbogi()
    {
        count++;
        if(count == 1)
        {
            light.GetComponent<Light>().color = new Color(0.4f, 0.4f, 0.4f);
            b.GetComponent<Image>().sprite = yes;
            sd.SetActive(false);
            sd1.SetActive(true);
            sd1.GetComponent<heart1>().asdf();
            Text.SetActive(false);
            image.SetActive(true);
            Dodbogi_Text.SetActive(true);
        }
        if (count == 2)
        {
            light.GetComponent<Light>().color = new Color(1,1,1);
            b.GetComponent<Image>().sprite = no;
            sd.SetActive(true);
            sd1.SetActive(false);
            sd.GetComponent<heart1>().asdf();
            Text.SetActive(true);
            image.SetActive(false);
            Dodbogi_Text.SetActive(false);
            count = 0;
        }
    }
    public void stopbtn()
    {
        count1++;
        if (count1 == 1)
        {
            stoptext.text = "재생하기"; 
            a.GetComponent<Image>().sprite = yes;
            sd.GetComponent<Animation>().enabled = false;
            sd1.GetComponent<Animation>().enabled = false;
            sd.GetComponent<AudioSource>().enabled = false;
            sd1.GetComponent<AudioSource>().enabled = false; 
        }
        if (count1 == 2)
        {
            stoptext.text = "일시정지";
            a.GetComponent<Image>().sprite = stop;
            sd.GetComponent<Animation>().enabled = true;
            sd1.GetComponent<Animation>().enabled = true;   
            sd1.GetComponent<AudioSource>().enabled = true;
            sd.GetComponent<AudioSource>().enabled = true;
            count1 = 0;
        }

    }
}