using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreelanceJob
{
    public string JobName;
    public string JobDescription;
    public double BaselineJobScore;
    public int IPPayout;
    public int MoneyPayout;
    public int PointsUntilCompletion;

    public FreelanceJob(string jobName, string jobDescription, double baselineJobScore, int ipPayout, int moneyPayout, int pointsUntilCompletion)
    {
        JobName = jobName;
        JobDescription = jobDescription;
        BaselineJobScore = baselineJobScore;
        IPPayout = ipPayout;
        MoneyPayout = moneyPayout;
        PointsUntilCompletion = pointsUntilCompletion;
    }
}
