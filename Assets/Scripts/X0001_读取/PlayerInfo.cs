using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
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
        //目的是 如果可读可写中 从来没有存储过 是不存在这个文件的
        //读取时 就先从默认文件中读取
        string path = Application.persistentDataPath + "/" + filename + ".xml";
        if (!File.Exists(path))
        {
            path = Application.streamingAssetsPath + "/PlayerInfo.xml";
        }


        //加载xml文件信息
        XmlDocument xml = new XmlDocument();
        //加载
        xml.Load(path);

        //从文件中加载具体的数据
        //加载根节点 去加载具体信息
        XmlNode playerInfo = xml.SelectSingleNode("PlayerInfo");
        //加载属性
        this.name = playerInfo.SelectSingleNode("name").InnerText;
        this.atk = int.Parse(playerInfo.SelectSingleNode("atk").InnerText);
        this.def = int.Parse(playerInfo.SelectSingleNode("def").InnerText);
        this.moveSpeed = float.Parse(playerInfo.SelectSingleNode("moveSpeed").InnerText);
        this.roundSpeed = float.Parse(playerInfo.SelectSingleNode("roundSpeed").InnerText);

        XmlNode weaponNode = playerInfo.SelectSingleNode("weapon");
        this.weapon = new Item();
        this.weapon.id = int.Parse(weaponNode.SelectSingleNode("id").InnerText);
        this.weapon.num = int.Parse(weaponNode.SelectSingleNode("num").InnerText);

        XmlNode listNode = playerInfo.SelectSingleNode("listInt");
        XmlNodeList intInlistNode = listNode.SelectNodes("int");
        this.listInt = new List<int>();
        for (int i = 0; i < intInlistNode.Count; i++)
        {
            this.listInt.Add(int.Parse(intInlistNode[i].InnerText));
        }

        XmlNode itemlistNode = playerInfo.SelectSingleNode("itemList");
        XmlNodeList itemInlistNode = itemlistNode.SelectNodes("Item");
        this.itemList = new List<Item>();
        for (int i = 0; i < itemInlistNode.Count; i++)
        {
            Item item = new Item();
            item.id = int.Parse(itemInlistNode[i].Attributes["id"].Value);
            item.num = int.Parse(itemInlistNode[i].Attributes["num"].Value);
            this.itemList.Add(item);
        }

        XmlNode itemDicNode = playerInfo.SelectSingleNode("itemDic");
        XmlNodeList intInDIcNode = itemDicNode.SelectNodes("int");
        XmlNodeList itemInDicNode = itemDicNode.SelectNodes("Item");
        this.itemDic = new Dictionary<int, Item>();

        for (int  i = 0;  i < intInDIcNode.Count;  i++)
        {
            int key = int.Parse(intInDIcNode[i].InnerText);
            Item value = new Item();
            value.id = int.Parse(itemInDicNode[i].Attributes["id"].Value);
            value.num = int.Parse(itemInDicNode[i].Attributes["num"].Value);
            this.itemDic.Add(key, value);
        }

    }

    public void SaveData(string filename)
    {
        //创建路径
        string path = Application.persistentDataPath + "/" + filename + ".xml";

        //创建xml文档
        XmlDocument xml = new XmlDocument();

        //创建xml版本信息和编码方式
        XmlDeclaration xmlDec = xml.CreateXmlDeclaration("1.0", "utf-8", null);
        xml.AppendChild(xmlDec);

        //创建根节点
        XmlElement playerInfo = xml.CreateElement("PlayerInfo");
        xml.AppendChild(playerInfo);

        //添加子节点
        XmlElement name = xml.CreateElement("name");
        name.InnerText = this.name;
        playerInfo.AppendChild(name);

        XmlElement atk = xml.CreateElement("atk");
        atk.InnerText = this.atk.ToString();
        playerInfo.AppendChild(atk);

        XmlElement def = xml.CreateElement("def");
        def.InnerText = this.def.ToString();
        playerInfo.AppendChild(def);

        XmlElement moveSpeed = xml.CreateElement("moveSpeed");
        moveSpeed.InnerText = this.moveSpeed.ToString();
        playerInfo.AppendChild(moveSpeed);

        XmlElement roundSpeed = xml.CreateElement("roundSpeed");
        roundSpeed.InnerText = this.roundSpeed.ToString();
        playerInfo.AppendChild(roundSpeed);

        //***************************

        XmlElement weapon = xml.CreateElement("weapon");
        //添加id
        XmlElement weaponId = xml.CreateElement("id");
        weaponId.InnerText = this.weapon.id.ToString();
        weapon.AppendChild(weaponId);
        //添加num
        XmlElement weaponNum = xml.CreateElement("num");
        weaponId.InnerText = this.weapon.num.ToString();
        weapon.AppendChild(weaponNum);
        playerInfo.AppendChild(weapon);

        //***************************

        XmlElement listInt = xml.CreateElement("listInt");
        for (int i = 0; i < this.listInt.Count; i++)
        {
            XmlElement intListInt = xml.CreateElement("int");
            intListInt.InnerText = this.listInt[i].ToString();
            listInt.AppendChild(intListInt);
        }
        playerInfo.AppendChild(listInt);

        //***************************

        XmlElement itemList = xml.CreateElement("itemList");
        for (int i = 0; i < this.itemList.Count; i++)
        {
            XmlElement itemInItemList = xml.CreateElement("Item");
            itemInItemList.SetAttribute("id", this.itemList[i].id.ToString());
            itemInItemList.SetAttribute("num", this.itemList[i].num.ToString());
            itemList.AppendChild(itemInItemList);
        }
        playerInfo.AppendChild(itemList);

        //***************************

        XmlElement itemDic = xml.CreateElement("itemDic");
        foreach (KeyValuePair<int, Item> pair in this.itemDic)
        {
            //添加int
            XmlElement keyInitemDic = xml.CreateElement("int");
            keyInitemDic.InnerText = pair.Key.ToString();
            itemDic.AppendChild(keyInitemDic);
            //添加Item
            XmlElement valueInitemDic = xml.CreateElement("Item");
            valueInitemDic.SetAttribute("id", pair.Value.id.ToString());
            valueInitemDic.SetAttribute("num", pair.Value.num.ToString());
            itemDic.AppendChild(valueInitemDic);
        }
        playerInfo.AppendChild(itemDic);

        //保存
        xml.Save(path);
    }
}

