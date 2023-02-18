using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxUI : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private TMP_Text text;

    public float characterDelay;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private bool letterByLetterMode;

    [SerializeField]
    private bool removeOnTimer;

    [SerializeField]
    private float removeStartTime;

    [SerializeField]
    private float destroyDelay;

    [SerializeField]
    private bool setUpOnStart = true;

    private void Start()
    {
        if (setUpOnStart)
        {
            SetUp();
        }
    }

    public void SetUp()
    {
        StartCoroutine(Text_Co());
    }

    public void SetUp(Sprite sprite, string message)
    {
        if(sprite != null)
        {
            icon.sprite = sprite;
        }
        else
        {
            icon.gameObject.SetActive(false);
        }

        
        text.text = message;

        

        StartCoroutine(Text_Co());
    }

    public void FadeOut()
    {
        animator.SetBool("FadeOut", true);
        Destroy(this.gameObject, destroyDelay);
    }

    private IEnumerator Text_Co()
    {
        if (!letterByLetterMode)
        {
            text.maxVisibleCharacters = 0;

            int curentCharacters = 0;

            while (curentCharacters <= text.text.Length)
            {
                text.maxVisibleCharacters = curentCharacters;
                curentCharacters++;
                yield return new WaitForSeconds(characterDelay);
            }

            
        }
        else
        {
            int curentCharacters = 0;

            string savedText = text.text;
            text.text = "";

            while (curentCharacters < savedText.Length)
            {
                text.text += savedText[curentCharacters];
                curentCharacters++;
                yield return new WaitForSeconds(characterDelay);
            }
        }

        if (removeOnTimer)
        {
            yield return new WaitForSeconds(removeStartTime);

            FadeOut();
        }

    }
}
