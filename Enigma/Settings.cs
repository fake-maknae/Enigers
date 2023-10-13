using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Enigma
{
    class Settings
    {
        public static List<string> ringLines = new List<string>();
        public static List<char> textboxInput = new List<char>();
        public static List<char> textboxOutput = new List<char>();
        public static char[,] groupedRings = new char[,] { };
        public static char[,] rotatingRings = new char[,] { };
        public static int[] ringSelection = new int[3] { 0, 0, 0 };
        public static int[] ringOffset = new int[3] { 0, 0, 0 };
        public static bool checkboxIsChecked = false;

        public static void ReadFiles(string path) // This method is responsible for reading the contents of a CSV file.
        // It skips the first two rows (commonly used for headers) in the CSV file and reads the remaining lines.
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    // Skip the first two rows (header rows) of a csv file
                    sr.ReadLine(); // Skip the first row
                    sr.ReadLine(); // Skip the second row


                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Add each remaining line to the 'ringLines' list.
                        ringLines.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                // If an exception occurs (e.g., file not found), initialize 'ringLines' as an empty list.
                ringLines = new List<string>();
            }
        }

        public static void ringSorter() // This method is responsible for sorting and organizing the contents of a CSV file.
        // It takes the lines of the CSV file, splits them into individual elements, and rearranges them.
        {
            // Get the number of rows and columns in the CSV file.
            int xCount = ringLines.Count;
            int yCount = ringLines[0].Split(',').Length;
            
            // Create two 2D character arrays for temporary storage.
            groupedRings = new char[yCount, xCount];
            char[,] ungroupedRings = new char[xCount, yCount];

            // Iterate through the rows of the CSV file.
            for (int x = 0; x < xCount; x++)
            {
                // Split each line into individual elements using a comma as the separator.
                string[] ringElements = ringLines[x].Split(',');
            
                // Convert the string elements to characters and store them in the temporary array.
                for (int y = 0; y < yCount; y++)
                {
                    ungroupedRings[x, y] = stringToChar(ringElements[y]);
                }
            }

            // Rearrange the characters into the final 2D character array for convenient access.
            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount; x++)
                {
                    groupedRings[y, x] = ungroupedRings[x, y];
                }
            }
        }

        private static char stringToChar(string a) // This method is responsible for converting a string to a char.
        // If the conversion is successful, it returns the corresponding character.
        // If the conversion fails, it handles the FormatException by returning a default character ('?').
        {
            try
            {
                // Attempt to convert the string to an integer and then to a character.
                return Convert.ToChar(Convert.ToInt32(a));
            }
            catch (FormatException)
            {
                //Handles the case where letters cannot be converted into an integer
                //For now, I will use '?' as a default value
                return '?';
            }
        }

        public static int ringCount() // This method returns the count of available rings, it basically gets the ring count.

        {
            return groupedRings.GetLength(0) - 1;
        }

        public static int ringContentCount() // This method returns the number of characters in one ring, it basically gets the number of characters in one ring.
        {
            return groupedRings.GetLength(1);
        }

        public static string NumberFormatter(int count) // This method formats an integer value to display it with two digits, basically formats the number display.

        {
            return String.Format("{0:00}", count);
        }

        public static void ringSelectionCounter(int index, char buttonFunction) // This method is responsible for incrementing or decrementing the ring selection for a specific rotor.
        {
            // The 'index' parameter specifies which rotor's ring selection to adjust (0 for first, 1 for second, and 2 for third rotor).
            switch (buttonFunction)
            {
                case '+':
                    // Increment the ring selection for the specified rotor.
                    ringSelection[index]++;
                    
                    // If the ring selection exceeds the maximum ring count, wrap it back to 0.
                    if (ringSelection[index] > ringCount() - 1)
                        ringSelection[index] = 0;
                    break;
                case '-':
                    // Decrement the ring selection for the specified rotor.
                    ringSelection[index]--;
                    
                    // If the ring selection goes below 0, wrap it to the maximum ring count.
                    if (ringSelection[index] < 0)
                        ringSelection[index] = ringCount() - 1;
                    break;
            }
        }

        public static void ringSettingsCounter(int index, char buttonFunction) // This method is responsible for incrementing or decrementing the ring settings for a specific rotor.
        {
            // The 'index' parameter specifies which rotor's settings to adjust (0 for first, 1 for second, and 2 for third rotor).
            switch (buttonFunction)
            {
                case '+':
                    // Increment the ring setting for the specified rotor.
                    ringOffset[index]++;
                    
                    // If the ring setting exceeds the maximum count, wrap it back to 0.
                    if (ringOffset[index] > ringContentCount() - 1)
                        ringOffset[index] = 0;
                    break;
                case '-':
                    // Decrement the ring setting for the specified rotor.
                    ringOffset[index]--;
                    
                    // If the ring setting goes below 0, wrap it to the maximum count.
                    if (ringOffset[index] < 0)
                        ringOffset[index] = ringContentCount() - 1;
                    break;
            }
        }

        public static void adjustRotors() // This method adjusts the positions of the Enigma machine's rotors based on the selected settings.
        {
            int rotorIndex = 0;
            int length = groupedRings.GetLength(1);
            rotatingRings = new char[3, length];
            
            // Adjust the position of the first rotor based on the selected setting and offset.
            for (int x = 0; x < length; x++)
            {
                rotorIndex = x + ringOffset[0];
                
                // Ensure that the rotorIndex stays within the valid range (0 to length-1).
                if (rotorIndex >= length)
                    rotorIndex %= length;

                // Update the first rotor's position in the rotatingRings array.
                rotatingRings[0, x] = groupedRings[ringSelection[0] + 1, rotorIndex];
            }

            // Repeat the same process for the second rotor.
            for (int x = 0; x < length; x++)
            {
                rotorIndex = x + ringOffset[1];
                if (rotorIndex >= length)
                    rotorIndex %= length;

                rotatingRings[1, x] = groupedRings[ringSelection[1] + 1, rotorIndex];
            }

            // Repeat the process for the third rotor.
            for (int x = 0; x < length; x++)
            {
                rotorIndex = x + ringOffset[2];
                if (rotorIndex >= length)
                    rotorIndex %= length;

                rotatingRings[2, x] = groupedRings[ringSelection[2] + 1, rotorIndex];
            }
        }

        public static void rotateRotors() //This method is responsible to rotate the rotors
        {
            int max = groupedRings.GetLength(1) - 1;
            
            // Increment the offset of the first rotor.
            ringOffset[0]++;
            
            // Check if the offset of the first rotor has reached the maximum value.
            if (ringOffset[0] > max)
            {
                // Reset the offset to 0.
                ringOffset[0] = 0;
                
                // Increment the offset of the second rotor.
                ringOffset[1]++;
                
                // Check if the offset of the second rotor has reached the maximum value.
                if (ringOffset[1] > max)
                {
                    // Reset the offset to 0.
                    ringOffset[1] = 0;
                    
                    // Increment the offset of the third rotor.
                    ringOffset[2]++;
                    
                    // Check if the offset of the third rotor has reached the maximum value.
                    if (ringOffset[2] > max)
                    {
                        // Reset the offset to 0.
                        ringOffset[2] = 0;
                    }
                }
            }
            // Rotate the rotors based on the new offsets.
            adjustRotors();
        }

        public static void reverseRotors() // This method is responsible to rotate rotors in reverse
        {
            if (textboxInput.Count == 0)
            {
                // If the input textbox is empty, do nothing.
            }
            else
            {
                int max = groupedRings.GetLength(1) - 1;
                
                // Decrement the offset of the first rotor.
                ringOffset[0]--;
                
                // Check if the offset of the first rotor has gone below 0.
                if (ringOffset[0] < 0)
                {
                    // Reset the offset to the maximum value.
                    ringOffset[0] = max;
                    
                    // Decrement the offset of the second rotor.
                    ringOffset[1]--;
                    
                    // Check if the offset of the second rotor has gone below 0.
                    if (ringOffset[1] < 0)
                    {
                        // Reset the offset to the maximum value.
                        ringOffset[1] = max;
                        
                        // Decrement the offset of the third rotor.
                        ringOffset[2]--;
                        
                        // Check if the offset of the third rotor has gone below 0.
                        if (ringOffset[2] < 0)
                        {
                            // Reset the offset to the maximum value.
                            ringOffset[2] = max;
                        }
                    }
                }
                // Rotate the rotors based on the new offsets.
                adjustRotors();
            }
        }

        public static void inputTextbox(char input) // Saves the input charecters in a list
        {
            textboxInput.Add(input);
        }

        public static void outputTextbox(char input) // Saves the output/encrypted charecters in a list
        {
            textboxOutput.Add(input);
        }

        public static string encrypted(char input) // returns the encrypted character
        {
            // Initialize the output character to a null character.
            char output = '\0';
            
            // Initialize the encrypted string.
            string encrypted = "";
            
            // Input the character into the Enigma machine's input mechanism.
            inputTextbox(input);

            int x = 0;
            if (input == '^')
            {
                output = '^'; // Leave '^' unchanged
            }
            else
            {
                // Iterate through the first rotor (groupedRings) to find the corresponding output character.
                for (x = 0; x < groupedRings.GetLength(1); x++)
                {
                    if (input == groupedRings[0, x])
                    {
                        output = rotatingRings[0, x];
                        break;
                    }
                }
            }

            int y = 0;
            for (y = 0; y < groupedRings.GetLength(1); y++)
            {
                if (rotatingRings[0, x] == groupedRings[0, y])
                {
                    output = rotatingRings[1, y];
                    break;
                }
            }

            int z = 0;
            for (z = 0; z < groupedRings.GetLength(1); z++)
            {
                if (rotatingRings[1, y] == groupedRings[0, z])
                {
                    output = rotatingRings[2, z];
                    break;
                }
            }

            if (checkboxIsChecked) // Check if the reflector is enabled.
            {
                int z1 = 0;
                for (z1 = 0; z1 < groupedRings.GetLength(1); z1++)
                {
                    if (rotatingRings[2, z] == groupedRings[0, z1])
                    {
                        output = rotatingRings[2, z1];
                        break;
                    }
                }

                int y1 = 0;
                for (y1 = 0; y1 < groupedRings.GetLength(1); y1++)
                {
                    if (rotatingRings[2, z1] == groupedRings[0, y1])
                    {
                        output = rotatingRings[1, y1];
                        break;
                    }
                }

                int x1 = 0;
                for (x1 = 0; x1 < groupedRings.GetLength(1); x1++)
                {
                    if (rotatingRings[1, y1] == groupedRings[0, x1])
                    {
                        output = rotatingRings[0, x1];
                        break;
                    }
                }     
                // Rotate the rotors.
                rotateRotors();

                // Output the encrypted character.
                outputTextbox(output);

                // Construct the "encrypted" string from the output of the Enigma machine.
                for (int a = 0; a < textboxOutput.Count; a++)
                {
                    encrypted = textboxOutput[a].ToString();
                }

                // Return the encrypted character.
                return encrypted;
            }
            else
            {
                // Rotate the rotors
                rotateRotors();
                
                // Output the encrypted character.
                outputTextbox(output);

                // Construct the "encrypted" string from the output of the Enigma machine.
                for (int a = 0; a < textboxOutput.Count; a++)
                {
                    encrypted = textboxOutput[a].ToString();
                }
                
                // Return the encrypted character.
                return encrypted;
            }
        }

        public static string backspaceInput() // Removes the last element in the list
        {
            // Initialize an empty string to store the updated input.
            string output = "";
            
            // Check if there are elements in the "textboxInput" list.
            if (textboxInput.Any())
            {
                // Remove the last element from the list.
                textboxInput.RemoveAt(textboxInput.Count - 1);

                // Reconstruct the "output" string by iterating through the updated "textboxInput" list.
                for (int x = 0; x < textboxInput.Count; x++)
                {
                    output += textboxInput[x];
                }
            }
            
            // Return the updated "output" string after backspacing.
            return output;
        }

        public static string backspaceOutput() // Removes the last element in the list
        {
            // Initialize an empty string to store the updated output.
            string output = "";
            
            // Check if there are elements in the "textboxOutput" list.
            if (textboxOutput.Any())
            {
                // Remove the last element from the list.
                textboxOutput.RemoveAt(textboxOutput.Count - 1);

                // Reconstruct the "output" string by iterating through the updated "textboxOutput" list.
                for (int x = 0; x < textboxOutput.Count; x++)
                {
                    output += textboxOutput[x];
                }
            }
            
            // Return the updated "output" string after backspacing.
            return output;
        }
    }
}