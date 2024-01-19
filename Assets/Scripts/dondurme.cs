using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{
    [SerializeField]
    public static float donusHizi=1f;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, donusHizi); //kendi etrafýnda dönme  gameobject center on children
    }
}
