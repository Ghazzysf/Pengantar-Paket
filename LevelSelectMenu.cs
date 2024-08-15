using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] Button nextButton, previousButton;

    private LevelButton[] levelButtons;

    public int totalLevel, unlockedLevel;
    private int totalPage = 0;
    private int page = 0;
    private int pageItem = 10;

    void OnEnable()
    {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }

    void Start()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 4);
        print(unlockedLevel);
        Refresh();
    }

    public void StartLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void ClickNext()
    {
        page += 1;
        Refresh();
    }

    public void ClickPrevious()
    {
        page -= 1;
        Refresh();
    }

    void Refresh()
    {
        totalPage = totalLevel / pageItem;

        int index = page * pageItem;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = index + i + 1;
            print(level);

            if (level <= totalLevel)
            {
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].Setup(level, level <= unlockedLevel - 3);
            }
            else
            {
                levelButtons[i].gameObject.SetActive(false);
            }
        }
        CheckButton();
    }

    void CheckButton()
    {
        nextButton.gameObject.SetActive(page + 1 < totalPage);
        previousButton.gameObject.SetActive(page > 0);
    }
}