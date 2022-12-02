using UnityEngine;
using UnityEngine.UI;
using EKTemplate;
using TMPro;
using System.Collections;
public class Upgrade : MonoBehaviour
{
    private GameManager gm;

    [Header("INCOME")]
    public TextMeshProUGUI incomeAmountTxt;
    public TextMeshProUGUI incomeAmountTxt2;
    public GameObject incomePanel;
    public GameObject incomePanelfake;
    [Header("SPEED")]
    public TextMeshProUGUI speedAmountTxt;
    public TextMeshProUGUI speedAmountTxt2;
    public GameObject speedPanel;
    public GameObject speedPanelfake;
    [Header("RANGE")]
    public TextMeshProUGUI rangeAmountTxt;
    public TextMeshProUGUI rangeAmountTxt2;
    public GameObject rangePanel;
    public GameObject rangePanelfake;
    [Header("ADD MONEY")]
    public TextMeshProUGUI ADDAmountTxt;
    public Animator Speedanim;
    public Animator Rangeanim;
    public Animator Incomenim;
    #region Singleton
    public static Upgrade instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    public void LoadResources()
    {
        speedAmountTxt.text = gm.SpeedCost[gm.speedLevel + 1] + "$".ToString();
        speedAmountTxt2.text = gm.SpeedCost[gm.speedLevel + 1] + "$".ToString();

        rangeAmountTxt.text = gm.RangeCost[gm.rangeLevel + 1] + "$".ToString();
        rangeAmountTxt2.text = gm.RangeCost[gm.rangeLevel + 1] + "$".ToString();

        incomeAmountTxt.text = gm.IncomeCosts[gm.incomeLevel + 1] + "$".ToString();
        incomeAmountTxt2.text = gm.IncomeCosts[gm.incomeLevel + 1] + "$".ToString();

        gm.speedLevel = PlayerPrefs.GetInt("speed-level", 0);
        gm.incomeLevel = PlayerPrefs.GetInt("income-level", 0);
        gm.rangeLevel = PlayerPrefs.GetInt("range-level", 0);

        gm.moneyfactor = gm.goldrealfactors[gm.incomeLevel + 1];
        gm.rangefactor = gm.rangerealfactors[gm.rangeLevel + 1];
        gm.speedfactor = gm.speedrealfactors[gm.speedLevel + 1];
    }
    private void Start()
    {
        gm = GameManager.instance;
        LoadResources();
    }
    private void Update()
    {
        if (gm.speedLevel < 10)
        {
            if (gm.money >= gm.SpeedCost[gm.speedLevel + 1])
            {
                speedPanel.SetActive(true);
                speedPanelfake.SetActive(false);
            }
            else
            {
                speedPanel.SetActive(false);
                speedPanelfake.SetActive(true);
            }
        }
        else
        {
            speedPanel.SetActive(false);
            speedPanelfake.SetActive(true);
            speedAmountTxt2.text = "MAX".ToString();
        }
        if (gm.rangeLevel < 10)
        {
            if (gm.money >= gm.RangeCost[gm.rangeLevel + 1])
            {
                rangePanel.SetActive(true);
                rangePanelfake.SetActive(false);
            }
            else
            {
                rangePanel.SetActive(false);
                rangePanelfake.SetActive(true);
            }
        }
        else
        {
            rangePanel.SetActive(false);
            rangePanelfake.SetActive(true);
            rangeAmountTxt2.text = "MAX".ToString();
        }
        if (gm.incomeLevel < 15)
        {
            if (gm.money >= gm.IncomeCosts[gm.incomeLevel + 1])
            {
                incomePanel.SetActive(true);
                incomePanelfake.SetActive(false);
            }
            else
            {
                incomePanel.SetActive(false);
                incomePanelfake.SetActive(true);
            }
        }
        else
        {
            incomePanel.SetActive(false);
            incomePanelfake.SetActive(true);
            incomeAmountTxt2.text = "MAX".ToString();
        }
    }
    public void BallSpeedFactor()
    {
        if (gm.speedLevel == 10) return;
        if (gm.money >= gm.SpeedCost[gm.speedLevel + 1])
        {
            Haptic.LightTaptic();
            Speedanim.SetTrigger("Click");
            PlayerPrefs.SetInt("speed-level", ++gm.speedLevel);
            PlayerPrefs.Save();
            speedAmountTxt.text = gm.SpeedCost[gm.speedLevel + 1] + "$".ToString();
            speedAmountTxt2.text = gm.SpeedCost[gm.speedLevel + 1] + "$".ToString();
            gm.speedfactor = gm.speedrealfactors[gm.speedLevel + 1];
            gm.AddMoney(-(gm.SpeedCost[gm.speedLevel]));
            UIManager.instance.gamePanel.AddMoney(-(gm.SpeedCost[gm.speedLevel]));
        }
    }
    public void RangeFactor()
    {
        if (gm.rangeLevel == 10) return;
        if (gm.money >= gm.RangeCost[gm.rangeLevel + 1])
        {
            Haptic.LightTaptic();
            Rangeanim.SetTrigger("Click");
            PlayerPrefs.SetInt("range-level", ++gm.rangeLevel);
            PlayerPrefs.Save();
            rangeAmountTxt.text = gm.RangeCost[gm.rangeLevel + 1] + "$".ToString();
            rangeAmountTxt2.text = gm.RangeCost[gm.rangeLevel + 1] + "$".ToString();
            for (int i = 0; i < PlayerController.instance.moneyList.Count; i++)
            {
                gm.rangefactor = gm.rangerealfactors[gm.rangeLevel + 1];
                PlayerController.instance.moneyList[i].transform.GetChild(1).GetComponent<SphereCollider>().radius = gm.rangefactor;
            }
            gm.AddMoney(-(gm.RangeCost[gm.rangeLevel]));
            UIManager.instance.gamePanel.AddMoney(-(gm.RangeCost[gm.rangeLevel]));
        }
    }
    public void IncomeFactor()
    {
        if (gm.incomeLevel == 15) return;
        if (gm.money >= gm.IncomeCosts[gm.incomeLevel + 1])
        {
            Haptic.LightTaptic();
            Incomenim.SetTrigger("Click");
            PlayerPrefs.SetInt("income-level", ++gm.incomeLevel);
            PlayerPrefs.Save();
            incomeAmountTxt.text = gm.IncomeCosts[gm.incomeLevel + 1]+ "$".ToString();
            incomeAmountTxt2.text = gm.IncomeCosts[gm.incomeLevel + 1] + "$".ToString();
            gm.moneyfactor = gm.goldrealfactors[gm.incomeLevel + 1];
            gm.AddMoney(-(gm.IncomeCosts[gm.incomeLevel]));
            UIManager.instance.gamePanel.AddMoney(-(gm.IncomeCosts[gm.incomeLevel]));
        }
    }
    public void AddGoldenBall()
    {
        if (!UIManager.instance.gamePanel.checkBallButtons) return;
        Haptic.LightTaptic();
        UIManager.instance.gamePanel.checkBallPanel = false;
        UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value = 0;
        GameObject goldenBall = Instantiate(Resources.Load("Goldenball"), PlayerController.instance.transform.GetChild(0).GetChild(0).position, Quaternion.identity) as GameObject;
        PlayerController.instance.moneyList.Add(goldenBall);
        goldenBall.GetComponent<Ball>().StartShoot();
    }
    public void AddLazerBall()
    {
        if (!UIManager.instance.gamePanel.checkBallButtons) return;
        Haptic.LightTaptic();
        UIManager.instance.gamePanel.checkBallPanel = false;
        UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value = 0;
        GameObject Plasmaball = Instantiate(Resources.Load("Plasmaball"), PlayerController.instance.transform.GetChild(0).GetChild(0).position, Quaternion.identity) as GameObject;
        PlayerController.instance.moneyList.Add(Plasmaball);
        Plasmaball.GetComponent<Ball>().StartShoot();
    }
    public void AddFireBall()
    {
        if (!UIManager.instance.gamePanel.checkBallButtons) return;
        Haptic.LightTaptic();
        UIManager.instance.gamePanel.checkBallPanel = false;
        UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value = 0;
        GameObject fireBall = Instantiate(Resources.Load("Fireball"), PlayerController.instance.transform.GetChild(0).GetChild(0).position, Quaternion.identity) as GameObject;
        PlayerController.instance.moneyList.Add(fireBall);
        fireBall.GetComponent<Ball>().StartShoot();
    }
    public void AddBombBall()
    {
        if (!UIManager.instance.gamePanel.checkBallButtons) return;
        Haptic.LightTaptic();
        UIManager.instance.gamePanel.checkBallPanel = false;
        UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value = 0;
        GameObject Bombball = Instantiate(Resources.Load("Bombball"), PlayerController.instance.transform.GetChild(0).GetChild(0).position, Quaternion.identity) as GameObject;
        PlayerController.instance.moneyList.Add(Bombball);
        Bombball.GetComponent<Ball>().StartShoot();
    }
}
