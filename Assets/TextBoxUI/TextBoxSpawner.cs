using System.Collections;
using UnityEngine;

public class TextBoxSpawner : MonoBehaviour
{
    public TextBoxUI prefab;

    private TextBoxUI temp = null;

    public TextBoxUI SpawnAndGetTextBox()
    {
        if(temp != null)
        {
            temp.Delete();
        }

        temp =  WorldCanvasController.Instance.InstantiateToWorldCanvas(prefab.gameObject, transform.position).GetComponent<TextBoxUI>();
        return temp;
    }

    public void SpawnTextBox()
    {
        if (temp != null)
        {
            temp.Delete();
        }

        temp = WorldCanvasController.Instance.InstantiateToWorldCanvas(prefab.gameObject, transform.position).GetComponent<TextBoxUI>();
    }

    private void Update()
    {
        if(temp != null)
        {
            temp.transform.position = transform.position;
        }
    }

    public void RemoveTextBox()
    {
        if(temp != null)
            temp.FadeOut();
    }


}
