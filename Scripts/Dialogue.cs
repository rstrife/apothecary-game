using Godot;
using System;

public partial class Dialogue : Area2D
{
	public bool isInside = false;

	private CanvasGroup _dialogueBox;

	public override void _Ready()
    {
    	_dialogueBox = GetNode<CanvasGroup>("/root/Node2D/Camera2D/DialogueBox");
		//var _dialogic = GetNode("/root/Dialogic");
		//_dialogic.Call("start", "TimelineName"); 
    }
	// Called when the node enters the scene tree for the first time.
	public void OnNPCBodyEntered(PhysicsBody2D body)
	{
		GD.Print("*click clack* I'm in.");
		isInside = true;
	}

	public void OnNPCBodyExit(PhysicsBody2D body)
	{
		isInside = false;
		// _dialogueBox.Visible = false;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event.IsActionPressed("interact") && isInside == true) 
		{
			DialogueBox();
		}
		else
		{
			return;
		}	
	}

	public void DialogueBox()
	{
		// GD.Print("HELLO IM A DIALOGUE BOX IN TRAINING! IM TRYING MY BEST BUT THIS IS SOOOO HARRRRWWWDDDDDD!");
		_dialogueBox.Visible = true;
		//_dialogic.Start("NPCTest");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
