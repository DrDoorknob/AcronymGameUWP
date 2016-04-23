using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AcronymGameWin10
{
    static class AcronymGenerator
    {
        struct CharWeight
        {
            public char Character { get; private set;}
            public double Weight { get; private set;}

            public CharWeight(char chr, double weight) : this()
            {
                Character = chr;
                Weight = weight;
            }
        }

        static IEnumerable<CharWeight> allCharacters = new CharWeight[] {
            new CharWeight('A', 1.0),
            new CharWeight('B', 1.0),
            new CharWeight('C', 1.0),
            new CharWeight('D', 1.0),
            new CharWeight('E', 1.0),
            new CharWeight('F', 1.0),
            new CharWeight('G', 1.0),
            new CharWeight('H', 1.0),
            new CharWeight('I', 1.0),
            new CharWeight('J', 1.0),
            new CharWeight('K', 1.0),
            new CharWeight('L', 1.0),
            new CharWeight('M', 1.0),
            new CharWeight('N', 1.0),
            new CharWeight('O', 1.0),
            new CharWeight('P', 1.0),
            new CharWeight('Q', 0.5),
            new CharWeight('R', 1.0),
            new CharWeight('S', 1.0),
            new CharWeight('T', 1.0),
            new CharWeight('U', 1.0),
            new CharWeight('V', 1.0),
            new CharWeight('W', 1.0),
            //new CharWeight('X', 1.0),
            new CharWeight('Y', 0.2),
            new CharWeight('Z', 0.1),
        };

        static double sumWeights = allCharacters.Sum(cw => cw.Weight);
        static Random rand = new Random();


        public static String GenerateAcronym(int minSize, int maxSize)
        {
            var differentiation = maxSize - minSize;
            int acronymLength;
            if (differentiation == 0)
            {
                acronymLength = minSize;
            }
            else
            {
                acronymLength = rand.Next(minSize, maxSize + 1); // rand.Next's max is exclusive, so add one.
            }
            var chars = new char[acronymLength];
            for (var i = 0; i < acronymLength; i++)
            {
                chars[i] = GenerateSingleCharacter();
            }
            return new String(chars);
        }

        public static char GenerateSingleCharacter()
        {
            var randWeight = rand.NextDouble() * sumWeights;
            foreach (var cw in allCharacters)
            {
                if (randWeight < cw.Weight)
                {
                    return cw.Character;
                }
                else
                {
                    randWeight -= cw.Weight;
                }
            }
            throw new RandomizationLogicException("Reached end of generation loop without picking a character");

        }
    }
}
