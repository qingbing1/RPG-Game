using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiddleAnswer : MonoBehaviour
{
    public int Num = 6;
    public GameObject Maincamera;
    public GameObject Manager;
    public GameObject Win;
    public GameObject Die;
    public GameObject Life01, Life02, Life03;
    private int life = 3;
    public GameObject AudioMain, AudioFight;

    //读取文档
    string[][] ArrayX;//题目数据
    string[] lineArray;//读取到题目数据
    private int topicMax = 0;//最大题数
    private List<bool> isAnserList = new List<bool>();//存放是否答过题的状态

    //加载题目
    
    public List<Toggle> toggleList;//答题Toggle
    public TextMeshProUGUI TM_Text;//当前题目
    //public Text indexText;//当前第几题
    public List<TextMeshProUGUI> DA_TextList;//选项
    private int topicIndex = 0;//第几题


    private List<int> randomNum = new List<int>();

    void Awake()
    {
        TextCsv();
        LoadAnswer();
    }

    void Start()
    {
        toggleList[0].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,0));
        toggleList[1].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,1));
        toggleList[2].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,2));
        toggleList[3].onValueChanged.AddListener((isOn) => AnswerRightRrongJudgment(isOn,3));

    }


    /*****************读取txt数据******************/
    void TextCsv()
    {
        //读取csv二进制文件  
        TextAsset binAsset = Resources.Load("Title Middle", typeof(TextAsset)) as TextAsset;
        //读取每一行的内容  
        lineArray = binAsset.text.Split('\r');
        //创建二维数组  
        ArrayX = new string[lineArray.Length][];
        //把csv中的数据储存在二维数组中  
        for (int i = 0; i < lineArray.Length; i++)
        {
            ArrayX[i] = lineArray[i].Split(':');
        }
        //设置题目状态
        topicMax = lineArray.Length;
        for (int x = 0; x < topicMax + 1; x++)
        {
            isAnserList.Add(false);
        }
    }

    /*****************加载题目******************/
    void LoadAnswer()
    {
        for (int i = 0; i < toggleList.Count; i++)
        {
            toggleList[i].isOn = false;
        }
        for (int i = 0; i < toggleList.Count; i++)
        {
            toggleList[i].interactable = true;
        }
        GetRandomNum();//获取随机数  
        //indexText.text = "第" + (topicIndex + 1) + "题：";//第几题
        TM_Text.text = ArrayX[randomNum[topicIndex]][1];//题目
        int idx = ArrayX[randomNum[topicIndex]].Length - 3;//有几个选项
        for (int x = 0; x < idx; x++)
        {
            DA_TextList[x].text = ArrayX[randomNum[topicIndex]][x + 2];//选项
        }
    }

    /*****************题目对错判断******************/
    void AnswerRightRrongJudgment(bool check,int index)
    {
        if (check)
        {
            //判断题目对错
            int idx = ArrayX[randomNum[topicIndex]].Length - 1;
            int n = int.Parse(ArrayX[randomNum[topicIndex]][idx]) - 1;
            if (n == index)
            {
                Debug.Log("对");
                topicIndex++;
                TextCsv();
                LoadAnswer();
                Number();
                Audio();
                Maincamera.SetActive(true);
                Manager.SetActive(false);
            }
            else
            {
                Debug.Log("错");
                topicIndex++;
                TextCsv();
                LoadAnswer();
                Life();
                Number();
                Audio();
                Maincamera.SetActive(true);
                Manager.SetActive(false);
            }

        }
    }
    void GetRandomNum()
    {
        HashSet<int> nums = new HashSet<int>();
        System.Random r = new System.Random();
        while (nums.Count != topicMax)
        {
            nums.Add(r.Next(0, topicMax));
        }
        foreach(var item in nums)
        {
            randomNum.Add(item);
        }
    }

    void Life() {
        life--;
        if (life == 3)
        {
            Life01.SetActive(true);
            Life02.SetActive(true);
            Life03.SetActive(true);
        }
        if (life == 2)
        {
            Life01.SetActive(true);
            Life02.SetActive(true);
            Life03.SetActive(false);
        }
        if (life == 1)
        {
            Life01.SetActive(true);
            Life02.SetActive(false);
            Life03.SetActive(false);
        }
        if (life == 0)
        {
            Die.SetActive(true);    
        }
    }
   
    void Number()
    {
        Num--;
        if (Num == 0 && life > 0)
        {
            Win.SetActive(true);
        }
        Debug.Log(Num);
    }

    void Audio()
    {
        AudioMain.SetActive(true);
        AudioFight.SetActive(false);
    }
}