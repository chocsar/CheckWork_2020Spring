using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject getEffect;
    public Text firstMission;
    public Text nextMission;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (firstMission.text != "ミッション 1：コインをゲットせよ！") //Player側でOnTriggerEnterを作成してない場合、反応しないようにする
            {
                GameObject effect = Instantiate(getEffect, transform.position, Quaternion.identity) as GameObject;
                Destroy(effect, 2);

                nextMission.gameObject.SetActive(true);

                Destroy(gameObject);
            }
        }

    }

}
