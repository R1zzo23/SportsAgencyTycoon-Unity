using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agency : MonoBehaviour
{
    // public variables - Define Gameplay
    public string Name;
    public int Level;
    Office Office;
    //public Agent Manager;
    public int Money;
    public int InfluencePoints;
    public int AgentCount;
    public int ClientCount;
    public Manager Manager;

    public int NextLicenseCost;

    // Start is called before the first frame update
    void Start()
    {
        Money = 35000;
        InfluencePoints = 10;
        Level = 0;
        NextLicenseCost = 10;
        CreateInitialOffice();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateInitialOffice()
    {
        Office = new Office(1, 0, 2500, 1);
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
    public int OfficeMonthlyPayment()
    {
        return Office.MonthlyCost;
    }
}
