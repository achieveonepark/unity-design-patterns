using System.Threading.Tasks;
using UnityEngine;

public class StartUp_ChainOfResponsibility : MonoBehaviour
{
    private async void Start()
    {
        var player = new PlayerData
        {
            Status = "none",
            HP = 100,
        };
        
        var menuHandler = new PoisonHandler(player);
        var gameHandler = new PlayerDeadHandler(player);
        
        menuHandler.SetNextHandler(gameHandler);

        while (player.Status != "dead")
        {
            menuHandler.Handle(new StatusRequest("poison", 10));
            await Task.Delay(1000);
        }
    }
}
