using Godot;
using System;
using System.ComponentModel;

public partial class Walk : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 100;
	private AnimatedSprite2D _animatedSprite;
	

	// Retrieves animated sprites
	public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

	// Handles input 
	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");

		Velocity = inputDirection * Speed;
		
	}

	// Handles movement
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}

	// Handles animation changes between directions
    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
		if (@event.IsActionPressed("up"))
		{
			_animatedSprite.Play("up");
		}
		else if (@event.IsActionPressed("down"))
		{
			_animatedSprite.Play("down");
		}
		else if (@event.IsActionPressed("left"))
		{
			_animatedSprite.Play("left");
		}
		else if (@event.IsActionPressed("right"))
		{
			_animatedSprite.Play("right");
		}
    }
}
