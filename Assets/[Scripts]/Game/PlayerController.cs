using System.Collections;
using UnityEngine;
using EKTemplate;
using DG.Tweening;
using System.Collections.Generic;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [Header("VARIABLES")]

    public float clickSpeed;
    private bool firstTouch = true;
    public bool withPlane = false;
    public bool onClick = false;
    public bool isWin = false;
    public float minY, maxY;
    public GameObject arrow;

    public TextMeshProUGUI leveltxt;
    public TextMeshProUGUI planetxt;

    [Header("OtherThings")]

    public List<GameObject> moneyList = new List<GameObject>();

    #region Singleton
    public static PlayerController instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    void Start()
    {
        ShooterRotate();
        LevelManager.instance.startEvent.AddListener(() => StartEvent());
    }
    private void StartEvent()
    {
        clickSpeed = 1f;
        firstTouch = false;
    }
    void Update()
    {
        if (isWin) return;
        Movement();
    }
    #region Movement
    void Movement()
    {
        if (GameManager.instance.canClick)
        {
            if (!onClick || true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!firstTouch)
                    {
                        StartCoroutine(DELAY());
                        IEnumerator DELAY()
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                GameObject money = Instantiate(Resources.Load("money"), transform.GetChild(0).GetChild(0).position, transform.rotation) as GameObject;
                                moneyList.Add(money);
                                money.GetComponent<Ball>().StartShoot();
                                yield return new WaitForSeconds(0.35f);
                                arrow.SetActive(false);
                                transform.DOKill();
                            }
                        }
                        firstTouch = true;
                    }
                    if (clickDelayEnum != null)
                    {
                        StopCoroutine(clickDelayEnum);
                    }
                    clickDelayEnum = ClickDelay(clickSpeed);
                    StartCoroutine(clickDelayEnum);
                    Time.timeScale = 2f;

                    for (int i = 0; i < moneyList.Count; i++)
                    {
                        moneyList[i].GetComponent<Ball>().speed = GameManager.instance.speedfactor;
                        moneyList[i].transform.GetChild(0).GetComponent<TrailRenderer>().material.color = new Color(1f, 1f, 1f, 0.25f);
                    }
                    onClick = true;
                }
            }
        }
        GameManager.instance.canClick = true;
    }
    private IEnumerator clickDelayEnum;
    private IEnumerator ClickDelay(float _clickSpeed)
    {
        yield return new WaitForSeconds(_clickSpeed);
        for (int i = 0; i < moneyList.Count; i++)
        {
            moneyList[i].GetComponent<Ball>().speed = GameManager.instance.speedfactor/2;
            moneyList[i].transform.GetChild(0).GetComponent<TrailRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
        }
        Time.timeScale = 1f;
        onClick = false;
    }
    public void ShooterRotate()
    {
        transform.DOLocalRotate(new Vector3(0, -minY, 0), 2f).OnComplete(() =>
        {
            transform.DOLocalRotate(new Vector3(0, maxY, 0), 2f).OnComplete(() =>
            {
                ShooterRotate();
            });
        });
    }
    #endregion
}
