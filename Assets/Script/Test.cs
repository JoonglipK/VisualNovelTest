using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea(5,10)]
    public string dialogue;
    public string name;
    public Sprite cg;
}
public class Test : MonoBehaviour
{

    //[SerializeField] private SpriteRenderer
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text txt_Name;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private SpriteRenderer sprite_NameBox;
    [SerializeField] private SpriteRenderer sprite_StandingCG;

    private bool isDialogue = true;
    private int count = 0;


    [SerializeField] private Dialogue[] dialogue;

    public void ShowDialogue()
    {
        OnOff(true);

        count = 0;
        NextDialouge(); 
    }

    public void NextDialouge()
    {
        if (dialogue[count].name == "")
        {
            sprite_NameBox.gameObject.SetActive(false);
        }

        else if(dialogue[count].name != "")
        {
            sprite_NameBox.gameObject.SetActive(true);
        }

        txt_Dialogue.text = dialogue[count].dialogue;
        txt_Name.text = dialogue[count].name;
        sprite_StandingCG.sprite = dialogue[count].cg;
        count++;

        StopAllCoroutines();
        StartCoroutine(Type(txt_Dialogue.text));
    }

    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_NameBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        txt_Name.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    IEnumerator Type(string narration)
    {

        int a = 0;
        string writerText = "";

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            txt_Dialogue.text = writerText;
            yield return new WaitForSeconds(0.05f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogue == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                    NextDialouge();
                else
                    OnOff(false);
            }
        }
    }
}
