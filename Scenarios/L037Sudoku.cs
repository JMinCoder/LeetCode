using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios
{
    class Sudoku
    {
        private static readonly int N = 9;
        List<int>[][] possibleValues = new List<int>[N][];
        int[][] board = new int[N][];
        int count = 0;

        // Assume empty values to be 0
        public Sudoku(int[][] board)
        {
            this.Copy(board);
        }

        public static void Test()
        {
            var board = new int[9][]
            {
                new int[] {0,0,8,0,1,0,0,0,9},
                new int[] {6,0,1,0,9,0,3,2,0},
                new int[] {0,4,0,0,3,7,0,0,5},
                new int[] {0,3,5,0,0,8,2,0,0},
                new int[] {0,0,2,6,5,0,8,0,0},
                new int[] {0,0,4,0,0,1,7,5,0},
                new int[] {5,0,0,3,4,0,0,8,0},
                new int[] {0,9,7,0,8,0,5,0,6},
                new int[] {1,0,0,0,6,0,9,0,0}
            };

            var s = new Sudoku(board);
            s.Solve();
            s.Print();
        }

        private void Copy(int[][] b)
        {
            for (var i = 0; i < N; i++)
            {
                this.board[i] = new int[N];
                this.possibleValues[i] = new List<int>[N];
                for (var j = 0; j < N; j++)
                {
                    this.possibleValues[i][j] = new List<int>();
                    for (var k = 1; k <= N; k++) this.possibleValues[i][j].Add(k);
                }
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    this.board[i][j] = b[i][j];
                    if (board[i][j] != 0)
                    {
                        AdjustPossibleValues(i, j);
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }

        private void AdjustPossibleValues(int r, int c)
        {
            // Col
            for (var i = 0; i < N; i++)
            {
                if (board[i][c] == 0 && this.possibleValues[i][c].Contains(board[r][c]))
                    this.possibleValues[i][c].Remove(board[r][c]);
            }

            // row
            for (var j = 0; j < N; j++)
            {
                if (board[r][j] == 0 && this.possibleValues[r][j].Contains(board[r][c]))
                    this.possibleValues[r][j].Remove(board[r][c]);
            }

            // box
            for (var i = r / 3; i < r / 3 + 3; i++)
            {
                for (var j = c / 3; j < c / 3 + 3; j++)
                {
                    if (board[i][j] == 0 && this.possibleValues[i][j].Contains(board[r][c]))
                    {
                        this.possibleValues[i][j].Remove(board[r][c]);
                    }
                }
            }
        }
        public void Solve()
        {
            int oldCount = this.count;
            do
            {
                oldCount = this.count;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (board[i][j] == 0)
                        {
                            var lst = possibleValues[i][j];
                            if (lst.Count == 1)
                            {
                                board[i][j] = lst[0];
                                count--;
                                Propagate(i, j);
                            }
                        }
                    }
                }
            } while (oldCount != count) ;

            if (count == 0) return;

            this.Print();
            BackTrack();            
        }

        private void Propagate(int r, int c)
        {
            // Col
            for (var i = 0; i < N; i++)
            {
                if (board[i][c] == 0)
                {
                    if (this.possibleValues[i][c].Contains(board[r][c]))
                        this.possibleValues[i][c].Remove(board[r][c]);

                    if (this.possibleValues[i][c].Count == 1)
                    {
                        this.board[i][c] = this.possibleValues[i][c][0];
                        this.count--;
                        Propagate(i,c);
                    }
                }
            }

            // row
            for (var j = 0; j < N; j++)
            {
                if (board[r][j] == 0)
                {
                    if (this.possibleValues[r][j].Contains(board[r][c]))
                        this.possibleValues[r][j].Remove(board[r][c]);

                    if (this.possibleValues[r][j].Count == 1)
                    {
                        this.board[r][j] = this.possibleValues[r][j][0];
                        this.count--;
                        Propagate(r, j);
                    }
                }
            }

            // box
            for (var i = r / 3; i < r / 3 + 3; i++)
            {
                for (var j = c / 3; j < c / 3 + 3; j++)
                {
                    if (board[i][j] == 0)
                    {
                        if (this.possibleValues[i][j].Contains(board[r][c]))
                            this.possibleValues[i][j].Remove(board[r][c]);

                        if (this.possibleValues[i][j].Count == 1)
                        {
                            this.board[i][j] = this.possibleValues[r][j][0];
                            this.count--;
                            Propagate(i, j);
                        }
                    }
                }
            }
        }

        private bool BackTrack()
        {
            if (this.count == 0) return true;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i][j] == 0)
                    {
                        var lst = possibleValues[i][j];
                        for (var k = 0; k < lst.Count; k++)
                        {
                            if (IsValid(i, j, lst[k]))
                            {
                                board[i][j] = lst[k];
                                this.count--;
                                if (BackTrack()) return true;
                                this.count++;
                                board[i][j] = 0;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private bool IsValid(int r, int c, int val)
        {
            for (var i = 0; i < N; i++)
            {
                if (board[i][c] == val) return false;
            }

            // row
            for (var j = 0; j < N; j++)
            {
                if (board[r][j] == val) return false;
            }

            // box
            for (var i = r / 3; i < r / 3 + 3; i++)
            {
                for (var j = c / 3; j < c / 3 + 3; j++)
                {
                    if (board[i][j] == val) return false;
                }
            }

            return true;
        }

        public void Print()
        {
            for (var i=0;i<N;i++)
            {
                for (var j=0;j<N;j++)
                {
                    Console.Write("{0} ", this.board[i][j]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("===============================");
        }
    }
}
