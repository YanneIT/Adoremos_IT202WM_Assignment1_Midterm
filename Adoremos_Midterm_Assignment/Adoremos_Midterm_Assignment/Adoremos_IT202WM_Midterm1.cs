using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adoremos_Midterm_Assignment
{
    public partial class Adoremos_IT202WM_Midterm1 : Form
    {
        public Adoremos_IT202WM_Midterm1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
    
            foreach (Control ctrl in this.Controls)
            {
                // If the control is a GroupBox (Prelim, Midterm, or Finals)
                if (ctrl is GroupBox)
                {
                    // Look inside that GroupBox for more controls
                    foreach (Control child in ctrl.Controls)
                    {
                        // If it's a TextBox, wipe the text clean
                        if (child is TextBox)
                        {
                            child.Text = "";
                        }
                    }
                }

                // This part clears the "Grand Total" box if it's NOT inside a GroupBox
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }

            // Optional: Put the blinking cursor back at the very first box
            txtPre_Ass1_S.Focus();
        }
        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Declare prelimTotal in the method scope so it won't resolve to a Label field
            double prelimTotal = 0;

            try
            {
                // --- 1. CLASS PERFORMANCE (10%) ---
                // We put the TextBoxes into an array to use a FOR loop
                TextBox[] cpScores = { txtPre_Ass1_S, txtPre_Ass2_S, txtPre_SW1_S, txtPre_SW2_S, txtPre_Rec1_S, txtPre_Rec2_S };
                TextBox[] cpTotals = { txtPre_Ass1_T, txtPre_Ass2_T, txtPre_SW1_T, txtPre_SW2_T, txtPre_Rec1_T, txtPre_Rec2_T };
                double cpSum = 0;

                for (int i = 0; i < cpScores.Length; i++)
                {
                    double s = double.Parse(cpScores[i].Text);
                    double t = double.Parse(cpTotals[i].Text);

                    // --- IF Statement Validation ---
                    if (s > t || s < 0 || t <= 0)
                    {
                        MessageBox.Show("Invalid input in Class Performance row " + (i + 1));
                        return; // Stops the code if there is an error
                    }

                    // Formula: (Score / Total) * 60 + 40
                    cpSum += (s / t) * 60 + 40;
                }
                double avgCP = cpSum / 6;

                // --- 2. LABORATORY (10%) ---
                TextBox[] labScores = { txtPre_Lab1_S, txtPre_Lab2_S, txtPre_Lab3_S, txtPre_Lab4_S };
                TextBox[] labTotals = { txtPre_Lab1_T, txtPre_Lab2_T, txtPre_Lab3_T, txtPre_Lab4_T };
                double labSum = 0;

                for (int i = 0; i < labScores.Length; i++)
                {
                    double s = double.Parse(labScores[i].Text);
                    double t = double.Parse(labTotals[i].Text);

                    if (s > t) { MessageBox.Show("Lab Score cannot exceed Total"); return; }

                    labSum += (s / t) * 60 + 40;
                }
                double avgLab = labSum / 4;

                // --- 3. QUIZZES (20%) ---
                // (Repeat loop logic for Quizzes)
                double q1 = (double.Parse(txtPre_Q1_S.Text) / double.Parse(txtPre_Q1_T.Text)) * 60 + 40;
                double q2 = (double.Parse(txtPre_Q2_S.Text) / double.Parse(txtPre_Q2_T.Text)) * 60 + 40;
                double q3 = (double.Parse(txtPre_Q3_S.Text) / double.Parse(txtPre_Q3_T.Text)) * 60 + 40;
                double avgQuizzes = (q1 + q2 + q3) / 3;

                // --- 4. LAB EXAMS (20%) ---
                double le1 = (double.Parse(txtPre_LE1_S.Text) / double.Parse(txtPre_LE1_T.Text)) * 60 + 40;
                double le2 = (double.Parse(txtPre_LE2_S.Text) / double.Parse(txtPre_LE2_T.Text)) * 60 + 40;
                double avgLabExam = (le1 + le2) / 2;

                // --- 5. WRITTEN EXAM (40%) ---
                double midExam = (double.Parse(txtPre_Exam_S.Text) / double.Parse(txtPre_Exam_T.Text)) * 60 + 40;

                // --- FINAL PRELIM TOTAL FORMULA ---
                // Assign to the method-scoped variable (do not redeclare)
                prelimTotal = (avgCP * 0.10) + (avgLab * 0.10) + (avgQuizzes * 0.20) + (avgLabExam * 0.20) + (midExam * 0.40);

                // Display result
                txtPre_WeightedGrade.Text = prelimTotal.ToString("F2");

            }
            // --- TRY-CATCH (Exception Handling) ---
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers in all fields.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Total score cannot be zero.");
            }
            // --- STEP 1: MIDTERM CLASS PERFORMANCE (10%) ---
            // Using arrays and a loop to keep it clean
            TextBox[] midCpScores = { txtMid_Ass1_S, txtMid_Ass2_S, txtMid_SW1_S, txtMid_SW2_S, txtMid_Rec1_S, txtMid_Rec2_S };
            TextBox[] midCpTotals = { txtMid_Ass1_T, txtMid_Ass2_T, txtMid_SW1_T, txtMid_SW2_T, txtMid_Rec1_T, txtMid_Rec2_T };
            double midCpSum = 0;

            for (int i = 0; i < midCpScores.Length; i++)
            {
                double s = double.Parse(midCpScores[i].Text);
                double t = double.Parse(midCpTotals[i].Text);

                // Validation: Score cannot be higher than Total
                if (s > t)
                {
                    MessageBox.Show("Midterm Class Performance: Score cannot be greater than Total in row " + (i + 1));
                    return;
                }
                midCpSum += (s / t) * 60 + 40;
            }
            double midAvgCP = midCpSum / 6;

            // --- STEP 2: MIDTERM LABORATORY (10%) ---
            TextBox[] midLabScores = { txtMid_Lab1_S, txtMid_Lab2_S, txtMid_Lab3_S, txtMid_Lab4_S };
            TextBox[] midLabTotals = { txtMid_Lab1_T, txtMid_Lab2_T, txtMid_Lab3_T, txtMid_Lab4_T };
            double midLabSum = 0;

            for (int i = 0; i < midLabScores.Length; i++)
            {
                midLabSum += (double.Parse(midLabScores[i].Text) / double.Parse(midLabTotals[i].Text)) * 60 + 40;
            }
            double midAvgLab = midLabSum / 4;

            // --- STEP 3: MIDTERM QUIZZES (20%) ---
            double mq1 = (double.Parse(txtMid_Q1_S.Text) / double.Parse(txtMid_Q1_T.Text)) * 60 + 40;
            double mq2 = (double.Parse(txtMid_Q2_S.Text) / double.Parse(txtMid_Q2_T.Text)) * 60 + 40;
            double mq3 = (double.Parse(txtMid_Q3_S.Text) / double.Parse(txtMid_Q3_T.Text)) * 60 + 40;
            double midAvgQuizzes = (mq1 + mq2 + mq3) / 3;

            // --- STEP 4: MIDTERM LAB EXAMS (20%) ---
            double mle1 = (double.Parse(txtMid_LE1_S.Text) / double.Parse(txtMid_LE1_T.Text)) * 60 + 40;
            double mle2 = (double.Parse(txtMid_LE2_S.Text) / double.Parse(txtMid_LE2_T.Text)) * 60 + 40;
            double midAvgLabExam = (mle1 + mle2) / 2;

            // --- STEP 5: MIDTERM WRITTEN EXAM (40%) ---
            double midWrittenExam = (double.Parse(txtMid_Exam_S.Text) / double.Parse(txtMid_Exam_T.Text)) * 60 + 40;

            // --- FINAL MIDTERM TOTAL FORMULA ---
            double midtermTotal = (midAvgCP * 0.10) + (midAvgLab * 0.10) + (midAvgQuizzes * 0.20) + (midAvgLabExam * 0.20) + (midWrittenExam * 0.40);

            // Display Midterm result
            txtMid_WeightedGrade.Text = midtermTotal.ToString("F2");

            // --- STEP 1: FINALS CLASS PERFORMANCE (5% - NOTE THE CHANGE!) ---
            TextBox[] finCpScores = { txtFin_Ass1_S, txtFin_Ass2_S, txtFin_SW1_S, txtFin_SW2_S, txtFin_Rec1_S, txtFin_Rec2_S };
            TextBox[] finCpTotals = { txtFin_Ass1_T, txtFin_Ass2_T, txtFin_SW1_T, txtFin_SW2_T, txtFin_Rec1_T, txtFin_Rec2_T };
            double finCpSum = 0;

            for (int i = 0; i < finCpScores.Length; i++)
            {
                finCpSum += (double.Parse(finCpScores[i].Text) / double.Parse(finCpTotals[i].Text)) * 60 + 40;
            }
            double finAvgCP = finCpSum / 6;

            // --- STEP 2: FINALS LABORATORY (10%) ---
            TextBox[] finLabScores = { txtFin_Lab1_S, txtFin_Lab2_S, txtFin_Lab3_S, txtFin_Lab4_S };
            TextBox[] finLabTotals = { txtFin_Lab1_T, txtFin_Lab2_T, txtFin_Lab3_T, txtFin_Lab4_T };
            double finLabSum = 0;

            for (int i = 0; i < finLabScores.Length; i++)
            {
                finLabSum += (double.Parse(finLabScores[i].Text) / double.Parse(finLabTotals[i].Text)) * 60 + 40;
            }
            double finAvgLab = finLabSum / 4;

            // --- STEP 3: FINALS QUIZZES (20%) ---
            double fq1 = (double.Parse(txtFin_Q1_S.Text) / double.Parse(txtFin_Q1_T.Text)) * 60 + 40;
            double fq2 = (double.Parse(txtFin_Q2_S.Text) / double.Parse(txtFin_Q2_T.Text)) * 60 + 40;
            double fq3 = (double.Parse(txtFin_Q3_S.Text) / double.Parse(txtFin_Q3_T.Text)) * 60 + 40;
            double finAvgQuizzes = (fq1 + fq2 + fq3) / 3;

            // --- STEP 4: FINAL PROJECT (25%) ---
            // Formula: (Score / Total) * 60 + 40
            double projManu = (double.Parse(txtFin_ProjManu_S.Text) / double.Parse(txtFin_ProjManu_T.Text)) * 60 + 40;
            double projPres = (double.Parse(txtFin_ProjPres_S.Text) / double.Parse(txtFin_ProjPres_T.Text)) * 60 + 40;
            double avgProject = (projManu + projPres) / 2;

            // --- STEP 5: FINAL WRITTEN EXAM (40%) ---
            double finalExam = (double.Parse(txtFin_Exam_S.Text) / double.Parse(txtFin_Exam_T.Text)) * 60 + 40;

            // --- FINAL FINALS TOTAL FORMULA ---
            // Note: Class performance is * 0.05 and Project is * 0.25
            double finalsTotal = (finAvgCP * 0.05) + (finAvgLab * 0.10) + (finAvgQuizzes * 0.20) + (avgProject * 0.25) + (finalExam * 0.40);

            // Display Finals result
            txtFin_WeightedGrade.Text = finalsTotal.ToString("F2");

            // --- FINAL GRADE COMPUTATION (33% each) ---
            double grandTotal = (prelimTotal * 0.33) + (midtermTotal * 0.33) + (finalsTotal * 0.33);

            // Display the big final result
            txtGrandTotalDisplay.Text = grandTotal.ToString("F2");

        }

        private void button3_Click(object sender, EventArgs e)
        {
   
            Application.Exit();
        }
    }
    
}
