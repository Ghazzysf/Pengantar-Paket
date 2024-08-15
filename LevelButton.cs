using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] LevelSelectMenu menu;
    [SerializeField] TMP_Text levelText;
    private Button levelButton;
    private int level, levelToLoad;

    void OnEnable()
    {
        levelButton = GetComponent<Button>();
    }
    
    public void Setup(int level, bool isUnlock)
    {
        var theColor = GetComponent<Button>().colors;
        this.level = level;
        levelText.text = level.ToString();
        levelToLoad = level + 3;

        if (isUnlock)
        {
            levelButton.enabled = true;
        }
        else
        {
            levelButton.enabled = false;
            theColor.normalColor = Color.gray;
            GetComponent<Button>().colors = theColor;
        }
    }

    public void OnClick()
    {
        print(levelToLoad);
        menu.StartLevel(levelToLoad);
    }
}