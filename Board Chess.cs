#region Header

using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Applications.KnightsTour
{
    #region Enum Board Mode

    public enum BoardMode
    {
        bmNormalChessBoard,
        bmShowCellWeights,
        bmWhichCellCanBeFirst,
        bmKnightsTourSolution
    }

    #endregion
    //-----------------------------------------------------------------------------------
    #region Struct Position

    public struct Position
    {
        private int m_intX, m_intY;

        public Position(int intX, int intY)
        {
            m_intX = intX;
            m_intY = intY;
        }

        public override string ToString()
        {
            return "[" + (m_intX + 1) + ", " + (m_intY + 1) + "]";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + m_intX * 2 - m_intY;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static Position operator+(Position posLeft, Position posRight)
        {
            return new Position(posLeft.m_intX + posRight.m_intX, posLeft.m_intY + posRight.m_intY);
        }

        public static bool operator !=(Position posLeft, Position posRight)
        {
            return (posLeft.m_intX != posRight.m_intX) || (posLeft.m_intY != posRight.m_intY);
        }

        public static bool operator ==(Position posLeft, Position posRight)
        {
            return (posLeft.m_intX == posRight.m_intX) && (posLeft.m_intY == posRight.m_intY);
        }

        public int X
        {
            get
            {
                return (byte)m_intX;
            }
        }

        public int Y
        {
            get
            {
                return (byte)m_intY;
            }
        }
    }

    #endregion
    //-----------------------------------------------------------------------------------
    public class Board
    {
        #region Variabe

        private const byte bytAdd2Add1 = 1,
                           bytAdd1Add2 = 2,
                           bytSub1Add2 = 4,
                           bytSub2Add1 = 8,
                           bytSub2Sub1 = 16,
                           bytSub1Sub2 = 32,
                           bytAdd1Sub2 = 64,
                           bytAdd2Sub1 = 128;

        private int m_intWhichAngel = 1;
        private Position m_posFirstCell;
        private byte[] bytArrAngels = new byte[8];
        byte[, ,] m_bytEnvironment = new byte[8, 8, 2];
        private Position[] posArrIncrease = new Position[8];
        private List<Position> m_lstPath = new List<Position>();
        private BoardMode m_bmStatus = BoardMode.bmNormalChessBoard;
        public const int intMaxY = 7, intMinY = 0, intMaxX = 7, intMinX = 0;

        #endregion
        //-------------------------------------------------------------------------------
        #region Events

        #endregion
        //-------------------------------------------------------------------------------
        #region Constructor

        public Board()
        {
            bytArrAngels[0] = 1;
            bytArrAngels[1] = 2;
            bytArrAngels[2] = 4;
            bytArrAngels[3] = 8;
            bytArrAngels[4] = 16;
            bytArrAngels[5] = 32;
            bytArrAngels[6] = 64;
            bytArrAngels[7] = 128;

            posArrIncrease[0] = new Position(+2, +1);
            posArrIncrease[1] = new Position(+1, +2);
            posArrIncrease[2] = new Position(-1, +2);
            posArrIncrease[3] = new Position(-2, +1);
            posArrIncrease[4] = new Position(-2, -1);
            posArrIncrease[5] = new Position(-1, -2);
            posArrIncrease[6] = new Position(+1, -2);
            posArrIncrease[7] = new Position(+2, -1);

            m_posFirstCell = FindTheFirstPossibleCell();
            NormalChessBoard();
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Indexer

        public int this[int X, int Y]
        {
            set
            {
                m_bytEnvironment[X, Y, 1] = (byte)(m_bytEnvironment[X, Y, 1] & 128);
                m_bytEnvironment[X, Y, 1] |= (byte)value;
            }
            get
            {
                return m_bytEnvironment[X, Y, 1] & 127;
            }
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Utility functions

        public bool SetFirstCell(int intFirst)
        {
            int l_intCounter = 0;
            bool l_blnDid = false;
            Position l_posResult = new Position(0, 0);

            for (int l_intX = 0; l_intX <= intMaxX; l_intX++)
                for (int l_intY = 0; l_intY <= intMaxY; l_intY++)
                {
                    l_posResult = new Position(l_intX, l_intY);

                    if (Play(l_posResult) && l_intCounter++ == intFirst)
                    {
                        l_blnDid = true;
                        m_posFirstCell = l_posResult;
                        goto outer;
                    }
                }
        outer:
            SetMode(m_bmStatus);

            return l_blnDid;
        }

        public object[] GetFirstCells()
        {
            int l_intCounter = 1;
            Position l_posCurrent;
            List<object> l_posArr = new List<object>();

            for (int l_intX = 0; l_intX <= intMaxX; l_intX++)
                for (int l_intY = 0; l_intY <= intMaxY; l_intY++)
                {
                    l_posCurrent = new Position(l_intX, l_intY);

                    if (Play(l_posCurrent))
                        l_posArr.Add(l_intCounter++.ToString() + ": " + l_posCurrent.ToString());
                }

            SetMode(m_bmStatus);

            return l_posArr.ToArray();
        }

        private bool Play(Position posFirst)
        {
            InitBoard();
            byte l_bytTemp;
            m_lstPath.Clear();
            bool l_blnNotChecked;
            Position l_posCurrent, l_posNew, l_posResult;
            int l_intMinNum, l_intNewNum, l_intMax = (int)Math.Pow(intMaxX + 1, 2);

            l_posCurrent = l_posResult = posFirst;
            SetChecked(l_posCurrent);

            for (int l_intIndexer = 1; l_intIndexer <= l_intMax; l_intIndexer++)
            {
                l_intMinNum = intMaxX + 1;

                for (int l_intIndexer1 = 0; l_intIndexer1 < 8 - m_intWhichAngel; l_intIndexer1++)
                {
                    l_bytTemp = bytArrAngels[l_intIndexer1 + m_intWhichAngel];

                    if ((m_bytEnvironment[l_posCurrent.X, l_posCurrent.Y, 0] & l_bytTemp) != 0)
                    {
                        l_posNew = l_posCurrent + posArrIncrease[(int)Math.Log(l_bytTemp, 2)];
                        l_intNewNum = m_bytEnvironment[l_posNew.X, l_posNew.Y, 1] & 127;
                        l_blnNotChecked = (m_bytEnvironment[l_posNew.X, l_posNew.Y, 1] & 128) == 0;

                        if (l_blnNotChecked && l_intNewNum <= l_intMinNum)
                        {
                            l_posResult = l_posNew;
                            l_intMinNum = l_intNewNum;
                        }
                    }
                }

                for (int l_intIndexer2 = 0; l_intIndexer2 < m_intWhichAngel; l_intIndexer2++)
                {
                    l_bytTemp = bytArrAngels[l_intIndexer2];

                    if ((m_bytEnvironment[l_posCurrent.X, l_posCurrent.Y, 0] & l_bytTemp) != 0)
                    {
                        l_posNew = l_posCurrent + posArrIncrease[(int)Math.Log(l_bytTemp, 2)];
                        l_intNewNum = m_bytEnvironment[l_posNew.X, l_posNew.Y, 1] & 127;
                        l_blnNotChecked = (m_bytEnvironment[l_posNew.X, l_posNew.Y, 1] & 128) == 0;

                        if (l_blnNotChecked && l_intNewNum <= l_intMinNum)
                        {
                            l_posResult = l_posNew;
                            l_intMinNum = l_intNewNum;
                        }
                    }
                }

                if (l_posCurrent != l_posResult)
                {
                    SetChecked(l_posResult);
                    l_posCurrent = l_posResult;
                }
            }

            for (int l_intX = 0; l_intX <= intMaxX; l_intX++)
                for (int l_intY = 0; l_intY <= intMaxY; l_intY++)
                    m_bytEnvironment[l_intX, l_intY, 1] = 0;

            byte l_bytCounter = 1;

            foreach(Position pos in m_lstPath)
                m_bytEnvironment[pos.X, pos.Y, 1] = l_bytCounter++;

            return (m_lstPath.Count == 64);
        }

        private void InitBoard()
        {
            byte l_bytPaths;

            for (int l_intIndexerX = 0; l_intIndexerX <= intMaxX; l_intIndexerX++)
                for (int l_intIndexerY = 0; l_intIndexerY <= intMaxY; l_intIndexerY++)
                {
                    m_bytEnvironment[l_intIndexerX, l_intIndexerY, 1] =
                        GetPaths(l_intIndexerX, l_intIndexerY, out l_bytPaths);
                    m_bytEnvironment[l_intIndexerX, l_intIndexerY, 0] = l_bytPaths;
                }
        }

        private void NormalChessBoard()
        {
            Play();

            for (int l_intX = 0; l_intX <= intMaxX; l_intX++)
                for (int l_intY = 0; l_intY <= intMaxY; l_intY++)
                    m_bytEnvironment[l_intX, l_intY, 1] = 0;
        }

        private void WhichCellCanBeFirst()
        {
            byte l_bytCounter = 1;
            const byte l_bytFalse = 0;
            byte[, ,] l_bytEnvTemp = (byte[, ,])m_bytEnvironment.Clone();

            for (int l_intX = 0; l_intX <= intMaxX; l_intX++)
                for (int l_intY = 0; l_intY <= intMaxY; l_intY++)
                    l_bytEnvTemp[l_intX, l_intY, 1] =
                        (Play(new Position(l_intX, l_intY))) ? l_bytCounter++ : l_bytFalse;

            m_bytEnvironment = l_bytEnvTemp;
        }

        private void SetChecked(Position pos)
        {
            m_bytEnvironment[pos.X, pos.Y, 1] |= 128;
            m_lstPath.Add(new Position(pos.X, pos.Y));
        }

        private Position FindTheFirstPossibleCell()
        {
            Position l_posResult = new Position(0, 0);

            for (int l_intX = 0; l_intX <= intMaxX; l_intX++)
                for (int l_intY = 0; l_intY <= intMaxY; l_intY++)
                {
                    l_posResult = new Position(l_intX, l_intY);

                    if (Play(l_posResult))
                        goto outer;
                }
        outer:
            return l_posResult;
        }

        private bool Play()
        {
            return Play(m_posFirstCell);
        }

        public void RefreshCurrentMode()
        {
            SetMode(m_bmStatus);
        }

        public void RollTheCompareTable(int intRollPosition)
        {
            if (intRollPosition > 0 && intRollPosition < 8)
            {
                if (m_intWhichAngel >= intRollPosition)
                    m_intWhichAngel -= intRollPosition;
                else
                    m_intWhichAngel += 8 - intRollPosition;

                SetMode(m_bmStatus);
            }
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Very Utility Functions!

        public Position[] GetPath()
        {
            return m_lstPath.ToArray();
        }

        private byte GetPaths(int intX, int intY, out byte bytPaths)
        {
            if (intX < intMinX || intY < intMinY || intX > intMaxX || intY > intMaxY)
                throw new Exception("Room position is out of environment range.");

            bytPaths = 0;
            int l_intXAdd1 = intX + 1;
            int l_intXAdd2 = intX + 2;
            int l_intXSub1 = intX - 1;
            int l_intXSub2 = intX - 2;
            int l_intYAdd1 = intY + 1;
            int l_intYAdd2 = intY + 2;
            int l_intYSub1 = intY - 1;
            int l_intYSub2 = intY - 2;
            byte l_bytResultCounter = 0;

            if (l_intXAdd1 <= intMaxX && l_intYAdd2 <= intMaxY)
            {
                bytPaths |= bytAdd1Add2;
                l_bytResultCounter++;
            }

            if (l_intXAdd1 <= intMaxX && l_intYSub2 >= intMinY)
            {
                bytPaths |= bytAdd1Sub2;
                l_bytResultCounter++;
            }

            if (l_intXSub1 >= intMinX && l_intYAdd2 <= intMaxY)
            {
                bytPaths |= bytSub1Add2;
                l_bytResultCounter++;
            }

            if (l_intXSub1 >= intMinX && l_intYSub2 >= intMinY)
            {
                bytPaths |= bytSub1Sub2;
                l_bytResultCounter++;
            }

            if (l_intXAdd2 <= intMaxX && l_intYAdd1 <= intMaxY)
            {
                bytPaths |= bytAdd2Add1;
                l_bytResultCounter++;
            }

            if (l_intXAdd2 <= intMaxX && l_intYSub1 >= intMinY)
            {
                bytPaths |= bytAdd2Sub1;
                l_bytResultCounter++;
            }

            if (l_intXSub2 >= intMinX && l_intYAdd1 <= intMaxY)
            {
                bytPaths |= bytSub2Add1;
                l_bytResultCounter++;
            }

            if (l_intXSub2 >= intMinX && l_intYSub1 >= intMinY)
            {
                bytPaths |= bytSub2Sub1;
                l_bytResultCounter++;
            }

            return l_bytResultCounter;
        }

        public BoardMode GetMode()
        {
            return m_bmStatus;
        }

        public void SetMode(BoardMode bmStatus)
        {
            switch (bmStatus)
            {
                case BoardMode.bmNormalChessBoard:
                    NormalChessBoard();
                    break;
                case BoardMode.bmShowCellWeights:
                    InitBoard();
                    break;
                case BoardMode.bmKnightsTourSolution:
                    Play();
                    break;
                case BoardMode.bmWhichCellCanBeFirst:
                    WhichCellCanBeFirst();
                    break;
                default:
                    throw new Exception("Undefined status occured in status switch.");
            }

            m_bmStatus = bmStatus;
        }

        public void DrawCell(Graphics grpGraphics, Font fntFont, Rectangle rctBounds, int intColumn, int intRow)
        {
            switch (m_bmStatus)
            {
                case BoardMode.bmNormalChessBoard:
                    if ((intColumn % 2 ^ intRow % 2) == 0)
                    {
                        grpGraphics.FillRectangle(Brushes.Black, rctBounds);

                        if (this[intColumn, intRow] != 0)
                            grpGraphics.DrawString(this[intColumn, intRow].ToString(),
                                fntFont, Brushes.LimeGreen, rctBounds.X + 3, rctBounds.Y + 4);
                    }
                    else
                    {
                        grpGraphics.FillRectangle(Brushes.White, rctBounds);

                        if (this[intColumn, intRow] != 0)
                            grpGraphics.DrawString(this[intColumn, intRow].ToString(),
                                fntFont, Brushes.Firebrick, rctBounds.X + 3, rctBounds.Y + 4);
                    }
                    break;
                case BoardMode.bmShowCellWeights:
                    switch (this[intColumn, intRow])
                    {
                        case 2:
                            grpGraphics.FillRectangle(Brushes.Blue, rctBounds);
                            break;
                        case 3:
                            grpGraphics.FillRectangle(Brushes.Green, rctBounds);
                            break;
                        case 4:
                            grpGraphics.FillRectangle(Brushes.Magenta, rctBounds);
                            break;
                        case 6:
                            grpGraphics.FillRectangle(Brushes.CornflowerBlue, rctBounds);
                            break;
                        case 8:
                            grpGraphics.FillRectangle(Brushes.Brown, rctBounds);
                            break;
                        default:
                            grpGraphics.FillRectangle(Brushes.Firebrick, rctBounds);
                            break;
                    }

                    grpGraphics.DrawString(this[intColumn, intRow].ToString(),
                        fntFont, Brushes.White, rctBounds.X + 5, rctBounds.Y + 4);

                    break;
                case BoardMode.bmKnightsTourSolution:
                    if (this[intColumn, intRow] == 0)
                    {
                        grpGraphics.FillRectangle(Brushes.Firebrick, rctBounds);
                        grpGraphics.DrawString("X", fntFont, Brushes.White, rctBounds.X + 5, rctBounds.Y + 4);
                    }
                    else
                    {
                        int l_intNum = (int)(this[intColumn, intRow] * 2);
                        Brush l_brsNormal = new SolidBrush(Color.FromArgb(0, l_intNum, 0));

                        grpGraphics.FillRectangle(l_brsNormal, rctBounds);

                        grpGraphics.DrawString(this[intColumn, intRow].ToString(),
                            fntFont, Brushes.Gold, rctBounds.X + 3, rctBounds.Y + 4);

                        l_brsNormal.Dispose();
                    }

                    break;
                case BoardMode.bmWhichCellCanBeFirst:
                    if (this[intColumn, intRow] == 0)
                    {
                        grpGraphics.FillRectangle(Brushes.Firebrick, rctBounds);
                        grpGraphics.DrawString("X", fntFont, Brushes.White, rctBounds.X + 5, rctBounds.Y + 4);
                    }
                    else if (m_posFirstCell.X == intColumn && m_posFirstCell.Y == intRow)
                    {
                        grpGraphics.FillRectangle(Brushes.Green, rctBounds);
                        grpGraphics.DrawString(this[intColumn, intRow].ToString(),
                            fntFont, Brushes.White, rctBounds.X + 5, rctBounds.Y + 4);
                    }
                    else
                    {
                        grpGraphics.FillRectangle(Brushes.DarkBlue, rctBounds);
                        grpGraphics.DrawString(this[intColumn, intRow].ToString(),
                            fntFont, Brushes.White, rctBounds.X + 5, rctBounds.Y + 4);
                    }

                    break;
                default:
                    throw new Exception("Undefined status occured in status switch.");
            }

            grpGraphics.DrawRectangle(Pens.Lime, rctBounds);
        }

        #endregion
    }
}










