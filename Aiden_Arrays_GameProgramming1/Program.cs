using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiden_Arrays_GameProgramming1
{
    internal class Program
    {

        static String[] weaponNames = { "bow", "pistol", "shotgun", "rocket launcher" };
        static int[] weaponAmmo = { 10, 16, 8, 2 };
        static int[] weaponClipMax = { 1, 8, 2, 1 };
        static int[] weaponClip = { 1, 8, 2, 1};

        static string currentWeapon = weaponNames[1];
        static string weaponName = weaponNames[1];
        static string PlayerInput;
        static int addAmmoAmount;
        static int IndexOfWeapon;
        static int ammoShot;
        static int ammoType;
        static int ammoFindChance;
        static int Score;

        static Random ammoShotRnD = new Random();
        static Random addAmmoAmountRnd = new Random();
        static Random ammoTypeRnD = new Random();
        static Random weaponTypeRnD = new Random();
        static Random ammoFindChanceRnD = new Random();
        static Random ScoreRnD = new Random();

        static void ScoreAdd()
        {
            Score += ScoreRnD.Next(25, 150);
        }

        static void PressAny()
        {
            Console.WriteLine("\nPress Any Key...");
            Console.ReadKey();
            Console.Clear();
        }
        static void ShowHUD()
        {
            Console.WriteLine($"Total Score: {Score}");
            Console.WriteLine("{0,0}{1,3}", $"Current Weapon: ", $"{weaponNames[IndexOfWeapon].ToUpper()}");
            Console.WriteLine("{0,0}{1,3}", $"Current Loaded: ", $"{weaponClip[IndexOfWeapon]}");
            Console.WriteLine("{0,0}{1,7}", $"Total Ammo: ", $"{weaponAmmo[IndexOfWeapon]}");

        }

        static void Reload()
        {
            Console.WriteLine("Would you like to reload?");
            Console.WriteLine("\nAnswer: ");

            Console.SetCursorPosition(8, 2);
            PlayerInput = Console.ReadLine();
            PlayerInput = PlayerInput.ToLower();

            if (PlayerInput == "y" || PlayerInput == "yes")
            {
                if (weaponAmmo[IndexOfWeapon] > 0)
                {
                    if (weaponAmmo[IndexOfWeapon] >= weaponClipMax[IndexOfWeapon])
                    {
                        weaponClip[IndexOfWeapon] += weaponClipMax[IndexOfWeapon];
                    }
                    Console.Clear();
                    Console.WriteLine($"You have reloaded with {weaponClip[IndexOfWeapon]} ammo ready!");
                    PressAny();
                }
            }
            else if(PlayerInput == "n" || PlayerInput == "no")
            {
                Console.Clear();
                Fire();
            }
        }

        static void Play()
        {
            ShowHUD();
            Fire();
            AmmoPickup();
            SwitchWeapon();
        }

        static void ChooseWeapon()
        {
            Console.WriteLine($"Choose weapon by name: {weaponNames[0].ToUpper()}, {weaponNames[1].ToUpper()}, {weaponNames[2].ToUpper()}, {weaponNames[3].ToUpper()}");
            Console.WriteLine("\nYour Choice: ");
            Console.SetCursorPosition(13, 2);
            PlayerInput = Console.ReadLine();
            PlayerInput.ToLower();
            weaponName = PlayerInput.ToLower();
            IndexOfWeapon = Array.IndexOf(weaponNames, weaponName);


            if (IndexOfWeapon >= 0 && IndexOfWeapon <= 3)
            {
                Console.Clear();
                Console.WriteLine($"You have successfully chosen {weaponNames[IndexOfWeapon]}");
                PressAny();
                Play();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Your Answer \"{PlayerInput}\" is not valid.");
                PressAny();
                ChooseWeapon();
            }
        }
        static void Fire()
        {
            Console.WriteLine("\nWould you like to fire your weapon?");
            Console.WriteLine("Answer: ");
            Console.SetCursorPosition (8, 6);
            PlayerInput = Console.ReadLine();
            PlayerInput = PlayerInput.ToLower();

            if (PlayerInput == "y" || PlayerInput == "yes")
            {
                if (weaponAmmo[IndexOfWeapon] >= 0 && weaponClip[IndexOfWeapon] > 0)
                {

                    Console.Clear();
                    currentWeapon = weaponName;
                    Console.WriteLine($"You shoot your {currentWeapon}");

                    IndexOfWeapon = Array.IndexOf(weaponNames, currentWeapon);
                    ammoShot = ammoShotRnD.Next(1, 3);

                    if(ammoShot > weaponClip[IndexOfWeapon])
                    {
                        ammoShot = weaponClip[IndexOfWeapon];
                    }

                    weaponClip[IndexOfWeapon] -= ammoShot;
                    weaponAmmo[IndexOfWeapon] -= ammoShot;

                    Console.WriteLine($"\nYou have {weaponAmmo[IndexOfWeapon]} shots left...");
                    ScoreAdd();
                    PressAny();
                }
                else if (weaponClip[IndexOfWeapon] <= 0 && weaponAmmo[IndexOfWeapon] > 0)
                {
                    Console.Clear();
                    Console.WriteLine("You need to reload!");
                    PressAny();
                    Reload();
                }
                else if (weaponAmmo[IndexOfWeapon] == 0 || weaponClip[IndexOfWeapon] == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You don't have enough ammo!");
                    PressAny();
                    SwitchWeapon();
                }

            }
            else if (PlayerInput == "n" || PlayerInput == "no")
            {
                SwitchWeapon();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Your answer \"{PlayerInput}\" is not valid!");
                PressAny();
                ShowHUD();
                Fire();
            }

        }

        static void SwitchWeapon()
        {
            Console.Clear();
            Console.WriteLine("Would you like to switch weapons? Y/N");
            Console.Write("\nAnswer: ");
            PlayerInput = Console.ReadLine();
            PlayerInput = PlayerInput.ToLower();

            if (PlayerInput == "y" || PlayerInput == "yes")
            {
                Console.Clear();
                Console.WriteLine($"Choose weapon by name: {weaponNames[0]}, {weaponNames[1]}, {weaponNames[2]}, {weaponNames[3]}");
                Console.WriteLine("{0,0}{1,15}{2,8}{3,9}{4,17}", $"Ammo Left: ", $"{weaponAmmo[0]}", $"{weaponAmmo[1]}", $"{weaponAmmo[2]}", $"{weaponAmmo[3]}");
                Console.WriteLine("\nAnswer: ");
                Console.SetCursorPosition(8, 3);

                PlayerInput = Console.ReadLine();
                PlayerInput = PlayerInput.ToLower();
                weaponName = PlayerInput;
                IndexOfWeapon = Array.IndexOf(weaponNames, weaponName);
                currentWeapon = weaponNames[IndexOfWeapon];

                Console.Clear();
                Console.WriteLine($"You have chosen {weaponNames[IndexOfWeapon]}");

                PressAny();
                Play();
            }
            else if(PlayerInput == "n" || PlayerInput == "no")
            {
                Console.Clear();
                Play();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Your input \"{PlayerInput}\" is invalid");
                PressAny();
                SwitchWeapon();
            }
        }

        static void AmmoPickup()
        {
            Console.Clear();
            ammoFindChance = ammoFindChanceRnD.Next(0, 100);

            if(ammoFindChance >= 65)
            {
                addAmmoAmount = addAmmoAmountRnd.Next(2, 8);
                ammoType = ammoTypeRnD.Next(0, 3);

                IndexOfWeapon = Array.IndexOf(weaponNames, weaponName);
                weaponAmmo[ammoType] += addAmmoAmount;
                weaponName = weaponNames[ammoType];

                Console.WriteLine($"You picked up {addAmmoAmount} {weaponName} ammo");
                Console.WriteLine($"\nYou now have {weaponAmmo[ammoType]} {weaponName} ammo!");
                weaponName = currentWeapon;
                PressAny();
            }


        }

        static void Main(string[] args)
        {
            ChooseWeapon();

        }
    }
}
