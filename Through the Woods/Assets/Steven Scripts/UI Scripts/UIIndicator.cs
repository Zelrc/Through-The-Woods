using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIIndicator : MonoBehaviour
{
    GameObject flyingUI;
    // Start is called before the first frame update
    void Start()
    {
        flyingUI = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHover(GameObject button)
    {
        flyingUI.GetComponent<Image>().enabled = true;
        flyingUI.transform.position = new Vector2(button.transform.position.x + 100, button.transform.position.y + 15);
    }

    public void ExitHover()
    {
        flyingUI.GetComponent<Image>().enabled = false;
    }
}
