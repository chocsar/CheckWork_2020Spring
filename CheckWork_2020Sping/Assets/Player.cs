using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//問題3-3



public class Player : MonoBehaviour
{
    //＝＝＝パラメータ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Transform groundCheck;
    bool grounded = false;
    Rigidbody2D rb2D; //問題1-1で使う
    float speed = 15.0f; //問題1-3で使う

    Animator animator; //問題2-1で使う
    float direction = 1.0f; //問題2-3で使う


    //問題3-4：宣言

    //問題4-5：宣言



    //＝＝＝コード（Monobehavior基本機能の実装）＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    void Start()
    {
        groundCheck = transform.Find("GroundCheck");

        //問題1-1


        //問題2-1
    }

    void Update()
    {
        //問題1-2：左右キー入力


        //問題1-3：速度の設定


        //問題2-2：アニメーションの設定


        //問題2-3：キャラの方向
        


        //地面チェック
        GroundCheck();
        if (grounded) //もし地面だったら
        {
            //問題4-1：スペースキー入力
            
                //問題4-2：速度の設定

                //問題4-3：アニメーションの設定
        }

    }

    //＝＝＝コード（当たり判定）＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //問題3-1
  
        //問題3-2
        
            //問題3-5
            

        //問4-4
        
            //問4-6
            








    //＝＝＝コード（サポート関数）＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    void GroundCheck()
    {
        //フラグの初期化
        grounded = false;

        //GroundCheckの位置にあるコライダーを全て取得
        Collider2D[] groundCheckCollider = Physics2D.OverlapPointAll(groundCheck.position);

        //コライダーを全てチェックしていく
        foreach (Collider2D checkCollider in groundCheckCollider)
        {
            if (checkCollider != null)
            {
                if (!checkCollider.isTrigger)
                {
                    grounded = true;
                }
            }
        }
    }
}


