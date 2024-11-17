using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주요 로직
public abstract class Handler<T>
{
    private Handler<T> _nextHandler;

    public void SetNextHandler(Handler<T> next)
    {
        _nextHandler = next;
    }

    public void Handle(T request)
    {
        if (CanHandle(request))
        {
            Process(request);
            return;
        }

        if (_nextHandler != null)
        {
            _nextHandler.Handle(request);
            return;
        }

        Debug.Log("please enter a handler");
    }

    protected abstract bool CanHandle(T request);
    protected abstract void Process(T request);
}

public class PoisonHandler : Handler<StatusRequest>
{
    private readonly PlayerData _player;

    public PoisonHandler(PlayerData player)
    {
        _player = player;
    }

    protected override bool CanHandle(StatusRequest request)
    {
        return _player.HP > 0;
    }

    protected override void Process(StatusRequest request)
    {
        _player.HP -= request.Damage;
        Debug.Log($"Player damaged... {request.Damage}... Player HP : {_player.HP}");
    }
}

public class PlayerDeadHandler : Handler<StatusRequest>
{
    private readonly PlayerData _player;
    
    public PlayerDeadHandler(PlayerData player)
    {
        _player = player;
    }
    
    protected override bool CanHandle(StatusRequest request)
    {
        return _player.HP <= 0;
    }

    protected override void Process(StatusRequest input)
    {
        Debug.Log("Player Dead...");
        _player.Status = "dead";
    }
}

// Handler에 필요한 Request
public readonly struct StatusRequest
{
    public readonly int Damage;

    public StatusRequest(string status, int damage)
    {
        Damage = damage;
    }
}