using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatScript : MonoBehaviour
{
    public Text Chat5;
    public Text Chat4;
    public Text Chat3;
    public Text Chat2;
    public Text Chat1;

    void Start()
    {
        Chat5.text = "";
        Chat4.text = "";
        Chat3.text = "";
        Chat2.text = "";
        Chat1.text = "";
    }

    public IEnumerator AddText(string text, bool buyer, float time)
    {
        yield return new WaitForSeconds(time);
        Chat5.text = Chat4.text;
        Chat5.alignment = (Chat4.alignment == TextAnchor.MiddleLeft) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;

        Chat4.text = Chat3.text;
        Chat4.alignment = (Chat3.alignment == TextAnchor.MiddleLeft) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;

        Chat3.text = Chat2.text;
        Chat3.alignment = (Chat2.alignment == TextAnchor.MiddleLeft) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;

        Chat2.text = Chat1.text;
        Chat2.alignment = (Chat1.alignment == TextAnchor.MiddleLeft) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;

        Chat1.text = text;
        Chat1.alignment = buyer ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;
    }
}
