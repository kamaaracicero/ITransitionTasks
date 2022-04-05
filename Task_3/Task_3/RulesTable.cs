using ConsoleTables;
using System.Linq;

namespace Task_3
{
    internal sealed class RulesTable
    {
        public RulesTable(string[] names)
        {
            Names = names;
        }

        public string[] Names { get; }

        public void Print()
        {
            var headerItems = Names.Prepend("PC \\ User");
            var table = new ConsoleTable(headerItems.ToArray());

            var rules = new GameJudge(Names.Length);
            for (int firstIndex = 0; firstIndex < Names.Length; firstIndex++)
            {
                var curRow = new string[Names.Length + 1];
                curRow[0] = Names[firstIndex];

                for (int secondIndex = 0; secondIndex < Names.Length; secondIndex++)
                {
                    curRow[secondIndex + 1] = rules.CheckMove(secondIndex, firstIndex).ToString();
                }

                table.AddRow(curRow.ToArray());
            }

            table.Write(Format.Alternative);
        }
    }
}
