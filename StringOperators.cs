using System;
/* 
   Lab 4 - String Operations on a File - Programming 1
   Daniel Osborne Github - danozzy86
   Due 10/1 @ 4PM
*/
class StringOperators
{
    public static int CharCount(string usrInput, bool vowel)
    {
        //Loops through and checks how many vowels or letters there are in the string by using the split method.
        char[] vowelArr = { 'A', 'E', 'I', 'O', 'U' };
        char[] letterArr = {'A','B','C','D','E','F','G','H','I','J','K','L',
                            'M','N','O','P','Q','R','S','T','U','V','W','X',
                            'Y','Z'};

        usrInput = usrInput.ToUpper();
        int intCharCount = 0;

        if (vowel)
        {
            //Counts the amount of vowels present in the string.
            foreach (char v in vowelArr)
            {
                intCharCount += usrInput.Split(v).Length;
            }
            return intCharCount - vowelArr.Length;
        }
        else
        {
            //Counts the string value by matching characters and adding the value by using the index of the letterArr
            char[] usrCharInput = usrInput.ToCharArray();

            foreach (char v in letterArr)
            {
                foreach (char c in usrCharInput)
                {
                    if (c == v)
                    {
                        intCharCount += Array.IndexOf(letterArr, v) + 1;
                    }
                }
            }
            return intCharCount;
        }
    }
    public static int WordCount(string usrInput)
    {
        //This method is still a WIP, basically just checks for spaces to count words. Also now uses line breaks.
        int intWordCount = 1;
        int strPos = 0;

        while (strPos <= usrInput.Length - 1)
        {
            if (usrInput[strPos] == ' ' || usrInput[strPos] == '\n')
            {
                intWordCount++;
            }
            strPos++;
        }
        return intWordCount;
    }
    public static bool IsPalindrome(string usrInput)
    {
        //This method will basically seperate the string into a char array, reverse it, turn it back into a string then compare.
        string usrInputRev;
        char[] charArr = usrInput.ToCharArray();

        Array.Reverse(charArr);
        usrInputRev = new string(charArr);

        if (usrInput == usrInputRev)
            return true;
        else
            return false;
    }
}