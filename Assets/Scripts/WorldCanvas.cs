using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWorldCanvas()
    {
        GameManager1.instance.WorldCanvas.SetActive(false);
        GameManager1.instance.MainCanvas.SetActive(true);
    }
}
