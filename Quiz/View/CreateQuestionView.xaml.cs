using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for CreateQuestionView.xaml
    /// </summary>
    public partial class CreateQuestionView : UserControl
    {
        public CreateQuestionView()
        {
            InitializeComponent();
            answerComboBox.Items.Add("A");
            answerComboBox.Items.Add("B");
            answerComboBox.Items.Add("C");
            answerComboBox.Items.Add("D");
        }
    }
}
