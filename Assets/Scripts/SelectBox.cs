using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBox : MonoBehaviour
{

    private SpriteRenderer sprite;
    private bool isAlphaUp;
    
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
   
    private void OnEnable()
    {
        isAlphaUp = true;
        sprite.color = new Color(255, 255, 255, 0);
        StartCoroutine("Blinking");
    }

    private IEnumerator Blinking()
    {
        while (true)
        {
            if (isAlphaUp)
            {
                sprite.color = new Color(1, 1, 1, sprite.color.a + 0.02f);
                if(sprite.color.a >= 1)
                {
                    sprite.color = new Color(1, 1, 1, 1);
                    isAlphaUp = false;
                }
            }
            else
            {
                sprite.color = new Color(1, 1, 1, sprite.color.a - 0.02f);
                if(sprite.color.a <= 0)
                {
                    sprite.color = new Color(1, 1, 1, 0);
                    isAlphaUp = true;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    
}
