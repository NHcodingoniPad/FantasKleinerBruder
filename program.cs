namespace FantaExotic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Player1, Player2;
            string SecretWord;
            char letter;
            int SWLength, p1, p2, mistakes, guess, run = 0, mistaketracker = 0;

            //Spieleinführung
            Console.WriteLine("Dies ist ein Hangman-Spiel! Es befindet sich noch in der BETA Phase und funktioniert aktuell nach der |ANMELDUNG| nur mit Kleinbuchstaben ");
            // Anmeldung zum Spiel 
            Console.WriteLine("|ANMELDUNG|");
            Console.WriteLine("Spieler1:"); Player1 = Console.ReadLine();
            Console.WriteLine("Spieler2:"); Player2 = Console.ReadLine();

            Thread.Sleep(1000);
            Console.Clear();

            // Wort von Player1 wird initialisiert und die BuchstabenZahl in einer Variablen gespeichert
            Console.WriteLine($"{Player1} ist als erstes am Zug! Gib dein Wort ein :");
            SecretWord = Console.ReadLine();

            SWLength = SecretWord.Length;

            // Den SecretWord string in ein char [] array convertiert und alle buchstaben in die einzelnen indices des arrays eingetragen
            // char ist wie string ein datentyp für zeichen aber diesesmal nur für einzelne character (zeichen), also pro char nur ein zeichen
            char[] Sw = new char[SWLength];
            Sw = SecretWord.ToCharArray(0, SWLength);

            Thread.Sleep(500);
            Console.Clear();

            // Spielinterface aufbauen in der Console 
            mistakes = 0;
            Console.WriteLine($"{mistakes} von 9 Fehler");

            
            char[] _ = new char[SWLength];      // Hier eine Kopie vom sw char array für die underlines
            for(int j = 0; j < _.Length;j++)
            {
                _[j] = Convert.ToChar("_");
            }

            foreach(char a in _)
            {
                Console.Write(a);
            }
            Console.WriteLine("");

            //Zug vom Player2, auswählen von den Buchstaben
            Console.WriteLine($"{Player2} ist jetzt dran!");
            guess = 1;

            do
            {
                Console.Write($"{guess}. Versuch:");
                letter = Convert.ToChar(Console.ReadLine());

                mistaketracker = 0;
                for (int i = 0; i < Sw.Length; i++)
                {
                    if (Sw[i] == letter)
                    {
                        _[i] = letter;
                    }
                    if (letter != Sw[i])
                    {
                        mistaketracker++;
                        if (mistaketracker == SWLength)
                        {
                            mistakes++;
                        }

                    }
                }
                guess++;
                
                Thread.Sleep(500);
                Console.Clear();
                // Hier wird die Console nach jdedem Durchgang neu aufgebaut 
                Console.WriteLine($"{mistakes} von 9 Fehler");
                foreach (char a in _)
                {
                    Console.Write(a);
                }
                Console.WriteLine("");
            } while (mistakes != 9);


        }
    }
}
