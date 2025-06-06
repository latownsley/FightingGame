using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class MainMenu : Control
{
    [Export]
    AudioStreamPlayer buttonSFX;
    

    //Holds indexes of menus
    List<int> goBacklist = new();
    private Game gameController;

    public override void _Ready()
    {
        base._Ready();

        // set up gameController
        if (GetParent().GetParent() is Game)
        {
            gameController = GetParent().GetParent() as Game;
        }
    }

    // function to go to other menus
    public void SwapMenu(int menuIndex, int returnIndex)
    {
        if (GetChild(menuIndex) is MenuTab menuTab)
        {
            menuTab.Visible = true;
        }

        if (returnIndex < 0) return;
        goBacklist.Add(returnIndex);
    }

    // function go back to previous menu
    public void SwapMenuToPrevious()
    {
        if (!goBacklist.Any()) return;
        SwapMenu(goBacklist[goBacklist.Count - 1], -1);
        goBacklist.RemoveAt(goBacklist.Count - 1);
    }

    // function to load a scene (function to load in game)
    // public void OnSwapScene(PackedScene loadScene){
    //     GetTree().Root.AddChild(loadScene.Instantiate());
    //     QueueFree();
    // }

    public void OnSwapScene(PackedScene loadScene)
    {
        gameController.SceneChange(loadScene);
    }

    // function to quit game
    public void OnQuitGameBtnPressed()
    {
        // button sfx
        buttonSFX.Play();

        // quit functionality
        GetTree().Quit();
    }
}
