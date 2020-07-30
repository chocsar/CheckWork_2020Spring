using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{
    public GameObject getEffect;
    public Sprite openSprite;
    public Text secondMission;
    bool getFlag = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (secondMission.text != "ミッション 2：宝箱をゲットせよ！") //Player側でOnTriggerEnterを作成してない場合、反応しないようにする
            {
                if (!getFlag)
                {
                    getFlag = true; //Stayで連続判定しないようにするためのフラグ

                    GameObject effect = Instantiate(getEffect, transform.position, Quaternion.identity) as GameObject;
                    Destroy(effect, 2);

                    GetComponent<SpriteRenderer>().sprite = openSprite;
                }
            }
        }

    }

}
