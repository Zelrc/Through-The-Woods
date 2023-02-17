using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    [SerializeField] Image HPBar;
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject bar;
   
    // Update is called once per frame
    void Update()
    {
        bar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        if (transform.parent.GetComponent<CharacterScripts>())
        {
            HPBar.fillAmount = (float)(transform.parent.GetComponent<CharacterScripts>().health) / (float)(transform.parent.GetComponent<CharacterScripts>().character.maxHealth);
        }
        else if(transform.parent.GetComponent<EnemyScript>())
        {
            HPBar.fillAmount = (float)(transform.parent.GetComponent<EnemyScript>().health) / (float)(transform.parent.GetComponent<EnemyScript>().enemy.maxHealth);
        }
    }
}
