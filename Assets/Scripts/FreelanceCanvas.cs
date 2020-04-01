using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreelanceCanvas : MonoBehaviour
{
    public Text FreelanceInfoText;
    public GameObject GotItButton;
    public GameObject AttemptJob1Button;
    public Text Job1DescriptionText;

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
        {
            AttemptJob1Button.SetActive(false);
            Job1DescriptionText.enabled = false;
            FreelanceInfoText.enabled = true;
        }
        else
        {
            AttemptJob1Button.SetActive(true);
            Job1DescriptionText.enabled = true;
            FreelanceInfoText.enabled = false;
        }
    }

    public void CloseFreelanceCanvas()
    {
        GameManager1.instance.FreelanceCanvas.SetActive(false);
        GameManager1.instance.MainCanvas.SetActive(true);
    }

    public void CloseFreelanceInfoText()
    {
        GotItButton.SetActive(false);
        FreelanceInfoText.enabled = false;
        GameManager1.instance.Agency.FreelanceBefore = true;

        GiveInitialFreelanceJob();
        ShowAvailableJobs();
    }
    private void GiveInitialFreelanceJob()
    {
        GameManager1.instance.Agency.FreelanceJobsAvailable.Add(new FreelanceJob("Back To School", "Complete a Sports Management Course", 1, 5, 0, 1500));
    }

    public void ShowAvailableJobs()
    {
        if (GameManager1.instance.Agency.FreelanceJobsAvailable.Count > 0)
        {
            FreelanceJob job1 = GameManager1.instance.Agency.FreelanceJobsAvailable[0];

            AttemptJob1Button.SetActive(true);
            Job1DescriptionText.text = job1.JobName + ": " + job1.JobDescription + " - Money: " + job1.MoneyPayout.ToString() + " - IP: " + job1.IPPayout.ToString();
            Job1DescriptionText.enabled = true;
        }
        else
        {
            AttemptJob1Button.SetActive(false);
            Job1DescriptionText.enabled = false;
        }
    }
}
