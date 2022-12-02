using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;
using System.Collections;
namespace EKTemplate
{
    public class GamePanel : Panel
    {
        public RectTransform coinPanelRect;
        public RectTransform restartButtonRect;
        public GameObject bar;
        [HideInInspector] int inGameCurrency;
        private Tween tween;
        public bool checkBallPanel = false;
        public bool checkBallButtons = false;
        private Text moneyText { get { return coinPanelRect.GetChild(1).GetChild(0).GetComponent<Text>(); } }
        private Button restartButton { get { return restartButtonRect.GetComponent<Button>(); } }
        public void OnUpgradeButtonEnter()
        {
            GameManager.instance.canClick = false;
        }
        private void Start()
        {
            restartButton.onClick.AddListener(OnClickRestartButton);
        }
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1.5f);
            checkBallButtons = true;
        }
        private void Update()
        {
            moneyText.text = GameManager.instance.money.ToString();

            if (bar.GetComponent<ProgressBarPro>().Value >= 1 && !checkBallPanel)
            {
                checkBallButtons = false;
                StartCoroutine(Delay());
                checkBallPanel = true;
            }
        }
        public void SetMoney(float to, float duration = 0.3f)
        {
            if (tween != null) tween.Kill();

            coinPanelRect
            .DOScale(1.2f, duration * 0.5f)
            .SetEase(Ease.Linear)
            .SetLoops(2, LoopType.Yoyo);

            float startFrom = int.Parse(moneyText.text);
            tween = DOTween.To((x) => startFrom = x, startFrom, to, duration)
            .OnUpdate(() =>
            {
                moneyText.text = ((int)startFrom).ToString();
            })
            .OnComplete(() => moneyText.text = ((int)to).ToString());
        }
        public void AddMoney(int amount)
        {
            float startFrom = int.Parse(moneyText.text);
            SetMoney(inGameCurrency + amount);
        }
        private void OnClickRestartButton()
        {
            GameManager.instance.RestartScene();
        }
    }
}