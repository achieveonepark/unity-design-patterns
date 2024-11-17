using UnityEngine;

// Invoker
public class InputHandler : MonoBehaviour
{
    private ICommand _currentCommand;

    public void SetCommand(ICommand command)
    {
        _currentCommand = command;
    }

    public void ExecuteCommand()
    {
        _currentCommand?.Execute();
    }
}