using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Obstacle : MonoBehaviour
{
    public int multipleFactor;
    private bool check = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("money"))
        {
            if(transform.localScale.y == 4.5f)
            {
                transform.DOScale(new Vector3(4.8f, 5f, 4.8f), 0.13f).OnComplete(() =>
                {
                    transform.DOScale(new Vector3(4.2f, 4.5f, 4.2f), 0.13f);
                });
            }
            StartCoroutine(Delay());
            IEnumerator Delay()
            {
                if (PlayerController.instance.moneyList.Count < 96)
                {
                    for (int i = 0; i < multipleFactor; i++)
                    {
                        yield return new WaitForSeconds(0.1f);
                        GameObject money = Instantiate(Resources.Load("money"), new Vector3(collision.transform.position.x ,
                            collision.transform.position.y, collision.transform.position.z ), transform.rotation) as GameObject;
                        PlayerController.instance.moneyList.Add(money);
                        money.GetComponent<Ball>().StartShoot();
                    }
                }
            }
        }
    }
}
