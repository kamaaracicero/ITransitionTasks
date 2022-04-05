namespace Task_3
{
    internal class GameJudge
    {
        public GameJudge(int moves)
        {
            GameMoves = moves;
            Half = moves / 2;
        }

        public int GameMoves { get; }

        private int Half { get; set; }

        public GameResults CheckMove(int playerMove, int computerMove)
        {
            if (playerMove == computerMove)
            {
                return GameResults.DRAW;
            }

            if (FirstVariant(playerMove, computerMove) || SecondVariant(playerMove, computerMove))
            {
                return GameResults.WIN;
            }

            return GameResults.LOSE;
        }

        private bool FirstVariant(int playerMove, int computerMove) =>
            playerMove > computerMove && playerMove - computerMove > Half;

        private bool SecondVariant(int playerMove, int computerMove) =>
            playerMove < computerMove && computerMove - playerMove <= Half;
    }
}
