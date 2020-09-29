using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFools : MagicCore
{
    public PlayerScript player;


    public GoldFools(){
        this.name = "Ouro dos tolos";
    }
    
    public override void Action()
    {   
        setNumberLess();
       // player.gold += 10;
    }


    public override string descrition(){
        return "Este encanto transformará pedra comum em uma pilha do que parece ser ouro.\n Contudo, o encanto é apenas uma forma de encanto da ilusão - embora mais confiável do que o Encanto da ilusão - e a pilha de ouro logo voltará a ser pedra.";
    }
}
