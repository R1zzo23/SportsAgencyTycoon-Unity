using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour
{
    public int Level;
    public int PurchaseCost;
    public int MonthlyCost;
    public int EmployeeCapacity;

    public void CreateInitialOffice()
    {
        Level = 1;
        PurchaseCost = 0;
        MonthlyCost = 2500;
        EmployeeCapacity = 1;
    }
}
