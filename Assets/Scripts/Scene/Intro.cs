using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class Intro : MonoBehaviour
{
    public enum IntroStep
    {
        Logo,
        MouseTracker,
        ClickMultipleTimes,
        CountDown,
        NextScene
    }

    [SerializeField] private Canvas canvas;

    private static IntroStep _step = IntroStep.Logo;
    private static bool isPlaying = false;

    private void Update()
    {
        print($"isPlaying? : {isPlaying}  Step : {_step}");

        if (isPlaying)
        {
            return;
        }

        switch (_step)
        {
            case IntroStep.Logo:
                LoadStep("Logo", canvas.transform);
                break;
            case IntroStep.MouseTracker:
                LoadStep("MouseTracker", canvas.transform);
                break;
            case IntroStep.ClickMultipleTimes:
                LoadStep("ClickMultipleTimes", canvas.transform);
                break;
            case IntroStep.CountDown:
                LoadStep("CountDown");
                break;
            case IntroStep.NextScene:
                NextScene();
                break;
        }
    }

    public static void StepStart()
    {
        isPlaying = true;
    }

    public static void StepEnd()
    {
        isPlaying = false;
        _step += 1;
    }

    void LoadStep(string prefabPath, Transform parent = null)
    {
        Resource.Instantiate(prefabPath, parent);
    }

    void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
