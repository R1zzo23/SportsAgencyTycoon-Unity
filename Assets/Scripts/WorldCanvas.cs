using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCanvas : MonoBehaviour
{
    public Dropdown SoccerTeamDropdown;
    public Dropdown HockeyTeamDropdown;

    // Start is called before the first frame update
    void Start()
    {
        PopulateSoccerTeamList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PopulateTeamLists();
    }

    public void CloseWorldCanvas()
    {
        GameManager1.instance.WorldCanvas.SetActive(false);
        GameManager1.instance.MainCanvas.SetActive(true);
    }

    public void PopulateTeamLists()
    {
        PopulateSoccerTeamList();
        PopulateHockeyTeamList();
    }

    public void PopulateSoccerTeamList()
    {
        SoccerTeamDropdown.ClearOptions();

        List<string> soccerTeams = new List<string>();
        foreach (Team t in GameManager1.instance.World.SoccerTeams)
            soccerTeams.Add(t.City + " " + t.Mascot);

        SoccerTeamDropdown.AddOptions(soccerTeams);

    }
    public void PopulateHockeyTeamList()
    {
        HockeyTeamDropdown.ClearOptions();

        List<string> hockeyTeams = new List<string>();
        foreach (Team t in GameManager1.instance.World.HockeyTeams)
            hockeyTeams.Add(t.City + " " + t.Mascot);

        HockeyTeamDropdown.AddOptions(hockeyTeams);

    }
}
