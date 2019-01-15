using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;

public class PlayerController:MonoBehaviour{
    public float speed;
  public static int score=0;
  public float flag=1000f;
    public Text countText;

    private Rigidbody2D rb2d;
    private int count;

    bool jump = false;

    void Start(){
        rb2d =GetComponent<Rigidbody2D>();
        count = 0;
    SetCountText();
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Horizontal");

    Vector2 movement = new Vector2(moveHorizontal,0);
        rb2d.AddForce(movement * speed);

    Vector3 scale = transform.localScale;
    if(x >= 0){
        scale.x = 1;
    }else{
        scale.x = -1;
    }

    transform.localScale = scale;
  }


    void Update(){
        if(Input.GetKeyDown("space") && !jump){
            rb2d.AddForce(Vector2.up*flag);
            jump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count = count + 1;
      score = score + 1;
      SetCountText();
        }else if(other.gameObject.CompareTag("gem")){
      other.gameObject.SetActive(false);
      count = count + 5;
      SetCountText();
    }
        if(other.gameObject.CompareTag("next1") && count >= 10){
            SceneManager.LoadScene("Main2");
        }else if(other.gameObject.CompareTag("next2") && count >= 10){
      SceneManager.LoadScene("finish");
    }
  }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("ground")){
            jump = false;
        }else if(other.gameObject.CompareTag("gameover")){
      SceneManager.LoadScene("Main2");
    }
    }

    void SetCountText(){
        countText.text="Count:"+count.ToString(); 
    }

    public static int GetScore(){
    return score;
  }
    
} 