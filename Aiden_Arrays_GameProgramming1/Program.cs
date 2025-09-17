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

        static String[] weaponNames = { "Bow", "Pistol", "Shotgun", "Rocket Launcher" };
        static int[] weaponAmmo = { 10, 16, 8, 2 };

        static string currentWeapon = weaponNames[1];
        static string weaponName = weaponNames[1];
        static string PlayerInput;
        static int weaponType;
        static int addAmmoAmount;
        static int IndexOfWeapon;
        static int ammoShot;
        static int ammotype;

        static Random ammoShotRnD = new Random();
        static Random addAmmoAmountRnd = new Random();
        static Random ammoTypeRnD = new Random();
        static Random weaponTypeRnD = new Random();

        static void ShowHUD()
        {
            Console.WriteLine("{0,0}{1,3}{2,9}{3,10}{4,18}", $"Current Arsenal: ", $"{weaponNames[0]}", $"{weaponNames[1]}", $"{weaponNames[2]}", $"{weaponNames[3]}");
            Console.WriteLine("{0,0}{1,6}{2,9}{3,10}{4,18}", $"Current Ammo: ", $"{weaponAmmo[0]}", $"{weaponAmmo[1]}", $"{weaponAmmo[2]}", $"{weaponAmmo[3]}");

        }
        static void ShootWeapon()
        {
            Console.Clear();

            if(weaponAmmo[IndexOfWeapon] != 0 || weaponAmmo[IndexOfWeapon] >= 0)
            {
                Console.WriteLine($"You shoot your {currentWeapon}");

                IndexOfWeapon = Array.IndexOf(weaponNames, currentWeapon);
                ammoShot = ammoShotRnD.Next(1, 3);

                if(ammoShot > weaponAmmo[IndexOfWeapon])
                {
                    ammoShot -= weaponAmmo[IndexOfWeapon];
                }

                weaponAmmo[IndexOfWeapon] -= ammoShot;

                Console.WriteLine($"\nYou have {weaponAmmo[IndexOfWeapon]} shots left...");
            }
            else if (weaponAmmo[IndexOfWeapon] == 0 || weaponAmmo[IndexOfWeapon] <= 0)
            {

            }
            else
            {

            }

            Console.ReadKey();
        }

        static void SwitchWeapon()
        {
            Console.Clear();
            Console.WriteLine("Would you like to switch weapons? Y/N");
            PlayerInput = Console.ReadLine();
            PlayerInput.ToLower();

            if(PlayerInput == "y" || PlayerInput == "yes")
            {
                Console.Clear();
                Console.WriteLine($"Choose weapon number or name: {weaponNames}({weaponNames[0]}), {weaponNames}({weaponNames[0]}), {weaponNames}({weaponNames[0]}), {weaponNames}({weaponNames[0]})");

                PlayerInput = Console.ReadLine();
                weaponName = PlayerInput;
                IndexOfWeapon = Array.IndexOf(weaponNames, weaponName);

                Console.WriteLine($"You have chosen {weaponNames[IndexOfWeapon]}");

                Console.ReadKey();
            }
            else if(PlayerInput == "n" || PlayerInput == "no")
            {

            }
            else
            {
                Console.WriteLine($"Your input \"{PlayerInput}\" is invalid");
                Console.ReadKey();
                Console.Clear();
                SwitchWeapon();
            }
        }

        static void AmmoPickup()
        {
            Console.Clear();
            addAmmoAmount = addAmmoAmountRnd.Next(2, 8);

            weaponType = weaponTypeRnD.Next(0, 3);
            ammotype = ammoTypeRnD.Next(0, 3);

            IndexOfWeapon = Array.IndexOf(weaponNames, weaponName);
            weaponAmmo[IndexOfWeapon] += addAmmoAmount;

            Console.WriteLine($"You picked up {addAmmoAmount} {weaponName} ammo");
            Console.WriteLine($"\nYou now have {weaponAmmo[IndexOfWeapon]}");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {

            ShowHUD();
            Console.ReadKey();
            ShootWeapon();
            AmmoPickup();
            SwitchWeapon();


        }
    }
}
