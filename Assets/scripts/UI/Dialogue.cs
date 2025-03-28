using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float speed;
    [SerializeField] private bool useButton;
    [SerializeField] private float initialDelay;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartCoroutine(StartDialogue());
    }


    public void NextLine()
    {
        if (textComponent.text == lines[index])
        {
            NextLineCoroutine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    IEnumerator StartDialogue()
    {
        index = 0;
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(speed);
        }
        if (useButton == false)
        {
            yield return new WaitForSeconds(5);
            NextLine();
        }
    }

    void NextLineCoroutine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (useButton)
            {
                gameObject.SetActive(false);
            }
            else
            {
                index = 0;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

        }
    }
}
