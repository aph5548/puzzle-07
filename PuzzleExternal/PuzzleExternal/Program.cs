using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*
 * Austin Stone
 * 4/30/17
 * External tool for Puzzle07
 */
namespace PuzzleExternal
{
    class Program
    {
        static void Main(string[] args)
        {

            // getting ready the streamWriter for use later
            StreamWriter writer = new StreamWriter("../../../../Puzzle07/DataFile.txt", false);
            // code to get values for each room from the player to use
            Console.WriteLine("Each room has 3 variations on it. Please enter 1 - 3 in order to select each room variation you would like");
            Console.Write("Water Room: ");
            string waterRoomPresetStr = Console.ReadLine();

            Console.Write("Lever Room: ");
            string leverRoomPresetStr = Console.ReadLine();

            Console.Write("Red Light Green Light Room: ");
            string redLightPresetStr = Console.ReadLine();

            Console.Write("Math Sequence Room: ");
            string mathPresetStr = Console.ReadLine();

            // code to check if the value entered is valid
            int waterRoomPreset;
            int leverRoomPreset;
            int redLightPreset;
            int mathPreset;

            while (true)
            {
                bool waterRoomPresetBool = int.TryParse(waterRoomPresetStr, out waterRoomPreset);
                bool leverRoomPresetBool = int.TryParse(leverRoomPresetStr, out leverRoomPreset);
                bool redLightPresetBool = int.TryParse(redLightPresetStr, out redLightPreset);
                bool mathPresetBool = int.TryParse(mathPresetStr, out mathPreset);

                if (waterRoomPresetBool == false || waterRoomPreset < 1 || waterRoomPreset > 3)
                {
                    Console.Write("Please enter a valid value for Water Room: ");
                    waterRoomPresetStr = Console.ReadLine();
                }


                if(leverRoomPresetBool == false || leverRoomPreset < 1 || leverRoomPreset > 3)
                {
                    Console.Write("Please enter a valid value for Lever Room: ");
                    leverRoomPresetStr = Console.ReadLine();
                }


                if (redLightPresetBool == false || redLightPreset < 1 || redLightPreset > 3)
                {
                    Console.Write("Please enter a valid value for Red Light Green Light Room: ");
                    redLightPresetStr = Console.ReadLine();
                }


                if (mathPresetBool == false || mathPreset < 1 || mathPreset > 3)
                {
                    Console.Write("Please enter a valid value for the Math Sequence Room: ");
                    mathPresetStr = Console.ReadLine();
                }

                // code to exit loop and write to the file in correct order
                if(waterRoomPresetBool && leverRoomPresetBool && redLightPresetBool && mathPresetBool && waterRoomPreset > 0 && waterRoomPreset < 4 && leverRoomPreset > 0 && leverRoomPreset < 4 && redLightPreset > 0 && redLightPreset < 4 && mathPreset > 0 && mathPreset < 4)
                {
                    writer.WriteLine(waterRoomPreset);
                    writer.WriteLine(leverRoomPreset);
                    writer.WriteLine(redLightPreset);
                    writer.WriteLine(mathPreset);
                    writer.Close();
                    return;

                }
            }
            
        }
    }
}
