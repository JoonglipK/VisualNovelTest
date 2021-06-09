using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{

    DialogueSystem dialoguetest;

    // Start is called before the first frame update
    void Start()
    {
        dialoguetest = DialogueSystem.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialoguetest.isSpeaking || dialoguetest.isWaitingForUserInput)
            {
                if (index >= s.Length)
                {
                    return;
                }
                Say(s[index]);
                index++;
            }
        }
    }

    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";
    }

    public string[] s = new string[]
    {
        "저기, 계세요?:진보라",
        "문 너머로 뚜렷하고 분명한 목소리가 들려왔다.",
        "어디선가 들어본 듯 한 익숙한 목소리에 별 의심없이 문고리로 손을 뻗었다.",
        "누구세요?:나",
        "문을 열자 보이는 여자의 모습.",
        "눈앞에 검푸른 긴 생머리를 휘날리는 여자가 서있었다.",
        "은은하게 빛나는 청회색 눈동자가 너무나도 아름다웠다.",


    };
    int index = 0;
}
 