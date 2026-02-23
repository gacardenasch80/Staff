using CandidatesMS.Models;
using System;
using System.Collections.Generic;

namespace CandidatesMS.Services
{
    public interface IRandomPasswordService
    {
        List<string> GenerateRandomPassword(int stringLength, int numberStrings);
        string GenerateRandomPasswordNineLetters();
        CandidateDTO GenerateValidationCodeInCandidate(CandidateDTO candidateDTO);
    }

    public class RandomPasswordService : IRandomPasswordService
    {

        Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        public RandomPasswordService()
        {

        }

        public List<string> GenerateRandomPassword(int stringLength, int numberStrings)
        {
            List<string> strings = new List<string>();

            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            char[] superString = new char[stringLength * numberStrings];
            string superStringConverted = "";

            for (int i = 0; i < stringLength * numberStrings; i++)
            {
                superString[i] = validChars[random.Next(0, validChars.Length)];
            }

            superStringConverted = new string(superString);

            for (int i = 0; i < numberStrings; i++)
            {
                strings.Add(superStringConverted.Substring(i * stringLength, stringLength));
            }

            return strings;
        }

        public string GenerateRandomPasswordNineLetters()
        {
            string validUpperChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            string validLowerChars = "abcdefghijklmnopqrstuvwxyz";
            string validNumbers = "0123456789";

            char[] superLowerString = new char[3];
            string superLowerStringConverted = "";

            char[] superUpperString = new char[3];
            string superUpperStringConverted = "";

            char[] superNumber = new char[3];
            string superNumberConverted = "";

            for (int i = 0; i < 3; i++)
            {
                superLowerString[i] = validLowerChars[random.Next(0, validLowerChars.Length)];
            }

            for (int i = 0; i < 3; i++)
            {
                superUpperString[i] = validUpperChars[random.Next(0, validUpperChars.Length)];
            }

            for (int i = 0; i < 3; i++)
            {
                superNumber[i] = validNumbers[random.Next(0, validNumbers.Length)];
            }

            superLowerStringConverted = new string(superLowerString);
            superUpperStringConverted = new string(superUpperString);
            superNumberConverted = new string(superNumber);

            return superUpperStringConverted + superLowerStringConverted + superNumberConverted + "*";
        }

        public CandidateDTO GenerateValidationCodeInCandidate(CandidateDTO candidateDTO)
        {
            List<string> strings = GenerateRandomPassword(6, 1);

            candidateDTO.LoginCode = strings[0];

            return candidateDTO;
        }
    }
}
