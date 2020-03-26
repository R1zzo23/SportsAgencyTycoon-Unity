using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class LoadTeamData : MonoBehaviour
{
    public TextAsset TeamData;

    public void Start()
    {
        LoadData();
    }
    public void LoadData()
    {
        // creates new XML Document
        XmlDocument xmlDoc = new XmlDocument();

        // loads GameData from variable above that we connected in inspector
        xmlDoc.LoadXml(TeamData.text);

        // adds every element with tag name of "store" to a list
        XmlNodeList SoccerTeamList = xmlDoc.GetElementsByTagName("SoccerTeam");

        // 
        foreach (XmlNode SoccerTeamInfo in SoccerTeamList)
        {

            XmlNodeList TeamNodes = SoccerTeamInfo.ChildNodes;
            foreach (XmlNode TeamNode in TeamNodes)
            {
                string city = "";
                string mascot = "";
                string abbrev = "";
                int titleContender = 0;
                int marketValue = 0;
                string conference = "";
                
                if (TeamNode.Name == "City")
                    city = TeamNode.InnerText;
                if (TeamNode.Name == "Mascot")
                    mascot = TeamNode.InnerText;
                if (TeamNode.Name == "Abbreviation")
                    abbrev = TeamNode.InnerText;
                if (TeamNode.Name == "Conference")
                    conference = TeamNode.InnerText;
                if (TeamNode.Name == "TitleContender")
                    titleContender = int.Parse(TeamNode.InnerText);
                if (TeamNode.Name == "MarketValue")
                    marketValue = int.Parse(TeamNode.InnerText);
                //if (TeamNode.Name == "image")
                //{
                // dynamically load images by finding sprite in resources folder
                //    Sprite newSprite = Resources.Load<Sprite>(StoreNode.InnerText);
                // drill down through prefab to find ImageButtonClick and access the Image component
                //    Image StoreImage = storeObject.transform.Find("ImageButtonClick").GetComponent<Image>();
                // set StoreImage to new sprite
                //    StoreImage.sprite = newSprite;

                //}

                Team team = new Team(city, mascot, abbrev, conference, "", marketValue, titleContender);
                GameManager1.instance.World.SoccerTeams.Add(team);
            }
        }

        foreach (Team t in GameManager1.instance.World.SoccerTeams)
            Debug.Log(t.City + " " + t.Mascot);
    }
}
