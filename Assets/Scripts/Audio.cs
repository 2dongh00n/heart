using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    int BGM_Index = -1;

    private AudioSource Source;
    private void Awake()
    {
        var obj = FindObjectsOfType<Audio>();
        Source = GameObject.Find("BGM1").GetComponent<AudioSource>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Check_Music()
    {
        if (BGM_Index != GameObject.Find("Scene_Manager").GetComponent<Scene_Manager_CS>().BGM_Index)
        {
            Source.Stop();
            BGM_Index = GameObject.Find("Scene_Manager").GetComponent<Scene_Manager_CS>().BGM_Index;
            switch (BGM_Index)
            {
                case 0:
                    Source = GameObject.Find("BGM1").GetComponent<AudioSource>();
                    break;
            }
            Source.Play();
        }
    }
}
