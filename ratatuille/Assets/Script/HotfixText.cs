
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XLua;

public class HotFixText : MonoBehaviour
{
    LuaEnv m_kLuaEnv;

    public GameObject gamepanel;
    public GameObject Downpanel;

    void Start()
    {
        //代码热更步骤
        m_kLuaEnv = new LuaEnv(); //该变量最好保证全局就此一个

        //查找指定路径下lua热更文件
        string path = Application.persistentDataPath + "/XluaText1.lua.txt";
        //用协程序下载读取文件内容
        StartCoroutine(DownloadFile(path));
    }

    public IEnumerator DownloadFile(string path)
    {
        WWW www = new WWW(path);
        yield return www;
        if (www.isDone)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(path, Encoding.UTF8);
            if (sr != null)
            {
                //执行该Lua脚本中的语句
                m_kLuaEnv.DoString(sr.ReadToEnd());
            }
        }
        gamepanel.SetActive(true);
        Downpanel.SetActive(false);
    }
}