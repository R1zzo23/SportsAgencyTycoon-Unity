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
    public Agency Agency;
    public Manager Manager;
    public Office Office;
    public Text AgencyNameText;
    public Text ManagerFullNameText;

    
    public bool TimerStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        MainCanvas.SetActive(false);
        CreateManagerAndAgencyCanvas.SetActive(true);

        Agency = this.GetComponent<Agency>();
        Manager = this.GetComponent<Manager>();
        Office = this.GetComponent<Office>();

        Agency.Money = 35000;
        Agency.InfluencePoints = 10;
        Agency.Office = Office;
        Agency.Office.CreateInitialOffice();
        Agency.UpdateOfficeInfo();

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
            // create Agency
            //Agency agency = AgencyPanel.GetComponent<Agency>();
            //agency.Name = AgencyNameInput.text;
            Agency.Name = AgencyNameInput.text;


            // create Manager
            //Manager manager = new Manager();
            Manager.FirstName = FirstNameInput.text;
            Manager.LastName = LastNameInput.text;
            Manager.FullName = FirstNameInput.text + " " + LastNameInput.text;

            // assign Manager to Agency
            Agency.Manager = Manager;

            // Update UI for Manager and Agency names
            ManagerFullNameText.text = Manager.FullName;
            AgencyNameText.text = Agency.Name;

            // hide manager create canvas and show main canvas
            CreateManagerAndAgencyCanvas.SetActive(false);
            MainCanvas.SetActive(true);

            // start calendar timer
            TimerStarted = true;
        }
    }

    public void AddToBalance(int amt)
    {
        Agency.Money += amt;
        if (OnUpdateBalance != null)
            OnUpdateBalance();
    }

    public void AddToIP(int amt)
    {
        Agency.InfluencePoints += amt;
        if (OnUpdateBalance != null)
            OnUpdateBalance();
    }

    public bool CanBuy(int AmtToSpend)
    {
        if (AmtToSpend <= Agency.Money)
            return true;
        else
            return false;
    }

    public float GetCurrentMoney()
    {
        return Agency.Money;
    }

    public int GetCurrentIP()
    {
        return Agency.InfluencePoints;
    }
}
