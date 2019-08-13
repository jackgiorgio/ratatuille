using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI; 


public class WWWText : MonoBehaviour {
    string urlPath = "d:/hotfix/XluaText1.lua.txt";  //资源网络路径(根据自己的服务器来写)    
    string file_SaveUrl;//资源保路径    
    FileInfo file;     
    
    void Start()    
    {        
        file_SaveUrl =  Application.persistentDataPath + "/XluaText1.lua.txt";        
        file = new FileInfo(file_SaveUrl);         
        StartCoroutine(DownFile(urlPath));    
        }    
        
    /// <summary>    
    /// 下载文件到对应的地址    
    /// </summary>    
    
    IEnumerator DownFile(string url){
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone){             
            Debug.Log("下载完成");
            byte[] bytes = www.bytes;
            CreatFile(bytes);            //下载完成并创建脚本后调用热更新脚本            
            this.GetComponent<HotFixText>().enabled = true;
        }
    }    
    
    /// <summary>    
    /// 创建文件    
    /// </summary>    
    
    /// <param name="bytes"></param>
    
    void CreatFile(byte[] bytes){
        Stream stream;
        stream = file.Create();
        stream.Write(bytes, 0, bytes.Length);
        stream.Close();
        stream.Dispose();
        Debug.Log("热更新完成");
    }
}