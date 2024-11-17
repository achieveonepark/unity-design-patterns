using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
}

public readonly struct AttackCommand : ICommand
{
    private readonly Player _player;
    private readonly Transform _target;

    public AttackCommand(Player player, Transform target)
    {
        _player = player;
        _target = target;
    }
    
    public void Execute()
    {
        _player.Attack(_target);
    }
}

public readonly struct JumpCommand : ICommand
{
    private readonly Player _player;

    public JumpCommand(Player player)
    {
        _player = player;
    }
    
    public void Execute()
    {
        _player.Jump();
    }
}

public class MultiAttackCommand : ICommand
{
    private readonly Player _player;
    private readonly List<Transform> _monsterTargets;

    public MultiAttackCommand(Player player, List<Transform> monsterTargets)
    {
        _player = player;
        _monsterTargets = monsterTargets;
    }
    
    public void Execute()
    {
        foreach (var monster in _monsterTargets)
        {
            _player.Attack(monster);
        }
    }
}