using System.Collections;
using UnityEngine;
using EKTemplate;
public class WinLoseController : MonoBehaviour
{
    #region SINGLETON
    public static WinLoseController instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    public void Win()
    {
        StartCoroutine(WinDelay());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Lose();
        }
    }
    public void Lose()
    {
        StartCoroutine(LoseDelay());
    }
    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(0.75f);
        PlayerController.instance.isWin = true;
        CameraManager.instance.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        LevelManager.instance.Success();
        Haptic.NotificationSuccessTaptic();
    }
    IEnumerator LoseDelay()
    {
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < PlayerController.instance.moneyList.Count; i++)
        {
            Destroy(PlayerController.instance.moneyList[i].gameObject);
        }
        LevelManager.instance.Fail();
        Haptic.NotificationErrorTaptic();
    }
}
