#region Header

using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Applications.KnightsTour
{
    #region Delegates

    public delegate void FirstChanged(int intNewFirstCell);

    #endregion
    //-----------------------------------------------------------------------------------
    public partial class Chess_Board : UserControl
    {
        #region Variables

        Position[] m_posArr;
        private int m_intCounter = 1;
        Timer m_timMain = new Timer();
        private volatile bool m_blnNotAllow;
        private Board m_brdEnvironment = new Board();

        #endregion
        //-------------------------------------------------------------------------------
        #region Constructor

        public Chess_Board()
        {
            InitializeComponent();
            m_timMain.Interval = 200;
            DataGridViewInitialize();
            m_brdEnvironment.SetMode(0);
            m_timMain.Tick += new EventHandler(OnTimerTicker);
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Events

        public event EventHandler OnFinishAnimate;
        public event FirstChanged OnFirstCellSelect;

        #endregion
        //-------------------------------------------------------------------------------
        #region Properties

        [
            Browsable(true),
            Description("Choose how to show chess board.")
        ]
        public BoardMode BoardMode
        {
            set
            {
                m_brdEnvironment.SetMode(value);
                m_grdEnvironment.Invalidate();
            }
            get
            {
                return m_brdEnvironment.GetMode();
            }
        }

        [
            Browsable(false)
        ]
        public int RollTheCompareTableValue
        {
            set
            {
                m_brdEnvironment.RollTheCompareTable(value);
                m_grdEnvironment.Invalidate();
            }
        }
        
        #endregion
        //-------------------------------------------------------------------------------
        #region Event Handlers

        private void m_grdEnvironment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            m_brdEnvironment.DrawCell(e.Graphics, (sender as Control).Font,
                e.CellBounds, e.ColumnIndex, e.RowIndex);
        }

        private void m_grdEnvironment_Scroll(object sender, ScrollEventArgs e)
        {
            m_grdEnvironment.Invalidate();
        }

        private void m_grdEnvironment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BoardMode == BoardMode.bmWhichCellCanBeFirst && m_brdEnvironment[e.ColumnIndex, e.RowIndex] != 0)
            {
                int l_intFirstCell = m_brdEnvironment[e.ColumnIndex, e.RowIndex] - 1;
                SetFirstCell(l_intFirstCell);

                if (OnFirstCellSelect != null)
                    OnFirstCellSelect(l_intFirstCell);
            }
        }

        private void OnTimerTicker(object sender, EventArgs e)
        {
            if (m_blnNotAllow || m_intCounter > m_posArr.Length - 1)
            {
                m_timMain.Stop();

                if (OnFinishAnimate != null)
                    OnFinishAnimate(this, null);

                return;
            }

            m_brdEnvironment[m_posArr[m_intCounter].X, m_posArr[m_intCounter].Y] = m_intCounter + 1;
            m_grdEnvironment.Invalidate();
            m_intCounter++;
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Access Methods

        public void AnimateStop()
        {
            m_blnNotAllow = true;
        }

        public void AnimateStart(Position[] posArrPath)
        {
            m_intCounter = 0;
            m_posArr = posArrPath;
            m_blnNotAllow = false;
            m_timMain.Start();
        }

        public void SetFirstCell(int value)
        {
            m_brdEnvironment.SetFirstCell(value);
            m_grdEnvironment.Invalidate();
        }

        public void ClearBoard()
        {
            m_brdEnvironment.SetMode(BoardMode.bmNormalChessBoard);
            m_grdEnvironment.Invalidate();
        }

        public object[] GetFirstCells()
        {
            return m_brdEnvironment.GetFirstCells();
        }

        public Position[] GetPath()
        {
            return m_brdEnvironment.GetPath();
        }

        public void RollTheCompareTable(int intRollPosition)
        {
            m_brdEnvironment.RollTheCompareTable(intRollPosition);
            m_grdEnvironment.Invalidate();
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Utility Functions

        private void DataGridViewInitialize()
        {
            m_grdEnvironment.Rows.Clear();
            m_grdEnvironment.Columns.Clear();

            for (int l_intIndexer = 0; l_intIndexer < 8; l_intIndexer++)
                m_grdEnvironment.Columns.Add(l_intIndexer.ToString(), l_intIndexer.ToString());

            m_grdEnvironment.Rows.Add(8 - 1);
        }

        #endregion
    }
}
