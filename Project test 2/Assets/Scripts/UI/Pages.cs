using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pages{
    int[][] book = new int[400][];
    bool[][] bookAction = new bool[400][];
    public Pages(){
        book[0] = new int[3]{261, 230, 20};
        bookAction[0] = new bool[3]{false, false, true};
        book[1] = new int[2]{142, 343};
        book[2] = new int[3]{327, 59, 236};
        book[19] = new int[2]{288, 96};

    }
    public int getAnswer(int page, int position){
        //Debug.Log(book[page][position-1]);
        return book[page][position-1];
    }

    public bool getKeep(int page, int position){
        //Debug.Log(bookAction[page][position - 1]);
        return bookAction[page][position-1];
    }
}
