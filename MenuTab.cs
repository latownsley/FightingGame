using Godot;
using System;

public partial class MenuTab : PanelContainer
{
	[Export]
    AudioStreamPlayer buttonSFX;
	private MainMenu mainMenu;

	public override void _Ready()
	{
		if(GetParent() is MainMenu){
			mainMenu = GetParent() as MainMenu;
		}
	}

	public void OnMenuSwapButtonPressed(int swapIndex){
		mainMenu.SwapMenu(swapIndex, GetIndex());       //GetIndex() is where you are compared to other children in scene
		Visible = false;                                // hide current menu
	}

	public void OnMenuReturnButtonPressed()
	{
		mainMenu.SwapMenuToPrevious();
		Visible = false;
		
		// button sfx
        buttonSFX.Play();
	}

	public void LoadSceneRequest(PackedScene loadScene){
		mainMenu.OnSwapScene(loadScene);
	}
}
