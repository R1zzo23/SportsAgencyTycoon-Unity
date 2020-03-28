using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreelanceCanvas : MonoBehaviour
{
    public Text FreelanceInfoText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (GameManager1.instance.Agency.FreelanceBefore == false)
            FreelanceInfoText.enabled = true;
        else FreelanceInfoText.enabled = false;
    }

    public void CloseFreelanceInfoText()
    {
        FreelanceInfoText.enabled = false;
        GameManager1.instance.Agency.FreelanceBefore = true;
    }
}
