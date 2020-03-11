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
        managerActions.Add("Manager Actions:");
        managerActions.Add("Obtain Next License");
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
        Debug.Log(managerActions[index]);
        dropdownIndex = index;
    }

    public void ManagerActionButton_OnClick()
    {
        Debug.Log("dropdownIndex: " + dropdownIndex);
        if (dropdownIndex > 0)
            Debug.Log(managerActions[dropdownIndex]);
    }
}
