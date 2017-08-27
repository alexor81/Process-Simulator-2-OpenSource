// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Drawing;
using System.Windows.Forms;

namespace Utils.DialogForms
{
    public partial class QuestionForm : Form
    {
        private static QuestionForm  mQuestionBoxForm;

        public static DialogResult      askQuestion(string aQuestion, IWin32Window aOwner)
        {
            if (mQuestionBoxForm == null)
            {
                mQuestionBoxForm = new QuestionForm(aQuestion);
            }
            else
            {
                mQuestionBoxForm.richTextBox_Question.Text = aQuestion;
            }

            return mQuestionBoxForm.ShowDialog(aOwner);
        }

        private                         QuestionForm(string aQuestion)
        {
            InitializeComponent();
            richTextBox_Question.Text = aQuestion;
        }

        private void                    QuestionBoxForm_Paint(object aSender, PaintEventArgs aEventArgs)
        {
            Graphics lGr = this.CreateGraphics();
            lGr.DrawIcon(SystemIcons.Question, 10, 10);
        }

        private void                    QuestionForm_Load(object aSender, System.EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
