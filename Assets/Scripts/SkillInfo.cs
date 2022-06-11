using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    public Text text;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        HideInfo();
    }

    public virtual void ShowInfo(string info)
    {
        image.enabled = true;
        text.enabled = true;
        text.text = info;
    }

    public virtual void HideInfo()
    {
        text.enabled = false;
        image.enabled = false;
    }
}
