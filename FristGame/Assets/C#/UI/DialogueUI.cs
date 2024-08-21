using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;

    private List<string> contentList;
    private int contentIndex = 0;
    private Action OnDialogueEnd;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nameText = transform.Find("NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Show(string name,string[] content,Action OnDiagoueEnd=null)
    {
        nameText.text = name;
        contentList = new List<string>(); 
        contentList.AddRange(content);
        contentIndex = 0;
        contentText.text = contentList[0];
        gameObject.SetActive(true);
        this.OnDialogueEnd = OnDiagoueEnd;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnContinueButtonClick()
    {
        contentIndex++;
        
        if (contentIndex >= contentList.Count)
        {
            OnDialogueEnd?.Invoke();
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
    }


}
