using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;


public class Item
{
    public int id;
    public int num;
}

public class PlayerInfo
{
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public float roundSpeed;
    public Item weapon;
    public List<int> listInt;
    public List<Item> itemList;
    public Dictionary<int, Item> itemDic;

    
    public void LoadData(string filename)
    {
        //加载xml文件信息
        XmlDocument xml = new XmlDocument();
        //加载
        xml.Load(Application.streamingAssetsPath + "/" + filename + ".xml");

        //从文件中加载具体的数据
        //加载根节点 去加载具体信息
        XmlNode playerInfo = xml.SelectSingleNode("PlayerInfo");
        //加载属性
        this.name = playerInfo.Attributes["name"].Value;
    }
}

