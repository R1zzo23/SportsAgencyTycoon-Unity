using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAgency : MonoBehaviour
{
    public Text AgencyNameText;
    public Text AgencyMoneyText;
    public Text AgencyIPText;
    public Slider ProgressSlider;
    public Text BuyButtonText;
    public Button BuyButton;

    public Image BaseballIcon;
    public Image BasketballIcon;
    public Image FootballIcon;
    public Image HockeyIcon;
    public Image SoccerIcon;

    public Agency Agency;

    void OnEnable()
    {
        GameManager1.OnUpdateBalance += UpdateUI;
    }

    void OnDisable()
    {
        GameManager1.OnUpdateBalance -= UpdateUI;
    }

    void Awake()
    {
        Agency = transform.GetComponent<Agency>();
    }

    // Start is called before the first frame update
    void Start()
    {
        AllSportsIconsInactive();
        UpdateUI();

        //BuyButtonText.text = "Buy: " + Agency.GetNextStoreCost().ToString("C2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AllSportsIconsInactive()
    {
        BaseballIcon.enabled = false;
        BasketballIcon.enabled = false;
        FootballIcon.enabled = false;
        HockeyIcon.enabled = false;
        SoccerIcon.enabled = false;
    }

    public void UpdateUI()
    {
        AgencyNameText.text = GameManager1.instance.Agency.Name;
        AgencyIPText.text = "IP: " + GameManager1.instance.Agency.InfluencePoints.ToString();
        AgencyMoneyText.text = "Money: " + GameManager1.instance.Agency.Money.ToString("C0");

        UpdateSportsIcons();
    }

    public void ObtainLicenseOnClick()
    {
        if (!GameManager1.instance.CanBuy(Agency.ObtainNextLicense()))
            return; // not enough funds to buy, so do nothing

        Agency.ObtainNextLicense();
        
        UpdateUI();
    }

    public void UpdateSportsIcons()
    {
        int licenses = GameManager1.instance.Agency.LicensesHeld.Count;
        if (licenses >= 1) SoccerIcon.enabled = true;
        if (licenses >= 2) HockeyIcon.enabled = true;
        if (licenses >= 3) BaseballIcon.enabled = true;
        if (licenses >= 4) BasketballIcon.enabled = true;
        if (licenses >= 5) FootballIcon.enabled = true;
    }
}
