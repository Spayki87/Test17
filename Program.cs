using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Бой_с_босом
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHealth = 1000;
            int bossHealth = 1500;

            int bossDamage = 100;
            int hardStrike = 100;
            int tripleStrike = 150;
            int counterAttack = 75;
            int retreatPlayer = 200;
            int berserkState = 200;

            int bossAttackCounter = 0;

            int reloadingBerserk = 5;
            int referencePoint = 1;

            string applicationHardStrike = "1";
            string applicationTripleStrike = "2";
            string applicationCounterattack = "3";
            string applicationRespite = "4";

            string namePlayer;
            string nameBoss = "Босс";

            string userInput;

            bool isTripleStrikeAvaliable = false;
            bool isRespiteAvaliable = false;

            Console.WriteLine("Введите имя игрока:");
            namePlayer = Console.ReadLine();
            Console.WriteLine($"{namePlayer} дошел до босса, чтобы победить {namePlayer} должен использовать конбинации ударов.");
            Console.WriteLine($"Сильный удара - бросается на врага и наносит {hardStrike} урона.");
            Console.WriteLine($"Тройной удар - в мгновение ока обрушиват на противника три молниеносных удара нанося врагу" +
                $" {tripleStrike} урона.(Может быть применен только после Сильного удара)");
            Console.WriteLine($"Контратака - блакирует урон врага и наносит {counterAttack} урона.");
            Console.WriteLine($"Отступление - отступает от врага не получив урона и вастанавливает себе {retreatPlayer} здоровья." +
                $"(Может быть применен только после Контратаки)");
            Console.WriteLine($"{nameBoss} после пяти атак вподает в состояние берсерка и наносит {berserkState} урона.");

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine("Выберите прием:");
                Console.WriteLine($"{applicationHardStrike}:Сильный удара - бросается на врага и наносит {hardStrike} урона.");
                Console.WriteLine($"{applicationTripleStrike}:Тройной удар - в мгновение ока обрушиват на противника три" +
                $" молниеносных удара нанося врагу {tripleStrike} урона.(Может быть применен только после Сильного удара)");
                Console.WriteLine($"{applicationCounterattack}:Контратака - блакирует урон врага и наносит {counterAttack} урона.");
                Console.WriteLine($"{applicationRespite}:Отступление - отступает от врага не получив урона и вастанавливает себе" +
                $" {retreatPlayer} здоровья.(Может быть применен только после Контратаки)");
                userInput = Console.ReadLine();

                if (userInput == applicationHardStrike)
                {
                    bossHealth -= hardStrike;
                    Console.WriteLine($"{bossHealth} - здоровье босса.");
                    playerHealth -= bossDamage;
                    Console.WriteLine(playerHealth + " - здоровье игрока.");
                    isTripleStrikeAvaliable = true;
                    bossAttackCounter++;

                    if (bossAttackCounter >= reloadingBerserk - referencePoint)
                    {
                        playerHealth -= berserkState;
                        Console.WriteLine($"{bossHealth} - здоровье босса.");
                        Console.WriteLine(playerHealth + " - здоровье игрока.");
                    }
                }
                else if (userInput == applicationTripleStrike)
                {
                    if (isTripleStrikeAvaliable == true)
                    {
                        bossHealth -= tripleStrike;
                        Console.WriteLine(bossHealth + " - здоровье босса.");
                        playerHealth -= bossDamage;
                        Console.WriteLine(playerHealth + " - здоровье игрока.");
                    }
                    else
                    {
                        Console.WriteLine("Нужно применить сильный удар");
                    }

                    isTripleStrikeAvaliable = false;
                }
                else if (userInput == applicationCounterattack)
                {
                    bossHealth -= counterAttack;
                    Console.WriteLine(bossHealth + " - здоровье босса.");
                    Console.WriteLine(playerHealth + " - здоровье игрока.");
                    isRespiteAvaliable = true;
                }
                else if (userInput == applicationRespite)
                {
                    if (isRespiteAvaliable == true)
                    {
                        Console.WriteLine(bossHealth + " - здоровье босса.");
                        playerHealth += retreatPlayer;
                        Console.WriteLine(playerHealth + " - здоровье игрока.");
                    }
                    else
                    {
                        Console.WriteLine("Нужно применить контратаку.");
                    }

                    isRespiteAvaliable = false;
                }
            }

            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Ничья.");
            }
            else if (playerHealth <= 0)
            {
                Console.WriteLine("Победа Босса!");
            }
            else
            {
                Console.WriteLine("Победа Игрока!");
            }
        }
    }
}
