using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public delegate void UpdateBalance();
    public static event UpdateBalance OnUpdateBalance;

    public static GameManager1 instance;

    public GameObject CreateManagerAndAgencyCanvas;
    public InputField FirstNameInput;
    public InputField LastNameInput;
    public InputField AgencyNameInput;
    public GameObject MainCanvas;
    public GameObject AgencyPanel;
    public Text AgencyNameText;
    public Text ManagerFullNameText;

    
    int CurrentMoney;
    int InfluencePoints;
    public bool TimerStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        MainCanvas.SetActive(false);
        CreateManagerAndAgencyCanvas.SetActive(true);

        CurrentMoney = 35000;
        InfluencePoints = 10;
        if (OnUpdateBalance != null)
            OnUpdateBalance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SubmitManagerAndAgency()
    {
        if (FirstNameInput.text == "")
            Debug.Log("Input a first name for your manager.");
        else if (LastNameInput.text == "")
            Debug.Log("Input a last name for your manager.");
        else if (AgencyNameInput.text == "")
            Debug.Log("Input a name for your agency.");
        else
        {
            Agency agency = AgencyPanel.GetComponent<Agency>();
            agency.Name = AgencyNameInput.text;
            Manager manager = new Manager();
            manager.FirstName = FirstNameInput.text;
            manager.LastName = LastNameInput.text;
            manager.FullName = FirstNameInput.text + " " + LastNameInput.text;
            agency.Manager = manager;
            ManagerFullNameText.text = manager.FullName;
            AgencyNameText.text = AgencyNameInput.text;
            CreateManagerAndAgencyCanvas.SetActive(false);
            TimerStarted = true;
            MainCanvas.SetActive(true);
        }
    }

    public void AddToBalance(int amt)
    {
        CurrentMoney += amt;
        if (OnUpdateBalance != null)
            OnUpdateBalance();
    }

    public void AddToIP(int amt)
    {
        InfluencePoints += amt;
        if (OnUpdateBalance != null)
            OnUpdateBalance();
    }

    public bool CanBuy(int AmtToSpend)
    {
        if (AmtToSpend <= CurrentMoney)
            return true;
        else
            return false;
    }

    public float GetCurrentMoney()
    {
        return CurrentMoney;
    }

    public int GetCurrentIP()
    {
        return InfluencePoints;
    }
}
