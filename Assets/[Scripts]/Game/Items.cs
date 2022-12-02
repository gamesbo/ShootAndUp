using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Items : MonoBehaviour
{
    public bool isCar = false;
    public bool isWatch = false;
    public bool isPlane = false;

    public int carLevel;
    public int watchLevel;
    public int planeLevel;

    public int hitCount;
    public int realhitCount;
    public int planehitCount;
    public int realplanehitCount;

    public GameObject[] cars;
    public GameObject[] watches;
    public GameObject[] planes;
    void Start()
    {
    }
    void Update()
    {
        if (isCar)
        {
            CarSwitch();
        }
        if (isWatch)
        {
            WatchSwitch();
        }
        if (isPlane)
        {
            PlaneSwitch();
        }
    }
    public void CarSwitch()
    {
        PlayerController.instance.leveltxt.text = "Level "+ realhitCount.ToString();
        switch (carLevel)
        {
            case 0:
                cars[0].SetActive(true);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);

                return;
            case 1:
                cars[0].SetActive(false);
                cars[1].SetActive(true);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                
                PlayerController.instance.leveltxt.color = new Color(0.23f, 0.86f, 1, 1);

                return;
            case 2:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(true);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                PlayerController.instance.leveltxt.color = new Color(0.883931f, 0.2313725f, 1, 1);

                return;
            case 3:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(true);
                cars[4].SetActive(false);
                cars[5].SetActive(false);
                PlayerController.instance.leveltxt.color = new Color(1f, 0.2313725f, 0.2693686f, 1);

                return;
            case 4:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(true);
                cars[5].SetActive(false);
                PlayerController.instance.leveltxt.color = new Color(0.3189939f, 1f, 0.2313725f, 1);

                return;
            case 5:
                cars[0].SetActive(false);
                cars[1].SetActive(false);
                cars[2].SetActive(false);
                cars[3].SetActive(false);
                cars[4].SetActive(false);
                cars[5].SetActive(true);
               
                PlayerController.instance.leveltxt.color = new Color(0.9931288f, 1f, 0.2313725f, 1);

                return;
        }
    }
    public void WatchSwitch()
    {
        PlayerController.instance.leveltxt.text = "Level " + realhitCount.ToString();

        switch (watchLevel)
        {
            case 0:
                 watches[0].SetActive(true);
                 watches[1].SetActive(false);
                 watches[2].SetActive(false);
                 watches[3].SetActive(false);
                 watches[4].SetActive(false);
                 watches[5].SetActive(false);

                return;
            case 1:
                 watches[0].SetActive(false);
                 watches[1].SetActive(true);
                 watches[2].SetActive(false);
                 watches[3].SetActive(false);
                 watches[4].SetActive(false);
                 watches[5].SetActive(false);
                PlayerController.instance.leveltxt.color = new Color(0.23f, 0.86f, 1, 1);

                return;
            case 2:
                watches[0].SetActive(false);
                watches[1].SetActive(false);
                watches[2].SetActive(true);
                watches[3].SetActive(false);
                watches[4].SetActive(false);
                watches[5].SetActive(false);
                PlayerController.instance.leveltxt.color = new Color(0.883931f, 0.2313725f, 1, 1);

                return;
            case 3:
                watches[0].SetActive(false);
                watches[1].SetActive(false);
                watches[2].SetActive(false);
                watches[3].SetActive(true);
                watches[4].SetActive(false);
                watches[5].SetActive(false);
                PlayerController.instance.leveltxt.color = new Color(1f, 0.2313725f, 0.2693686f, 1);

                return;
            case 4:
                watches[0].SetActive(false);
                watches[1].SetActive(false);
                watches[2].SetActive(false);
                watches[3].SetActive(false);
                watches[4].SetActive(true);
                watches[5].SetActive(false);
                PlayerController.instance.leveltxt.color = new Color(0.3189939f, 1f, 0.2313725f, 1);

                return;
            case 5:
                watches[0].SetActive(false);
                watches[1].SetActive(false);
                watches[2].SetActive(false);
                watches[3].SetActive(false);
                watches[4].SetActive(false);
                watches[5].SetActive(true);
                PlayerController.instance.leveltxt.color = new Color(0.9931288f, 1f, 0.2313725f, 1);

                return;
        }
    }
    public void PlaneSwitch()
    {
        PlayerController.instance.planetxt.text = "Level " + realplanehitCount.ToString();
        switch (planeLevel)
        {
            case 0:
                planes[0].SetActive(true);
                planes[1].SetActive(false);
                planes[2].SetActive(false);
                planes[3].SetActive(false);
                planes[4].SetActive(false);
                planes[5].SetActive(false);

                return;
            case 1:
                planes[0].SetActive(false);
                planes[1].SetActive(true);
                planes[2].SetActive(false);
                planes[3].SetActive(false);
                planes[4].SetActive(false);
                planes[5].SetActive(false);
                PlayerController.instance.planetxt.color = new Color(0.23f, 0.86f, 1, 1);
                return;
            case 2:
                planes[0].SetActive(false);
                planes[1].SetActive(false);
                planes[2].SetActive(true);
                planes[3].SetActive(false);
                planes[4].SetActive(false);
                planes[5].SetActive(false);
                PlayerController.instance.planetxt.color = new Color(0.883931f, 0.2313725f, 1, 1);

                return;
            case 3:
                planes[0].SetActive(false);
                planes[1].SetActive(false);
                planes[2].SetActive(false);
                planes[3].SetActive(true);
                planes[4].SetActive(false);
                planes[5].SetActive(false);
                PlayerController.instance.planetxt.color = new Color(1f, 0.2313725f, 0.2693686f, 1);

                return;
            case 4:
                planes[0].SetActive(false);
                planes[1].SetActive(false);
                planes[2].SetActive(false);
                planes[3].SetActive(false);
                planes[4].SetActive(true);
                planes[5].SetActive(false);
                PlayerController.instance.planetxt.color = Color.blue;
                PlayerController.instance.planetxt.color = new Color(0.3189939f, 1f, 0.2313725f, 1);

                return;
            case 5:
                planes[0].SetActive(false);
                planes[1].SetActive(false);
                planes[2].SetActive(false);
                planes[3].SetActive(false);
                planes[4].SetActive(false);
                planes[5].SetActive(true);
                PlayerController.instance.planetxt.color = Color.yellow;
                PlayerController.instance.planetxt.color = new Color(0.9931288f, 1f, 0.2313725f, 1);


                return;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("money"))
        {
            if (transform.localScale.y == 1.37f)
            {
                transform.DOScale(new Vector3(1.49f, 1.49f, 1.49f), 0.13f).OnComplete(() =>
                {
                    transform.DOScale(new Vector3(1.37f, 1.37f, 1.37f), 0.13f);
                });
            }
        }
    }
}
