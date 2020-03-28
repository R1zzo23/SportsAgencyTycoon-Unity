using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    int dropdownIndex;
    List<string> managerActions = new List<string>();

    void Start()
    {
        DetermineManagerActions();
        PopulateList();
    }

    void DetermineManagerActions()
    {
        managerActions.Clear();
        int licenseCount;
        int licenseCost;

        if (GameManager1.instance == null || GameManager1.instance.Agency == null || GameManager1.instance.World == null)
        {
            licenseCount = 0;
            licenseCost = 10;
        }
        else
        {
            licenseCount = GameManager1.instance.Agency.LicensesHeld.Count;
            licenseCost = GameManager1.instance.World.LicenseCost[GameManager1.instance.Agency.LicensesHeld.Count];
        }
            

        managerActions.Add("Manager Actions:");
        managerActions.Add("Obtain " + GameManager1.instance.World.LicenseOrder[licenseCount].ToString() + " License - " + licenseCost.ToString() + " IP");
        managerActions.Add("Search for Client");
        managerActions.Add("Freelance");
    }

    void PopulateList()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(managerActions);
    }

    public void Dropdown_IndexChanged(int index)
    {
        dropdownIndex = index;
    }

    public void ManagerActionButton_OnClick()
    {
        // Obtain Next License
        if (dropdownIndex == 1)
        {
            bool gotLicense = GameManager1.instance.ObtainNextLicense();
            if (gotLicense)
            {
                DetermineManagerActions();
                PopulateList();
            }
        }
        // Search For Client
        else if (dropdownIndex == 2)
        {
            if (GameManager1.instance.Agency.LicensesHeld.Count == 0)
                Debug.Log("Need to obtain a sports license before signing a player.");
        }
        // Freelance Work
        else if (dropdownIndex == 3)
        {
            GameManager1.instance.FreelanceCanvas.SetActive(true);
        }
    }
}
