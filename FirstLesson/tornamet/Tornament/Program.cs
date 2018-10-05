using System;
using System.IO;
using System.Linq;
using System.Collections;


namespace Tornament
{
    public class Program
    {
        static void Main(string[] args)
        {
            string ParticipantsPath = "ParticipantsList.txt";
            string Name = "MyTornament";

            string[] Participants = GetParticipantsList(ParticipantsPath);

            var t = new Tornament(Name, Participants);
            Console.WriteLine(t.ParticipantsPairs[0, 0]);
            t.WriteTornament();
        }

        public static string[] GetParticipantsList(string FilePath)
        {
            var separators = new char[] { ',', ';' };
            var FileText = File.ReadAllText(FilePath);
            var People = FileText.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                 .ToList()
                                 .ConvertAll((string input) => input.Trim())
                                 .ToArray();
            return People;
        }
    }



    public class Tornament
    {
        public string Name;// { get; set; }
        public string[,] ParticipantsPairs;
        public string[] CurrentLevelWinners = { };


        public Tornament(string name, string[] participants)
        {
            Name = name;
            ParticipantsPairs = Pair(participants);
        }

        public static string[,] Pair(string[] people)
        {
            if ((people.Length == 0) || (people.Length & (people.Length - 1)) != 0)
            {
                throw new ArgumentException("A list of people to pair should have length of power of 2");
            }

            int PairsAmt = people.Length / 2;
            string[,] Pairs = new string[PairsAmt, 2];
            for (var i = 0; i < PairsAmt; i += 1)
            {
                Pairs[i, 0] = people[i * 2];//, people[i + 1]};
                Pairs[i, 1] = people[i * 2 + 1];
            }
            return Pairs;
        }

        public void Evaluate()
        {
            ParticipantsPairs = Pair(CurrentLevelWinners);

            CurrentLevelWinners = new string[] {};
        }

        public void AddPairWinner(string PairWinner)
        {
            //если его нет иди в попу
            if (CheckPerson(PairWinner))
            {
                CurrentLevelWinners.Append(PairWinner);
            } else {
                throw new ArgumentException("A winner should be in the tornament.");
            }
            //если это был последний то переходи на след уровень
            if(CurrentLevelWinners.Length == ParticipantsPairs.GetLength(0))
            {
                Evaluate();
            }
        }

        public bool CheckPerson(string person)
        {
            bool inside = false;
            for (var i = 0; i < this.ParticipantsPairs.GetLength(0); i++)
            {
                if (this.ParticipantsPairs[i, 0] == person ||
                    this.ParticipantsPairs[i, 0] == person)
                {
                    inside = true;
                    break;
                }
            }
            return inside;
        }

        public void WriteTornament()
        {
            string pairs = String.Join("\n", ParticipantsPairs);
            string winners = String.Join("\n", CurrentLevelWinners);
            File.WriteAllText(Name, pairs +winners);
        }
    }
}
