using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTestNew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(Application.persistentDataPath);
        print(Application.streamingAssetsPath);

        PlayerInfo p = new PlayerInfo();
        p.LoadData("PlayerInfo");

        p.name = "超市里的马";
        p.listInt.Add(2);
        p.itemList.Add(new Item() { id = 1, num = 2 });
        p.itemDic.Add(22, new Item() { id = 2, num = 3 });

        p.SaveData("PlayerInfo1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
