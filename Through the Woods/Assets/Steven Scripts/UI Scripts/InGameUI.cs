using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DragLine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

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

    [SerializeField] TextMeshProUGUI HPText;

    [SerializeField] Image nameText;

    [SerializeField] GameObject UIPanel;

    [SerializeField] GameObject WinUI;

    [SerializeField] Button next;
    [SerializeField] Button exit1;

    [SerializeField] GameObject LoseUI;

    [SerializeField] Button restart;
    [SerializeField] Button exit2;

    [SerializeField] GameObject skillPanel;
    [SerializeField] Image skillImage;
    [SerializeField] TextMeshProUGUI skillNameText;
    [SerializeField] TextMeshProUGUI skillInfoText;
    [SerializeField] TextMeshProUGUI dmgNumText;
    [SerializeField] TextMeshProUGUI cdNumText;

    [SerializeField] TextMeshProUGUI CDRemainingText;
    [SerializeField] TextMeshProUGUI CDMaxText;
    [SerializeField] Image CDbar;


    selectedSkills currentSkill = selectedSkills.NONE;

    public static CharacterScripts currentSelectedCharacter;

    public static int killCount;

    [SerializeField] int neededKill;

    Coroutine changingPhase;

    [SerializeField] GameObject VIP;

    public static Action closeSkillSelectUI;

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
        CDRemainingText.text = "" + CDint;
        
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
        //if(currentSkill == selectedSkills.NONE)
        //{
        //    skillActivation.interactable = false;
        //}
        //else
        //{
        //    skillActivation.interactable = true;
        //}

        CDRemainingText.text = "" + CDint;
        CDMaxText.text = "" + maxCDint;
        CDbar.fillAmount = (float)(CDint) / (float)(maxCDint);

        if (killCount >= neededKill)
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
        skill1.GetComponent<Image>().sprite = character.character.Skill1.skillSprite;
        skill2.GetComponent<Image>().sprite = character.character.Skill2.skillSprite;
        skill3.GetComponent<Image>().sprite = character.character.Skill3.skillSprite;

        portrait.sprite = character.character.portrait;

        nameText.sprite = character.character.name;

        HPText.text = character.health.ToString() + "/" + character.character.maxHealth.ToString();
        
        if(currentSelectedCharacter.usedSkill)
        {
            skill1.interactable = false;
            skill2.interactable = false;
            skill3.interactable = false;
        }
        else
        {
            skill1.interactable = true;
            skill2.interactable = true;
            skill3.interactable = true;
        }
    }

    void SkillButton1Click()
    {
        if(currentSkill != selectedSkills.ONE)
        {
            currentSelectedCharacter.character.Skill2.Deactivate(currentSelectedCharacter);
            currentSelectedCharacter.character.Skill3.Deactivate(currentSelectedCharacter);
            currentSelectedCharacter.character.Skill1.Activate(currentSelectedCharacter);
            ShowSkillInfo(1);
            currentSkill = selectedSkills.ONE;
        }
        else
        {
            skillPanel.SetActive(false);
            choosingTarget = false;
            currentSelectedCharacter.character.Skill1.Deactivate(currentSelectedCharacter);
            currentSkill = selectedSkills.NONE;
            closeSkillSelectUI?.Invoke();
        }
        
    }

    void SkillButton2Click()
    {
        if(currentSkill != selectedSkills.TWO)
        {
            currentSelectedCharacter.character.Skill1.Deactivate(currentSelectedCharacter);
            currentSelectedCharacter.character.Skill3.Deactivate(currentSelectedCharacter);
            currentSelectedCharacter.character.Skill2.Activate(currentSelectedCharacter);
            ShowSkillInfo(2);
            currentSkill = selectedSkills.TWO;
        }
        else
        {
            skillPanel.SetActive(false);
            choosingTarget = false;
            currentSelectedCharacter.character.Skill2.Deactivate(currentSelectedCharacter);
            currentSkill = selectedSkills.NONE;
            closeSkillSelectUI?.Invoke();
        }
        
    }

    void SkillButton3Click()
    {
        if(currentSkill != selectedSkills.THREE)
        {
            currentSelectedCharacter.character.Skill2.Deactivate(currentSelectedCharacter);
            currentSelectedCharacter.character.Skill1.Deactivate(currentSelectedCharacter);
            currentSelectedCharacter.character.Skill3.Activate(currentSelectedCharacter);
            ShowSkillInfo(3);
            currentSkill = selectedSkills.THREE;
        }
        else
        {
            skillPanel.SetActive(false);
            choosingTarget = false;
            currentSelectedCharacter.character.Skill2.Deactivate(currentSelectedCharacter);
            currentSkill = selectedSkills.NONE;
            closeSkillSelectUI?.Invoke();
        }
        
    }

    void ShowSkillInfo(int skillNum)
    {
        skillPanel.SetActive(true);
        switch(skillNum)
        {
            case 1:
                skillImage.sprite = currentSelectedCharacter.character.Skill1.skillSprite;
                skillNameText.text = currentSelectedCharacter.character.Skill1.name;
                skillInfoText.text = currentSelectedCharacter.character.Skill1.description;
                dmgNumText.text = currentSelectedCharacter.character.Skill1.damage.ToString();
                cdNumText.text = currentSelectedCharacter.character.Skill1.CD.ToString();
                if(currentSelectedCharacter.character.Skill1.CD > CDint)
                {
                    skillActivation.interactable = false;
                    enoughCD = false;
                }
                else
                {
                    enoughCD = true;
                    if(!currentSelectedCharacter.character.Skill1.needTarget)
                    {
                        skillActivation.interactable = true;
                    }
                }
                break;
            case 2:
                skillImage.sprite = currentSelectedCharacter.character.Skill2.skillSprite;
                skillNameText.text = currentSelectedCharacter.character.Skill2.name;
                skillInfoText.text = currentSelectedCharacter.character.Skill2.description;
                dmgNumText.text = currentSelectedCharacter.character.Skill2.damage.ToString();
                cdNumText.text = currentSelectedCharacter.character.Skill2.CD.ToString();
                if (currentSelectedCharacter.character.Skill2.CD > CDint)
                {
                    skillActivation.interactable = false;
                    enoughCD = false;
                }
                else
                {
                    enoughCD = true;
                    if (!currentSelectedCharacter.character.Skill2.needTarget)
                    {
                        skillActivation.interactable = true;
                    }
                }
                break;
            case 3:
                skillImage.sprite = currentSelectedCharacter.character.Skill3.skillSprite;
                skillNameText.text = currentSelectedCharacter.character.Skill3.name;
                skillInfoText.text = currentSelectedCharacter.character.Skill3.description;
                dmgNumText.text = currentSelectedCharacter.character.Skill3.damage.ToString();
                cdNumText.text = currentSelectedCharacter.character.Skill3.CD.ToString();
                if (currentSelectedCharacter.character.Skill3.CD > CDint)
                {
                    skillActivation.interactable = false;
                    enoughCD = false;
                }
                else
                {
                    enoughCD = true;
                    if (!currentSelectedCharacter.character.Skill3.needTarget)
                    {
                        skillActivation.interactable = true;
                    }
                }
                break;
        }
        
    }

    void UseSkillsConfirmation()
    {
        if(currentSkill != selectedSkills.NONE)
        {
            if (currentSkill == selectedSkills.ONE)
            {
                currentSelectedCharacter.character.Skill1.UseSkill(currentSelectedCharacter);
                CDint -= currentSelectedCharacter.character.Skill1.CD;
                Debug.Log(CDint);
            }
            else if (currentSkill == selectedSkills.TWO)
            {
                currentSelectedCharacter.character.Skill2.UseSkill(currentSelectedCharacter);
                CDint -= currentSelectedCharacter.character.Skill2.CD;
            }
            else if (currentSkill == selectedSkills.THREE)
            {
                currentSelectedCharacter.character.Skill3.UseSkill(currentSelectedCharacter);
                CDint -= currentSelectedCharacter.character.Skill3.CD;
            }
            skill1.interactable = false;
            skill2.interactable = false;
            skill3.interactable = false;
            currentSkill = selectedSkills.NONE;
            skillPanel.SetActive(false);
            closeSkillSelectUI?.Invoke();
            currentSelectedCharacter.usedSkill = true;
        }
        
    }
    public void OnActionStage()
    {
        ActionPhase = true;
        actionButton.interactable = false;
        UIPanel.SetActive(false);
        skillPanel.SetActive(false);
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

        CDint = maxCDint;
        
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
