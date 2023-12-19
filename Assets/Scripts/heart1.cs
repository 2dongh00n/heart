using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 initpos;
    Quaternion initrot;
    // Start is called before the first frame update
    public void asd()
    {
        initpos = transform.localPosition;
        initrot = transform.localRotation;
    }
    public void asdf()
    {
        transform.localPosition = initpos;
        transform.localRotation = initrot;
    }
}
