using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//問題3-3
using UnityEngine.UI;


public class Player_Test : MonoBehaviour
{
    //＝＝＝パラメータ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Transform groundCheck;
    bool grounded = false;
    Rigidbody2D rb2D; //問題1-1で使う
    float speed = 15.0f; //問題1-3で使う

    Animator animator; //問題2-1で使う
    float direction = 1.0f; //問題2-3で使う


    //問題3-4：宣言
    public Text mission1Text;

    //問題4-5：宣言
    public Text mission2Text;


    //＝＝＝コード（Monobehavior基本機能の実装）＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    void Start()
    {
        groundCheck = transform.Find("GroundCheck");

        //問題1-1
        rb2D = GetComponent<Rigidbody2D>();

        //問題2-1
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //問題1-2：左右キー入力
        float inputValue = Input.GetAxis("Horizontal");

        //問題1-3：速度の設定
        rb2D.velocity = new Vector2(inputValue * speed, rb2D.velocity.y);

        //問題2-2：アニメーションの設定
        animator.SetFloat("MoveSpeed", Mathf.Abs(inputValue));

        //問題2-3：キャラの方向
        if (inputValue != 0.0f)
        {
            direction = Mathf.Sign(inputValue);
        }
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        


        //地面チェック
        GroundCheck();
        if (grounded) //もし地面だったら
        {
            //問題4-1：スペースキー入力
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //問題4-2：速度の設定
                rb2D.velocity = new Vector2(rb2D.velocity.x, 35);

                //問題4-3：アニメーションの設定
                animator.SetTrigger("Jump");
            }
        }

    }

    //＝＝＝コード（当たり判定）＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //問題3-1
    void OnTriggerEnter2D(Collider2D other)
    {
        //問題3-2
        if(other.tag == "Coin")
        {
            //問題3-5
            mission1Text.text = "ミッション 1：CLEAR!";

        }    

        //問4-4
        if(other.tag == "Treasure")
        {
            //問4-6
            mission2Text.text = "ミッション 2：CLEAR!";
        }
            
    }




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


