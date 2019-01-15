using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;

public class score : MonoBehaviour
{
    public Text countText;
  private int FinalScore;
  // Start is called before the first frame update
  void Start()
    {
    FinalScore = PlayerController.GetScore();
        countText.text="Count:"+FinalScore.ToString();
  }

    // Update is called once per frame
    void Update()
    {
    print(FinalScore);
  }
}
