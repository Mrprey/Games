using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : CoreEnemyScript{

    // Start is called before the first frame update
    public DiceScript dice = new DiceScript();
    //public PlayerScript player1;


    void Start(){
       // Destroy(gameObject);
    }

    // Update is called once per frame
    void Update(){
        
    }
    public override void Action(){
        SpeechScript();
        playerS.heart -= 1;
    }

    public override void SpeechScript(){
        dialog.Dialogo();
    }
}
