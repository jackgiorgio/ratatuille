using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class XluaText : MonoBehaviour
{
    public Text EditionText;//显示版本
    public Text Operator;//运算符
    public Text Anser;//结果
    public InputField input1;//第一个数据
    public InputField input2;//第二个数据

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Debug.LogError("第一个版本初始化");
    }

    public void Add()
    {
        int num = int.Parse(input1.text) + int.Parse(input2.text);
        Anser.text = num.ToString();
    }

}