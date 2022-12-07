using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EKTemplate;
using DG.Tweening;
public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 12.5f;
    public bool isWin= false;
    void Start()
    {
        StartShoot();
    }
    public void StartShoot()
    {
        rb.velocity = Vector3.zero;
        rb.velocity = PlayerController.instance.transform.GetChild(0).forward * speed; rb.velocity = transform.forward * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            Vector3 dir = new Vector3(-speed, 0, rb.velocity.z).normalized;
            rb.velocity = dir * speed;
        }
        else if (collision.gameObject.tag == "Left")
        {
            Vector3 dir = new Vector3(speed, 0, rb.velocity.z).normalized;
            rb.velocity = dir * speed;
        }
        else if (collision.gameObject.tag == "Down")
        {
            Vector3 dir = new Vector3(rb.velocity.x, 0, speed).normalized;
            rb.velocity = dir * speed;
        }
        else if (collision.gameObject.tag == "Up")
        {
            Vector3 dir = new Vector3(rb.velocity.x, 0, -speed).normalized;
            rb.velocity = dir * speed;
        }
        else if (collision.gameObject.tag == "Obs")
        {
        }
        else if (collision.gameObject.tag == "item")
        {
            if (PlayerController.instance.isWin) return;
            Haptic.LightTaptic();
            GameManager.instance.AddMoney(1);
            UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value += 0.0042f;
            collision.transform.parent.gameObject.GetComponent<Items>().hitCount++;
            collision.transform.parent.gameObject.GetComponent<Items>().realhitCount++;
            collision.transform.parent.gameObject.GetComponent<Items>().realplanehitCount++;
            collision.transform.parent.gameObject.GetComponent<Items>().planehitCount++;
            if(collision.transform.parent.gameObject.GetComponent<Items>().hitCount >= 150)
            {
                if (isWin) return;
                if (PlayerController.instance.withPlane)
                {
                    if (collision.transform.parent.gameObject.GetComponent<Items>().carLevel > 4 || collision.transform.parent.gameObject.GetComponent<Items>().watchLevel > 4)
                    {
                        WinLoseController.instance.Win();
                        isWin = true;
                    }
                }
                else
                {
                    if (collision.transform.parent.gameObject.GetComponent<Items>().carLevel > 4 && collision.transform.parent.gameObject.GetComponent<Items>().planeLevel > 4)
                    {
                        WinLoseController.instance.Win();
                        isWin = true;
                    }
                }
                if (collision.transform.parent.gameObject.GetComponent<Items>().isCar)
                {
                    UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value = 0f;
                    collision.transform.parent.gameObject.GetComponent<Items>().carLevel++;
                    collision.transform.parent.gameObject.GetComponent<Items>().hitCount= 0;
                    Instantiate(Resources.Load("particles/Clouds"), new Vector3(collision.transform.parent.position.x, collision.transform.parent.position.y + 7f,
                        collision.transform.parent.position.z), Quaternion.identity);
                }
                else if (collision.transform.parent.gameObject.GetComponent<Items>().isWatch)
                {
                    UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value = 0f;
                    collision.transform.parent.gameObject.GetComponent<Items>().watchLevel++;
                    collision.transform.parent.gameObject.GetComponent<Items>().hitCount = 0;
                    Instantiate(Resources.Load("particles/Clouds"), new Vector3(collision.transform.parent.position.x, collision.transform.parent.position.y + 7f,
                        collision.transform.parent.position.z), Quaternion.identity);
                }
            }
            if (collision.transform.parent.gameObject.GetComponent<Items>().planehitCount >= 150)
            {
                if (isWin) return;
                if (collision.transform.parent.gameObject.GetComponent<Items>().carLevel > 4 && collision.transform.parent.gameObject.GetComponent<Items>().planeLevel > 4)
                {
                    WinLoseController.instance.Win();
                    isWin = true;
                }
                if (collision.transform.parent.gameObject.GetComponent<Items>().isPlane)
                {
                    UIManager.instance.gamePanel.bar.GetComponent<ProgressBarPro>().Value = 0f;
                    collision.transform.parent.gameObject.GetComponent<Items>().planeLevel++;
                    collision.transform.parent.gameObject.GetComponent<Items>().planehitCount = 0;
                    Instantiate(Resources.Load("particles/Clouds"), new Vector3(collision.transform.parent.position.x, collision.transform.parent.position.y + 7f,
                        collision.transform.parent.position.z), Quaternion.identity);
                }
            }
        }
    }
}
