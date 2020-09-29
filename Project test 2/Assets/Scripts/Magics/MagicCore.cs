using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicCore
{
    private int number = 1;
    public string name;

    public int getNumber(){
        return number;
    }

    public void setNumberLess(){
        number -= 1;
    }

    public abstract void Action();

    public abstract string descrition();
}
