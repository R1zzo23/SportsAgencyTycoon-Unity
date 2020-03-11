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
        AgencyNameText.text = Agency.Name;
        UpdateUI();

        //BuyButtonText.text = "Buy: " + Agency.GetNextStoreCost().ToString("C2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        AgencyNameText.text = Agency.Name;
        AgencyIPText.text = "IP: " + Agency.InfluencePoints.ToString();
        AgencyMoneyText.text = "Money: " + Agency.Money.ToString("C0");
    }

    public void ObtainLicenseOnClick()
    {
        if (!GameManager1.instance.CanBuy(Agency.ObtainNextLicense()))
            return; // not enough funds to buy, so do nothing

        Agency.ObtainNextLicense();
        
        UpdateUI();
    }
}
