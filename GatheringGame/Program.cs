using System;

namespace GatheringGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // We are tasked with creating a gathering mini-game. Using classes we will create 3 forms of gathering: mining, farming, and fishing. (like a popular MMO)
            // The player charcter (user) will first select what form of gathering they would like to do
            // The user must then select the item they will search for. Each item is specific to a form of gathering
            // So a stone is only available to mining, a corn is only available to farming, and a bass is only available to fishing
            // Make at least 5 items per gathering form to select from
            // Using an interface for gathering, allow the user to gather 1 item per turn, with a chance of failing (null)
            // Allow five attempts, quit gathering on a successful gather, or after 5 unseccessful attempt
            // Because we are using an interface, we will not use any control flow construct when starting the gathering
            // Ex: no 'if miner start mining'
            // Keep track of users inventory and output it when the mini-game is finished (user indicates they wish to quit gathering)
        }
    }
}
