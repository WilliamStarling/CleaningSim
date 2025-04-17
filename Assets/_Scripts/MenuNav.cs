using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuNav : MonoBehaviour
{

    [Header("Components")]
    public int questionNumber = 1;
    public string answerTag;
    public GameObject ScoreText;
    public int Score = 100;

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

    [Header("Answers")]
    public GameObject Answer1;
    public GameObject Answer2;
    public GameObject Answer3;
    public GameObject Answer4;
    public GameObject Answer5;

    private string Q1Answer;
    private string Q2Answer;
    private string Q3Answer;
    private string Q4Answer;
    private string Q5Answer;

    public void OpensScreen(GameObject next)
    {
        
        next.SetActive(true);
        questionNumber++;
    }

    public void CloseScreen(GameObject self)
    {
        self.SetActive(false);
    }

    public void Answer(GameObject self)
    {
        if (questionNumber == 1)
        {
            answerTag = self.tag;
            Q1Answer = answerTag;
        }

        else if (questionNumber == 2)
        {
            answerTag = self.tag;
            Q2Answer = answerTag;
        }

        else if (questionNumber == 3)
        {
            answerTag = self.tag;
            Q3Answer = answerTag;
        }

        else if (questionNumber == 4)
        {
            answerTag = self.tag;
            Q4Answer = answerTag;
        }

        else if (questionNumber == 5)
        {
            answerTag = self.tag;
            Q5Answer = answerTag;
            CalculateResults();
            questionNumber = 0;
            answerTag = null;
        }

        else if (questionNumber == 6)
        {
            
        }
    }

    void CalculateResults()
    {
        Answer1.GetComponent<TMP_Text>().text = Q1Answer;
        if (Q1Answer == "False") Answer1.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer1.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        Answer2.GetComponent<TMP_Text>().text = Q2Answer;
        if (Q2Answer == "B") Answer2.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer2.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        Answer3.GetComponent<TMP_Text>().text = Q3Answer;
        if (Q3Answer == "D") Answer3.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer3.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }
        Answer4.GetComponent<TMP_Text>().text = Q4Answer;
        if (Q4Answer == "C") Answer4.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer4.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        Answer5.GetComponent<TMP_Text>().text = Q5Answer;
        if (Q5Answer == "False") Answer5.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer5.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        ScoreText.GetComponent<TMP_Text>().text = Score.ToString() + "%";
        if (Score >= 70) ScoreText.GetComponent<TMP_Text>().color = Color.green;
        else ScoreText.GetComponent<TMP_Text>().color = Color.red;
    }
}
