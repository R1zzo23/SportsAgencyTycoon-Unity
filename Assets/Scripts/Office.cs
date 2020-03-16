using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour
{
    public int Level;
    public int PurchaseCost;
    public int MonthlyCost;
    public int EmployeeCapacity;
    public Office(int level, int purchaseCost, int monthlyCost, int employeeCapacity)
    {
        Level = level;
        PurchaseCost = purchaseCost;
        MonthlyCost = monthlyCost;
        EmployeeCapacity = employeeCapacity;
    }
}
