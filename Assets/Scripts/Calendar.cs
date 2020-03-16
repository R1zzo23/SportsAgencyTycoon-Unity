using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    Agency Agency;
    public GameObject AgencyPanel;
    public Slider CalendarSlider;
    public Text YearText;
    public Text MonthText;
    public Text WeekText;
    int yearNumber;
    int monthNumber;
    int weekNumber;
    int WeekTimer = 1;
    float CurrentTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        yearNumber = 1;
        monthNumber = 1;
        weekNumber = 1;
        UpdateCalendarText();

        Agency = AgencyPanel.GetComponent<Agency>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager1.instance.TimerStarted)
        {
            CurrentTimer += Time.deltaTime;
            CalendarSlider.value = CurrentTimer / WeekTimer;
            if (CurrentTimer > WeekTimer)
            {
                CurrentTimer = 0;
                HandleCalendar();
            }
        }
    }

    public void UpdateCalendarText()
    {
        YearText.text = "Year: " + yearNumber;
        MonthText.text = "Month: " + monthNumber;
        WeekText.text = "Week: " + weekNumber;
    }

    public void HandleCalendar()
    {
        //add 1 to week number
        weekNumber++;

        //check if month ends
        if (((weekNumber == 5) && (monthNumber % 3 != 0)) || ((weekNumber == 6) && (monthNumber % 3 == 0)))
        {
            SetNewMonth();
            //MainForm.agency.ClientInteractions(rnd, MainForm);
            //PayPlayersMonthlySalary();
        }
        UpdateCalendarText();
    }
    private void SetNewMonth()
    {
        GameManager1.instance.AddToBalance(-Agency.OfficeMonthlyPayment());

        monthNumber++;
        if (monthNumber == 13)
        {
            SetNewYear();
        }
        weekNumber = 1;
    }
    private void SetNewYear()
    {
        monthNumber = 1;
        yearNumber++;
        //CreateAllEvents();
        //IncreasePrizePool();
    }
}
