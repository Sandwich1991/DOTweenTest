using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CommandManager : MonoBehaviour
{
    [SerializeField] private Text _command;
    
    private void Start()
    {
        JumpTest.JumpAction += PrintCommand;
        UiController.UIAction += PrintCommand;
        MoveTest.MoveAction += PrintCommand;
        MeterialTest.ColorAction += PrintCommand;
        
        PrintCommand("DOTween Simulator");
    }

    void PrintCommand(string command)
    {
        _command.DOText(command, 0.7f);
    }
}
