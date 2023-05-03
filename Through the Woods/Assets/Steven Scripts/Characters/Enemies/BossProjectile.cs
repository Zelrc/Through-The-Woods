using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterScripts>())
        {
            if (!collision.gameObject.GetComponent<CharacterScripts>().parryBuff && !collision.gameObject.GetComponent<CharacterScripts>().BOTW)
            {
                collision.gameObject.GetComponent<CharacterScripts>().health -= 3;
                collision.gameObject.GetComponent<CharacterScripts>().anim.SetTrigger("Hit");
            }
            else
            {
                AudioManager.Instance.Play("Parry");
            }
            Destroy(this.gameObject);
        }
    }
}
