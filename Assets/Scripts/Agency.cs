using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agency : MonoBehaviour
{
    // public variables - Define Gameplay
    public string Name;
    public int Level;
    public Office Office;
    //public Agent Manager;
    public int Money;
    public int InfluencePoints;
    public int AgentCount;
    public int ClientCount;
    public Manager Manager;
    public int OfficeMonthlyCost;
    public int OfficeMaxEmployee;
    public int OfficeLevel;
    public int OfficePurchaseCost;
    public bool FreelanceBefore = false;

    public int NextLicenseCost;

    public List<Sports> LicensesHeld = new List<Sports>();

    // Start is called before the first frame update
    void Start()
    {
        Money = 35000;
        InfluencePoints = 10;
        Level = 0;
        NextLicenseCost = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateOfficeInfo()
    {
        OfficeLevel = Office.Level;
        OfficeMaxEmployee = Office.EmployeeCapacity;
        OfficePurchaseCost = Office.PurchaseCost;
        OfficeMonthlyCost = Office.MonthlyCost;
    }

    public int ObtainNextLicense()
    {
        return NextLicenseCost;
    }
    public void BuyLicense()
    {
        // Amt is negative of NextLicenseCost
        int Amt = -NextLicenseCost;
        Level++;
        NextLicenseCost = (NextLicenseCost * Mathf.RoundToInt(Mathf.Pow(Level + 1, 2)));

        // will subtract amount from Agency's IP
        GameManager1.instance.AddToIP(Amt);
    }
    public void MonthlyPayments()
    {
        // pay monthly cost for Office
        GameManager1.instance.AddToBalance(-Office.MonthlyCost);
    }
}
