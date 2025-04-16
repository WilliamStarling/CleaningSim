using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNav : MonoBehaviour
{

    [Header("Components")]
    public int questionNumber = 1;
    public string answerTag;
    public GameObject Debug;

    [Header("Question 1")]
    public GameObject ButtonTrue1;
    public GameObject ButtonFalse1;

    [Header("Question 2")]
    public GameObject ButtonA2;
    public GameObject ButtonB2;
    public GameObject ButtonC2;
    public GameObject ButtonD2;

    [Header("Question 3")]
    public GameObject ButtonA3;
    public GameObject ButtonB3;
    public GameObject ButtonC3;
    public GameObject ButtonD3;
    public GameObject ButtonE;

    [Header("Question 4")]
    public GameObject ButtonA4;
    public GameObject ButtonB4;
    public GameObject ButtonC4;
    public GameObject ButtonD4;

    [Header("Question 5")]
    public GameObject ButtonTrue5;
    public GameObject ButtonFalse5;

    private string Q1Answer;
    private string Q2Answer;
    private string Q3Answer;
    private string Q4Answer;
    private string Q5Answer;

    public void OpensScreen(GameObject next)
    {
        Answer();
        next.SetActive(true);
        questionNumber++;
    }

    public void CloseScreen(GameObject self)
    {
        self.SetActive(false);
    }

    public void Answer()
    {
        if (questionNumber == 1)
        {
            answerTag = this.tag;
            Q1Answer = answerTag;
        }
        
        else if (questionNumber == 2)
        {

        }
        
        else if (questionNumber == 3)
        {

        }
        
        else if (questionNumber == 4)
        {

        }
        
        else if (questionNumber == 5)
        {

        }

        else
        {

        }
    }
}
