using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/DialogController_SO")]
public class DialogController_SO : ScriptableObject
{
    public string[] Messages;

    public string GetRandom()
    {
        return Messages[Random.Range(0, Messages.Length)];
    }
}
