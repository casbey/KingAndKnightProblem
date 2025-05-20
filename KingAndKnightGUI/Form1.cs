using KingAndKnightProblemIJKRYI;

namespace KingAndKnightGUI
{
    public partial class Form1 : Form
    {
        Graphics g;
        Brush lightSquare = Brushes.Beige;
        Brush darkSquare = Brushes.SaddleBrown;
        Brush goalSquare = Brushes.LightGreen;
        Font pieceFont = new Font("Consolas", 24, FontStyle.Bold);
        Brush kingBrush = Brushes.Black;
        Brush knightBrush = Brushes.Blue;

        int cellSize = 60;
        int step = 0;
        int totalSteps = 0;

        BaseOfGraphSearchAlgorithms solver;
        KingAndKnightNode terminalNode;
        Stack<KingAndKnightState> stepsOfSolution;
        Stack<KingAndKnightState> tempStepsOfSolution = new Stack<KingAndKnightState>();
        KingAndKnightState state;

        public Form1()
        {
            InitializeComponent();
            cbSolverType.Text = "Simple Trial-Error";
            solver = new SimpleTrialAndError();
            terminalNode = solver.FindTerminalNode();
            stepsOfSolution = solver.PathOfSolution(terminalNode);
            totalSteps = stepsOfSolution.Count;
            state = stepsOfSolution.Pop();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            DrawBoard(g);
            DrawGoal(g);
            DrawPieces(g, state);
        }

        private void DrawBoard(Graphics g)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Brush squareColor = (row + col) % 2 == 0 ? darkSquare : lightSquare;
                    g.FillRectangle(squareColor, col * cellSize, (7 - row) * cellSize, cellSize, cellSize);
                }
            }
        }

        private void DrawGoal(Graphics g)
        {
            g.FillRectangle(goalSquare, 6 * cellSize, 7 * cellSize, cellSize, cellSize); // g1
        }

        private void DrawPieces(Graphics g, KingAndKnightState state)
        {
            int kingDrawRow = 7 - state.KingRow;
            int knightDrawRow = 7 - state.KnightRow;

            g.DrawString("K", pieceFont, kingBrush, state.KingCol * cellSize + 10, kingDrawRow * cellSize + 5);
            g.DrawString("N", pieceFont, knightBrush, state.KnightCol * cellSize + 10, knightDrawRow * cellSize + 5);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (tempStepsOfSolution.Count > 0)
            {
                stepsOfSolution.Push((KingAndKnightState)state.Clone());
                state = tempStepsOfSolution.Pop();
                step--;
                canvas.Invalidate();
                lblStep.Text = $"Step {step}/{totalSteps - 1}";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (stepsOfSolution.Count > 0)
            {
                tempStepsOfSolution.Push((KingAndKnightState)state.Clone());
                state = stepsOfSolution.Pop();
                step++;
                canvas.Invalidate();
                lblStep.Text = $"Step {step}/{totalSteps - 1}";
            }
        }

        private void cbSolverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSolverType.Text)
            {
                case "Simple Trial-Error":
                    solver = new SimpleTrialAndError();
                    break;
                case "Trial-Error with Restart and Depth-Bound (max depth: 10, rounds: 10000)":
                    solver = new TrialAndErrorWithRestart(10, 10000);
                    break;
                case "Backtrack":
                    solver = new KingAndKnightBackTrack(100, false);
                    break;
                case "Backtrack with Circle Check":
                    solver = new KingAndKnightBackTrack(40, true);
                    break;
                case "Backtrack with Circle Check (max depth: 20)":
                    solver = new KingAndKnightBackTrack(20, true);
                    break;
                case "Backtrack with Circle Check (max depth: 9)":
                    solver = new KingAndKnightBackTrack(9, true);
                    break;
                case "Depth First":
                    solver = new KingAndKnightDepthFirst(true);
                    break;
                case "Breadth First":
                    solver = new KingAndKnightBreadthFirst();
                    break;
                case "A*":
                    solver = new KingAndKnightAStar();
                    break;
                default:
                    break;
            }

            terminalNode = solver.FindTerminalNode();
            stepsOfSolution = solver.PathOfSolution(terminalNode);
            totalSteps = stepsOfSolution.Count;
            state = stepsOfSolution.Pop();
            tempStepsOfSolution.Clear();
            step = 0;
            lblStep.Text = $"Step {step}/{totalSteps - 1}";
            canvas.Invalidate();
        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }
    }
}
