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

    
    public void LoadData()
    {
        //加载xml文件信息
        XmlDocument xml = new XmlDocument();
        //加载
        xml.Load(Application.dataPath + "/Scripts/PlayerInfo.xml");
    }
}

