#region Header

// Main.cs: Defines the main windows-form of KnightsTour
// Copyright© 2004-2021 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using ArdeshirV.Tools;
using ArdeshirV.Forms;
using System.Windows.Forms;
using ArdeshirV.Applications.KnightsTour.Properties;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Applications.KnightsTour
{
    public partial class FormMain : FormBase
    {
        #region Variables
        
        const string _stringEmail = "ArdeshirV@protonmail.com";
        const string _stringWebsite = "https://ArdeshirV.github.io/KnightsTour/";

        #endregion
        //-------------------------------------------------------------------------------
        #region Constructor

        public FormMain(string[] args)
        {
            InitializeComponent();
            m_btnSolveStepByStep.Tag = true;
            SplashImage = Resources.KnightOfChess;
            StartPosition = FormStartPosition.CenterScreen;
            m_lstAngels_SelectedIndexChanged(m_lstAngels, null);
        }

        #endregion
        //-----------------------------------------------------------------------------------------
        #region Event Handlers

        private void m_cmbFirstCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFirstCell(m_cmbFirstCell.SelectedIndex);
        }

        private void m_lstAngels_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_cmbFirstCell.Items.Clear();
            OnListChanged(m_lstAngels.SelectedIndex);
            m_cmbFirstCell.Items.AddRange(GetFirstCells());
            ChangeFirstCell(m_cmbFirstCell.SelectedIndex = 0);
            m_picTopSide.Image = m_imgList.Images[TopsideSelector((string)m_lstAngels.SelectedItem)];
        }

        private void m_btnSolveStepByStep_Click(object sender, EventArgs e)
        {
            bool l_blnIsSolve = (bool)m_btnSolveStepByStep.Tag;

            if (l_blnIsSolve)
            {
                SolveSolution();
                m_btnSolveStepByStep.Text = "Sto&p";
            }
            else
            {
                StopSolution();
                m_btnSolveStepByStep.Text = "&Solve Step by Step";
            }

            m_btnSolveStepByStep.Tag = !l_blnIsSolve;
        }

        private void m_chbNormal_OnFinishAnimate(object sender, EventArgs e)
        {
            m_btnSolveStepByStep.Tag = true;
            m_btnSolveStepByStep.Text = "&Solve Step by Step";
        }

        private void m_chbFirst_OnFirstCellSelect(int intNewFirstCell)
        {
            ChangeFirstCell(intNewFirstCell);
            m_cmbFirstCell.SelectedIndex = intNewFirstCell;
        }
        
		void M_btnFormAboutClick(object sender, EventArgs e)
		{
			string stringAssemblyProductName = // Application.ProductName
				new AssemblyAttributeAccessors(this).AssemblyProduct;

			Donations[] donations = new Donations[] {
				new Donations( 
				stringAssemblyProductName,
				DefaultDonationList.Items)};
			
			const string stringCreditDesc = 
@"ArdeshirV is creator and developer of ""Knight's Tour""
Knight's Tour: https://ardeshirv.github.io/KnightsTour/
Github: https://github.com/ArdeshirV/KnightsTour
Email: ArdeshirV@protonmail.com";
			Credits[] credits = new Credits[] {
				new Credits(stringAssemblyProductName, new Credit[] {
				            	new Credit(
				            		"ArdeshirV",
				            		stringCreditDesc, GlobalResouces.AuthorsPhotos.ArdeshirV),
				            	new Credit("Artua.com - Knight's icon and image",
@"The 'Knight of Chess' icon(ico) and image(png) that are used in this windows-application are free for none-commercial use and are designed by Artua.com.
Copyright (c) https://Artua.com
Download: https://iconarchive.com/show/mac-icons-by-artua/Chess-icon.html", Resources.artua_logo)
				            })
			};
			
			Copyright[] copyrights = new Copyright[] {
				new Copyright(this, Resources.KnightOfChess)
			};
			
			License[] licenses = new License[] {
				new License(stringAssemblyProductName,
				            GlobalResouces.Licenses.GPLLicense,
				            GlobalResouces.Licenses.GPLLicenseLogo)
			};
			
        	FormAboutData data = new FormAboutData(this,
        	                                       copyrights,
        	                                       credits,
        	                                       licenses,
        	                                       donations,
        	                                       _stringWebsite,
        	                                       _stringEmail);
        	FormAbout.Show(data);
		}

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        //-----------------------------------------------------------------------------------------
        #region Utility Functions

        private void StopSolution()
        {
            m_chbNormal.AnimateStop();
        }

        private void SolveSolution()
        {
            m_chbNormal.ClearBoard();
            m_chbNormal.AnimateStart(m_chbSolution.GetPath());
        }

        private void ChangeFirstCell(int intFirstCell)
        {
            StopSolution();
            m_chbNormal.ClearBoard();
            m_chbFirst.SetFirstCell(intFirstCell);
            m_chbSolution.SetFirstCell(intFirstCell);
        }

        private object[] GetFirstCells()
        {
            return m_chbSolution.GetFirstCells();
        }

        private void OnListChanged(int intIndex)
        {
            if (intIndex > 0)
            {
                int l_intIndexer = 0;
                string[] l_strArrOfAngels = new string[8];

                foreach (string str in m_lstAngels.Items)
                    l_strArrOfAngels[l_intIndexer++] = str;

                for (l_intIndexer = 0; l_intIndexer < 8 - intIndex; l_intIndexer++)
                    m_lstAngels.Items[l_intIndexer] = l_strArrOfAngels[l_intIndexer + intIndex];

                for (l_intIndexer = 0; l_intIndexer < intIndex; l_intIndexer++)
                    m_lstAngels.Items[8 - intIndex + l_intIndexer] = l_strArrOfAngels[l_intIndexer];

                m_lstAngels.SelectedIndex = 0;
                m_chbFirst.RollTheCompareTableValue = intIndex;
                m_chbSolution.RollTheCompareTableValue = intIndex;
            }
        }

        private int TopsideSelector(string strItem)
        {
            int l_intResult = 0;

            switch (strItem)
            {
                case "X + 2, Y + 1":
                    l_intResult = 0;
                    break;
                case "X + 1, Y + 2":
                    l_intResult = 1;
                    break;
                case "X  - 1, Y + 2":
                    l_intResult = 2;
                    break;
                case "X  - 2, Y + 1":
                    l_intResult = 3;
                    break;
                case "X  - 2, Y  - 1":
                    l_intResult = 4;
                    break;
                case "X  - 1, Y  - 2":
                    l_intResult = 5;
                    break;
                case "X + 1, Y  - 2":
                    l_intResult = 6;
                    break;
                case "X + 2, Y  - 1":
                    l_intResult = 7;
                    break;
            }

            return l_intResult;
        }

        #endregion
    }
}
