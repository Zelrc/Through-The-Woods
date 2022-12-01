using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DragLine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Button skill1;
    [SerializeField] Button skill2;
    [SerializeField] Button skill3;

    [SerializeField] Image portrait;

    public static CharacterScripts currentSelectedCharacter;

    private void Awake()
    {
        skill1.onClick.RemoveListener(SkillButton1Click);
        skill1.onClick.AddListener(SkillButton1Click);
        skill2.onClick.RemoveListener(SkillButton2Click);
        skill2.onClick.AddListener(SkillButton2Click);
        skill3.onClick.RemoveListener(SkillButton3Click);
        skill3.onClick.AddListener(SkillButton3Click);
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }

    void CurrentCharacterAssign(CharacterScripts character)
    {
        currentSelectedCharacter = character;

        skill1.GetComponent<Image>().sprite = character.character.Skill1.skillSprite;
        skill2.GetComponent<Image>().sprite = character.character.Skill2.skillSprite;
        skill3.GetComponent<Image>().sprite = character.character.Skill3.skillSprite;

        portrait.sprite = character.character.portrait;
    }

    void SkillButton1Click()
    {
        currentSelectedCharacter.character.Skill1.Activate(currentSelectedCharacter);
    }

    void SkillButton2Click()
    {
        currentSelectedCharacter.character.Skill2.Activate(currentSelectedCharacter);
    }

    void SkillButton3Click()
    {
        currentSelectedCharacter.character.Skill3.Activate(currentSelectedCharacter);
    }
}
