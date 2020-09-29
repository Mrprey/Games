using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject panelBox;
    public TextAsset[] fileText;
    public string[] phrase;
    public Text message;
    public Text textButton1;
    public Text textButton2;
    public Text textButton3;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    //public bool ativo;

    public int lenText;
    public int current;
    public int pag = 0;
    private Pages paginas = new Pages();
    private bool inConversation;
    private bool kepp = false;
    // Start is called before the first frame update
    void Start()
    {   
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        //Debug.Log(paginas.getAnswer(1,1));
        phrase = (fileText[pag].text.Split('\n'));

        lenText = phrase.Length; 

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) && panelBox.activeSelf) || inConversation)
        {
            if (current < lenText - 1)
            {
                message.text = phrase[current];
            }

            if (current == lenText - 1)
            {
                question(phrase[current].Split(';'));

            }

            if (panelBox.activeSelf)
            {
                current++;
            }
            inConversation = false;

        }
        if (current > lenText){
            //Debug.Log(kepp);
            if(!kepp){
                kepp = false;
                Desabilitar();
                current = 0;
            }
            else{
                message.text = phrase[0];
                current = 1;
            }
            //inConversation = false;
        }
    }

    void Habilitar(){
        panelBox.SetActive(true);
    }

    void Desabilitar(){
        panelBox.SetActive(false);
    }

    void question(string[] answers){
        message.text = answers[0];
        if(answers.Length == 4){
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            textButton1.text = answers[1];
            textButton2.text = answers[2];
            textButton3.text = answers[3];
        }
        else{
            button1.SetActive(true);
            button2.SetActive(true);
            textButton1.text = answers[1];
            textButton2.text = answers[2];
        }
    }

    public void WhatButton(int button){
        kepp = paginas.getKeep(pag, button);
        pag = paginas.getAnswer(pag, button) -1;
        //kepp = paginas.getKeep(pag, button);
        Debug.Log(kepp);
        Start();
        //inConversation = true;
        Dialogo();
    }

    public void Dialogo(){
        Habilitar();
        inConversation = true;
    }
}
