using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static World instance;

    public List<Sports> LicenseOrder = new List<Sports>();
    public List<int> LicenseCost = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        AddLicensesInOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddLicensesInOrder()
    {
        LicenseOrder.Add(Sports.Soccer);
        LicenseOrder.Add(Sports.Hockey);
        LicenseOrder.Add(Sports.Baseball);
        LicenseOrder.Add(Sports.Basketball);
        LicenseOrder.Add(Sports.Football);

        LicenseCost.Add(10);
        LicenseCost.Add(50);
        LicenseCost.Add(150);
        LicenseCost.Add(250);
        LicenseCost.Add(400);
    }
}
