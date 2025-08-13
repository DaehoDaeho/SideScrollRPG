using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum QuestState
{
    None = 0,
    Aceepted = 1,
    Completed = 2,
}

public class QuestManager : MonoBehaviour
{
    // ½Ì±ÛÅæ ÆÐÅÏ.
    static public QuestManager Instance;
    QuestState questState = QuestState.None;
    public GameObject QuestUI;
    public TextMeshProUGUI textMessage;
    public Button buttonAccept;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AccepQuest()
    {
        questState = QuestState.Aceepted;
        textMessage.text = "quest!!!!";
        buttonAccept.gameObject.SetActive(false);
        QuestUI.gameObject.SetActive(false);
        Debug.Log("Äù½ºÆ® ¼ö¶ô!!!");
    }

    public void CompleteQuest()
    {
        questState = QuestState.Completed;
        textMessage.text = "Quest Completed!!!";
        QuestUI.gameObject.SetActive(true);
    }
}
