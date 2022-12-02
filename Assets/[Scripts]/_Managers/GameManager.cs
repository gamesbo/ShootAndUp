using UnityEngine;
using UnityEngine.SceneManagement;

namespace EKTemplate
{
    public class GameManager : MonoBehaviour
    {
        [Header("LEVEL'S"), Space(5)]
        public int level = -1;
        public int levelCount = 10;
        public int levelLoopFrom = 3;
        public bool canClick = true;

        [Header("CURRENCY"), Space(5)]
        public int money = 0;
        public bool _creative = false;
        public int[] SpeedCost;
        public int[] RangeCost;
        public int[] IncomeCosts;

        public int incomeLevel;
        public int speedLevel;
        public int rangeLevel;
        public int levelcounter;
        public int moneyfactor;
        public int speedfactor;
        public float rangefactor;
        public int[] goldrealfactors;
        public int[] speedrealfactors;
        public float[]rangerealfactors;
        public GameObject handTutorial;

        #region Singleton
        public static GameManager instance = null;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
                GetDependencies();
            }
            else
            {
                DestroyImmediate(this);
            }
        }
        #endregion

        private void GetDependencies()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || level == -1) level = DataManager.instance.level;
            money = DataManager.instance.money;
            incomeLevel = PlayerPrefs.GetInt("income-level", 0);
            speedLevel = PlayerPrefs.GetInt("speed-level", 0);
            rangeLevel = PlayerPrefs.GetInt("range-level", 0);
           
        }

        #region DataOperations
        public void AddMoney(int amount)
        {
            money += amount;
            DataManager.instance.SetMoney(money);
        }

        public void LevelUp()
        {
            DataManager.instance.SetLevel(++level);
        }
        #endregion

        #region SceneOperations
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OpenScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void OpenScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        #endregion
    }
}