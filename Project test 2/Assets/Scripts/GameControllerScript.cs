using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UI.Text;

public class GameControllerScript : MonoBehaviour
{
    public Text scoreText;
    //public string test = "vamo";
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver(){
        SceneManager.LoadScene("FirstScene");
    }

    public void UITest(string test){
        scoreText.text = test;
    }

    public void ListMagics(MagicCore[] magics){
        string text = "";
        for (int i = 0; i < 2; i++){
            text = text + magics[i].name + ": " + magics[i].getNumber().ToString() + "\n";
        }
        scoreText.text = text;
        Debug.Log("test1");
    }

    public void Clean(){
        scoreText.text = " ";
        Debug.Log("test2");
    }
}
