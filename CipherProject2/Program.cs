using System;
using System.Text;
using System.Text.RegularExpressions;

namespace HackerTest;
public class CipherProject
{
	public static void Main(String[] args)
	{
		const int offset = 3; //can only be from 0 - 26
		bool isInputValid = false;

        while (!isInputValid)
        {
			Console.WriteLine("Please enter your message:");

			String secretMessage = Console.ReadLine();

			if (ValidateMessage(secretMessage))
			{
				isInputValid = true;
				StringBuilder encryptedMessage = EncryptMessage(secretMessage, offset);
				StringBuilder decryptedMessage = DecryptMessage(encryptedMessage.ToString(), offset);

				Console.WriteLine("Encrypted Value: " + encryptedMessage.ToString());
				Console.WriteLine("Decrypted Value: " + decryptedMessage.ToString());
				Console.WriteLine("Cipher Used: " + offset.ToString()) ;

			}
			else
			{
				Console.WriteLine("Sorry, ensure string is not empty, contains no whitespace and contains only A-Z/a-z letters");
			}

		}
	}

	public static StringBuilder EncryptMessage(String message, int offset)
	{
		StringBuilder myResult = new();
		char myChar;

		for (int i = 0; i < message.Length; i++)
		{
			if (char.IsLower(message[i])) //lowercase
			{

				myChar = (char)(((int)message[i] + offset - 97) % 26 + 97); //97 is the code for lowercase 'a' //26 letters in alphabet
			}
			else //uppercase
			{
				int myInt = (int)message[i];
				myChar = (char)(((int)message[i] + offset - 65) % 26 + 65); //65 is the char code for uppercase 'A' //26 letters in alphabet
			}

			myResult.Append(myChar);

		}
		return myResult;
	}
	public static StringBuilder DecryptMessage(String message, int offset)
	{
		StringBuilder myResult = new();
		char myChar;

		for (int i = 0; i < message.Length; i++)
		{

			if (char.IsLower(message[i])) //lowercase
			{
				int myInt = (int)message[i];

				myChar = (char)(((int)message[i] - offset - 122) % 26 + 122); //122 is the code for lowercase 'z' //26 letters in alphabet
			}
			else //uppercase
			{
				myChar = (char)(((int)message[i] - offset - 90) % 26 + 90); //90 is the code for uppercase 'Z'  //26 letters in alphabet
			}
			myResult.Append(myChar);

		}
		return myResult;
	}


	//validate if message is valid
	private static bool ValidateMessage(string input)
	{
        if (!String.IsNullOrEmpty(input) && Regex.IsMatch(input, "^[a-zA-Z]+$"))
        {
			return true;
        }
        else 
		{ 
			return false; 
		}
        		
	}
}


