using Godot;
using System;
using System.ComponentModel;

public partial class Walk : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 100;
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

	public override void _Process(double delta)
    {
        _animatedSprite.Play("default");
    }


	// Called when the node enters the scene tree for the first time.
	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * Speed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
