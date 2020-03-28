using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public string City;
    public string Mascot;
    public string Abbreviation;

    public string Conference;
    public string Division;

    public int MarketValue;
    public int TitleConteder;

    public int Wins;
    public int WinsThisWeek;
    public int ConferenceWins;
    public int DivisionWins;
    public int Losses;
    public int Ties;
    public int OTLosses;
    public int Points;
    public int ConferenceLosses;
    public int DivisionLosses;
    public bool PlayedGameThisCycle;

    //public List<Player> Roster = new List<Player>();
    //public List<Award> Awards = new List<Award>();

    public Team(string city, string mascot, string abbreviation, int marketValue, int titleContender)
    {
        City = city;
        Mascot = mascot;
        Abbreviation = abbreviation;
        MarketValue = marketValue;
        TitleConteder = titleContender;
        Wins = 0;
        ConferenceWins = 0;
        DivisionWins = 0;
        Losses = 0;
        ConferenceLosses = 0;
        DivisionLosses = 0;
    }
    public Team(string city, string mascot, string conference, string division, string abbreviation, int marketValue, int titleContender)
    {
        City = city;
        Mascot = mascot;
        Conference = conference;
        Division = division;
        Abbreviation = abbreviation;
        MarketValue = marketValue;
        TitleConteder = titleContender;
        Wins = 0;
        ConferenceWins = 0;
        DivisionWins = 0;
        Losses = 0;
        ConferenceLosses = 0;
        DivisionLosses = 0;
    }
    /*public Player DraftPlayer(Random rnd, List<Player> DraftEntrants, Sports sport, int numberOfRounds, int pick, int round)
    {
        Player draftedPlayer;

        if (round <= numberOfRounds / 2)
        {
            // do not draft Kickers or Punters in top half of the draft
            if (sport == Sports.Football)
            {
                for (int i = 2; i >= 0; i--)
                {
                    if (DraftEntrants[i].Position == Position.K || DraftEntrants[i].Position == Position.P)
                    {
                        Player p = DraftEntrants[i];
                        DraftEntrants.RemoveAt(i);
                        DraftEntrants.Insert(DraftEntrants.Count - 1, p);
                    }
                }
            }
            //make pick based on highest potential
            if (pick <= 10)
            {
                DraftEntrants = DraftEntrants.OrderByDescending(o => o.PotentialSkill).ToList();
                int index = rnd.Next(0, 3);
                if (DraftEntrants[0].PotentialSkill > DraftEntrants[1].PotentialSkill + 10) index = 0;

                draftedPlayer = DraftEntrants[index];
            }
            else if (pick <= 20)
            {
                int coinFlip = rnd.Next(1, 3);
                if (coinFlip == 1)
                {
                    DraftEntrants = DraftEntrants.OrderByDescending(o => o.CurrentSkill).ToList();
                }
                else DraftEntrants = DraftEntrants.OrderByDescending(o => o.PotentialSkill).ToList();

                int index = rnd.Next(0, 3);
                draftedPlayer = DraftEntrants[index];
            }
            else
            {
                DraftEntrants = DraftEntrants.OrderByDescending(o => o.CurrentSkill).ToList();
                int index = rnd.Next(0, 3);
                draftedPlayer = DraftEntrants[index];
            }
        }
        else
        {
            DraftEntrants = DraftEntrants.OrderByDescending(o => o.PotentialSkill).ToList();
            int index = rnd.Next(0, 3);
            if (DraftEntrants[0].PotentialSkill > DraftEntrants[1].PotentialSkill + 15) index = 0;

            draftedPlayer = DraftEntrants[index];
        }

        return draftedPlayer;
    }*/
}
