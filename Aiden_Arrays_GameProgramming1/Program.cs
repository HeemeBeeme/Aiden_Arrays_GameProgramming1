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

        static void AmmoPickup(string weaponName, int addAmmoAmount)
        {
            int IndexOfWeapon = Array.IndexOf(weaponNames, weaponName);

            weaponAmmo[IndexOfWeapon] += addAmmoAmount;
        }

        static void Main(string[] args)
        {
            AmmoPickup("Bow", 4);

            Console.WriteLine(weaponAmmo[0]);
            Console.WriteLine(weaponAmmo[1]);
            Console.WriteLine(weaponAmmo[2]);
            Console.WriteLine(weaponAmmo[3]);


            Console.ReadKey();



        }
    }
}
