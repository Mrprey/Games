using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float heart; //energia ou vida
    public float ability; //Habilidade
    public int numSpells = 12; //quantidade de feitiços
    public int luck;
    public float speedMove = 3f;
    public int gold;
    public MagicCore[] magics = new MagicCore[2];
    public Rigidbody2D playerRb;
    public GameControllerScript gameController;



    private Vector2 direction;
    private DiceScript dice = new DiceScript();
    private bool keyQ = false;
    // Start is called before the first frame update
    void Start()
    {
        StartStatus();
        magics[0] = new CreatureCopyScript();
        magics[1] = new GoldFools();
    }

    // Update is called once per frame
    void Update()
    {
        direction.y = Input.GetAxisRaw("Vertical");
        direction.x = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = direction*speedMove;

        //gameController.UITest(magics[1].name + magics[1].getNumber().ToString());

        if (Input.GetKeyDown(KeyCode.Q)){
            if (keyQ == false){
                gameController.ListMagics(magics);
                keyQ = true;
            }
            else{
                gameController.Clean();
                keyQ = false;}
        }

        if (heart <= 0){
            gameController.GameOver();
        }
    }

    void StartStatus(){
        heart = 12 + dice.D6() + dice.D6();
        ability = 6 + dice.D6();
        luck = 6 + dice.D6();
        //numSpells = dice.D6() + dice.D6() + 6;
    }


}
