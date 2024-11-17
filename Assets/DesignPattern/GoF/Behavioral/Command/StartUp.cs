using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class StartUp : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InputHandler _handler;
    [SerializeField] private Transform[] _monsters;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_monsters.Length == 0)
            {
                return;
            }
            
            if (_monsters.Length == 1)
            {
                var attackCommand = new AttackCommand(_player, _monsters[0]);
                _handler.SetCommand(attackCommand);    
            }
            else
            {
                var multiAttackCommand = new MultiAttackCommand(_player, _monsters.ToList());
                _handler.SetCommand(multiAttackCommand);    
            }
            
            _handler.ExecuteCommand();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            var jumpCommand = new JumpCommand(_player);
            _handler.SetCommand(jumpCommand);
            _handler.ExecuteCommand();
        }
    }
}