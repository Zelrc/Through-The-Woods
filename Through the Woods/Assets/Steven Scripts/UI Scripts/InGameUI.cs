using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DragLine;
using TMPro;
using UnityEngine.SceneManagement;

public enum selectedSkills
{
    NONE,
    ONE,
    TWO,
    THREE
}
public class InGameUI : MonoBehaviour
{
    [SerializeField] Button skill1;
    [SerializeField] Button skill2;
    [SerializeField] Button skill3;

    [SerializeField] Button skillActivation;

    [SerializeField] Image portrait;

    [SerializeField] Button actionButton;

    [SerializeField] Image HPBar;
    [SerializeField] TextMeshProUGUI HPText;

    [SerializeField] TextMeshProUGUI nameText;

    [SerializeField] GameObject UIPanel;

    [SerializeField] GameObject WinUI;

    [SerializeField] Button next;
    [SerializeField] Button exit1;

    [SerializeField] GameObject LoseUI;

    [SerializeField] Button restart;
    [SerializeField] Button exit2;

    selectedSkills currentSkill = selectedSkills.NONE;

    public static CharacterScripts currentSelectedCharacter;

    public static int killCount;

    [SerializeField] int neededKill;

    Coroutine changingPhase;

    [SerializeField] GameObject VIP;

    private void Awake()
    {
        skill1.onClick.RemoveListener(SkillButton1Click);
        skill1.onClick.AddListener(SkillButton1Click);
        skill2.onClick.RemoveListener(SkillButton2Click);
        skill2.onClick.AddListener(SkillButton2Click);
        skill3.onClick.RemoveListener(SkillButton3Click);
        skill3.onClick.AddListener(SkillButton3Click);
        skillActivation.onClick.RemoveListener(UseSkillsConfirmation);
        skillActivation.onClick.AddListener(UseSkillsConfirmation);
        actionButton.onClick.RemoveListener(OnActionStage);
        actionButton.onClick.AddListener(OnActionStage);
        next.onClick.RemoveListener(GoNextScene);
        next.onClick.AddListener(GoNextScene);
        restart.onClick.RemoveListener(RestartScene);
        restart.onClick.AddListener(RestartScene);
        exit1.onClick.RemoveListener(ExitGame);
        exit2.onClick.RemoveListener(ExitGame);
        exit1.onClick.AddListener(ExitGame);
        exit2.onClick.AddListener(ExitGame);
    }
    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
    }

    private void OnEnable()
    {
        DragLine.characterCall += CurrentCharacterAssign;
    }

    private void OnDisable()
    {
        DragLine.characterCall -= CurrentCharacterAssign;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSkill == selectedSkills.NONE)
        {
            skillActivation.interactable = false;
        }
        else
        {
            skillActivation.interactable = true;
        }

        if(killCount >= neededKill)
        {
            WinUI.SetActive(true);
        }

        if(VIP.GetComponent<CharacterScripts>().health <= 0)
        {
            LoseUI.SetActive(true);
        }
    }

    void CurrentCharacterAssign(CharacterScripts character)
    {
        UIPanel.SetActive(true);
        currentSelectedCharacter = character;
        currentSelectedCharacter.agent.ResetPath();
        currentSelectedCharacter.agent.isStopped = false;
        //skill1.GetComponent<Image>().sprite = character.character.Skill1.skillSprite;
        //skill2.GetComponent<Image>().sprite = character.character.Skill2.skillSprite;
        //skill3.GetComponent<Image>().sprite = character.character.Skill3.skillSprite;

        //portrait.sprite = character.character.portrait;

        //nameText.text = character.character.name;

        HPText.text = character.health.ToString() + "/" + character.character.maxHealth.ToString();
        HPBar.fillAmount = (float)character.health / (float)(character.character.maxHealth);
    }

    void SkillButton1Click()
    {
        currentSelectedCharacter.character.Skill2.Deactivate(currentSelectedCharacter);
        currentSelectedCharacter.character.Skill3.Deactivate(currentSelectedCharacter);
        currentSelectedCharacter.character.Skill1.Activate(currentSelectedCharacter);
        
        currentSkill = selectedSkills.ONE;
    }

    void SkillButton2Click()
    {
        currentSelectedCharacter.character.Skill1.Deactivate(currentSelectedCharacter);
        currentSelectedCharacter.character.Skill3.Deactivate(currentSelectedCharacter);
        currentSelectedCharacter.character.Skill2.Activate(currentSelectedCharacter);
        currentSkill = selectedSkills.TWO;
    }

    void SkillButton3Click()
    {
        currentSelectedCharacter.character.Skill2.Deactivate(currentSelectedCharacter);
        currentSelectedCharacter.character.Skill1.Deactivate(currentSelectedCharacter);
        currentSelectedCharacter.character.Skill3.Activate(currentSelectedCharacter);
        currentSkill = selectedSkills.THREE;
    }

    void UseSkillsConfirmation()
    {
        if(currentSkill != selectedSkills.NONE)
        {
            if (currentSkill == selectedSkills.ONE)
            {
                currentSelectedCharacter.character.Skill1.UseSkill(currentSelectedCharacter);
            }
            else if (currentSkill == selectedSkills.TWO)
            {
                currentSelectedCharacter.character.Skill2.UseSkill(currentSelectedCharacter);
            }
            else if (currentSkill == selectedSkills.THREE)
            {
                currentSelectedCharacter.character.Skill3.UseSkill(currentSelectedCharacter);
            }
            skill1.interactable = false;
            skill2.interactable = false;
            skill3.interactable = false;
            currentSkill = selectedSkills.NONE;
        }
        
    }
    public void OnActionStage()
    {
        ActionPhase = true;
        actionButton.interactable = false;
        UIPanel.SetActive(false);
        StartCoroutine(changePhase());
        //if (changingPhase != null)
        //{
        //    StopCoroutine(changingPhase);
        //    changingPhase = StartCoroutine(changePhase());
        //}
    }
    IEnumerator changePhase()
    {
        yield return new WaitForSeconds(1.2f);
        
        ActionPhase = false;
        actionButton.interactable = true;
        skill1.interactable = true;
        skill2.interactable = true;
        skill3.interactable = true;
        
    }

    void GoNextScene()
    {
        SceneManager.LoadScene("Stage1_Second");
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
