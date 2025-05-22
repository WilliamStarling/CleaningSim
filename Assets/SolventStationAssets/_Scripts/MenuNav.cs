using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class MenuNav : MonoBehaviour
{

    [Header("Components")]
    public int questionNumber = 1;
    public int hintsUsed = 0;
    public string answerTag;
    public GameObject ScoreText;
    public GameObject HintsTracker;
    public GameObject ResultScreenHints;
    public int Score = 100;
    public VideoPlayer videoPlayer;
    public GameObject VideoDoneScreen;

    [Header("Answer Key")]
    public String Q1CorrectAnswer;
    public String Q2CorrectAnswer;
    public String Q3CorrectAnswer;
    public String Q4CorrectAnswer;
    public String Q5CorrectAnswer;

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

    [Header("Hints")]
    public GameObject Hint1;
    public GameObject Hint2;
    public GameObject Hint3;
    public GameObject Hint4;
    public GameObject Hint5;

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

    private bool Hint1used = false;
    private bool Hint2used = false;
    private bool Hint3used = false;
    private bool Hint4used = false;
    private bool Hint5used = false;

    
    private void Start()
    {
        videoPlayer.loopPointReached += videoDone; //Add this so it gets called when the video is done, so we can move on.
    }
    void videoDone(VideoPlayer vp)
    {
        //vp.Stop(); //Stop the video player so it doesn't keep playing.
        videoPlayer.gameObject.SetActive(false); //done with the video so turn it off.
        VideoDoneScreen.SetActive(true); // show the video done screen to decide what to do next.
        questionNumber = 0; //Lowers the question number so that it is 1 when the quiz starts.
    }

    public void setQuestionNumber(int number)
    {
        questionNumber = number;
    }

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
            Hint1.SetActive(false);

        }

        else if (questionNumber == 2)
        {
            answerTag = self.tag;
            Q2Answer = answerTag;
            Hint2.SetActive(false);
        }

        else if (questionNumber == 3)
        {
            answerTag = self.tag;
            Q3Answer = answerTag;
            Hint3.SetActive(false);
        }

        else if (questionNumber == 4)
        {
            answerTag = self.tag;
            Q4Answer = answerTag;
            Hint4.SetActive(false);
        }

        else if (questionNumber == 5)
        {
            answerTag = self.tag;
            Q5Answer = answerTag;
            Hint5.SetActive(false);
            CalculateResults();
            questionNumber = 0;
            answerTag = null;
        }
    }

    public void UseHint()
    {
        if (questionNumber == 1 && Hint1used == false)
        {
            Hint1.SetActive(true);
            Score = Score - 3;
            Hint1used = true;
            hintsUsed++;
            HintsTracker.GetComponent<TMP_Text>().text = hintsUsed.ToString();
            ResultScreenHints.GetComponent<TMP_Text>().text = hintsUsed.ToString();
        }

        else if (questionNumber == 2 && Hint2used == false)
        {
            Hint2.SetActive(true);
            Score = Score - 3;
            Hint2used = true;
            hintsUsed++;
            HintsTracker.GetComponent<TMP_Text>().text = hintsUsed.ToString();
            ResultScreenHints.GetComponent<TMP_Text>().text = hintsUsed.ToString();
        }

        else if (questionNumber == 3 && Hint3used == false)
        {
            Hint3.SetActive(true);
            Score = Score - 3;
            Hint3used = true;
            hintsUsed++;
            HintsTracker.GetComponent<TMP_Text>().text = hintsUsed.ToString();
            ResultScreenHints.GetComponent<TMP_Text>().text = hintsUsed.ToString();
        }

        else if (questionNumber == 4 && Hint4used == false)
        {
            Hint4.SetActive(true);
            Score = Score - 3;
            Hint4used = true;
            hintsUsed++;
            HintsTracker.GetComponent<TMP_Text>().text = hintsUsed.ToString();
            ResultScreenHints.GetComponent<TMP_Text>().text = hintsUsed.ToString();
        }

        else if (questionNumber == 5 && Hint5used == false)
        {
            Hint5.SetActive(true);
            Score = Score - 3;
            Hint5used = true;
            hintsUsed++;
            HintsTracker.GetComponent<TMP_Text>().text = hintsUsed.ToString();
            ResultScreenHints.GetComponent<TMP_Text>().text = hintsUsed.ToString();
        }
    }

    public void LabelsToggleOn()
    {
        Score = Score - 3;
        hintsUsed++;
        HintsTracker.GetComponent<TMP_Text>().text = hintsUsed.ToString();
        ResultScreenHints.GetComponent<TMP_Text>().text = hintsUsed.ToString();
    }

    void CalculateResults()
    {
        Answer1.GetComponent<TMP_Text>().text = Q1Answer;
        if (Q1Answer == Q1CorrectAnswer) Answer1.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer1.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        Answer2.GetComponent<TMP_Text>().text = Q2Answer;
        if (Q2Answer == Q2CorrectAnswer) Answer2.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer2.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        Answer3.GetComponent<TMP_Text>().text = Q3Answer;
        if (Q3Answer == Q3CorrectAnswer) Answer3.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer3.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }
        Answer4.GetComponent<TMP_Text>().text = Q4Answer;
        if (Q4Answer == Q4CorrectAnswer) Answer4.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer4.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        Answer5.GetComponent<TMP_Text>().text = Q5Answer;
        if (Q5Answer == Q5CorrectAnswer) Answer5.GetComponent<TMP_Text>().color = Color.green;
        else
        {
            Answer5.GetComponent<TMP_Text>().color = Color.red;
            Score = Score - 20;
        }

        Score = Mathf.Max(0, Score); // added to hopefully fix the negative score issue

        ScoreText.GetComponent<TMP_Text>().text = Score.ToString() + "%";
        if (Score >= 70) ScoreText.GetComponent<TMP_Text>().color = Color.green;
        else ScoreText.GetComponent<TMP_Text>().color = Color.red;
    }

    public void RetakeQuiz()
    {
        // resets score and question numbers
        Score = 100;
        questionNumber = 0;
        hintsUsed = 0;

        // resets answers
        Q1Answer = "";
        Q2Answer = "";
        Q3Answer = "";
        Q4Answer = "";
        Q5Answer = "";

        // resets hints used
        Hint1used = false;
        Hint2used = false;
        Hint3used = false;
        Hint4used = false;
        Hint5used = false;

        // hides hints
        Hint1.SetActive(false);
        Hint2.SetActive(false);
        Hint3.SetActive(false);
        Hint4.SetActive(false);
        Hint5.SetActive(false);

        // resets UI / colors
        Answer1.GetComponent<TMP_Text>().text = "";
        Answer1.GetComponent<TMP_Text>().color = Color.white;
        Answer2.GetComponent<TMP_Text>().text = "";
        Answer2.GetComponent<TMP_Text>().color = Color.white;
        Answer3.GetComponent<TMP_Text>().text = "";
        Answer3.GetComponent<TMP_Text>().color = Color.white;
        Answer4.GetComponent<TMP_Text>().text = "";
        Answer4.GetComponent<TMP_Text>().color = Color.white;
        Answer5.GetComponent<TMP_Text>().text = "";
        Answer5.GetComponent<TMP_Text>().color = Color.white;

        // reset score and hin tracker
        ScoreText.GetComponent<TMP_Text>().text = Score.ToString() + "%";
        ScoreText.GetComponent<TMP_Text>().color = Color.white;
        HintsTracker.GetComponent<TMP_Text>().text = hintsUsed.ToString();
        ResultScreenHints.GetComponent<TMP_Text>().text = hintsUsed.ToString();
    }

    public void QuitSimulation()
    {
        // quits the application
        Application.Quit();
    }
}
