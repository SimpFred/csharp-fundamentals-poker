using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {
        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)

        //TODO: complete the winningPair method, without chaning the method signature
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            // Initialize the result tuple with empty strings
            result = new Tuple<string, string>(string.Empty, string.Empty);

            // Initialize highestValue to -1 to ensure any valid hand will be higher
            int highestValue = -1;

            // Iterate over each hand in the hands collection
            foreach (var hand in hands)
            {
                // Get the value of each card in the hand
                int value1 = GetValueOfCard(hand.Item1);
                int value2 = GetValueOfCard(hand.Item2);

                // Check if the two cards have the same value
                if (value1 == value2)
                {
                    // Calculate the total value of the hand
                    int totalValue = value1 + value2;

                    // If the total value is higher than the current highest value, update highestValue and result
                    if (totalValue > highestValue)
                    {
                        highestValue = totalValue;
                        result = hand;
                    }
                }
            }

            // Return true if a winning pair was found, otherwise false
            return result.Item1 != string.Empty;
        }

        // Method to get the value of a card based on its rank
        public int GetValueOfCard(string card)
        {
            switch (card)
            {
                case "A":
                    return 14; // Ace
                case "K":
                    return 13; // King
                case "Q":
                    return 12; // Queen
                case "J":
                    return 11; // Jack
                default:
                    return int.Parse(card); // Numeric cards
            }
        }
    }
}