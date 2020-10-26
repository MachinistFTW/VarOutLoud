using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

namespace VarOutLoud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Okuma.CMDATAPI.DataAPI.CMachine objMMachine;
        Okuma.CMDATAPI.DataAPI.CVariables objMVariables;

        public MainWindow()
        {
            InitializeComponent();

            //On window Load, run MainWindow_Loaded
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create an instance of CMachine class
                objMMachine = new Okuma.CMDATAPI.DataAPI.CMachine();
                objMMachine.Init();

                // Create an instance of CVariables class
                objMVariables = new Okuma.CMDATAPI.DataAPI.CVariables();

                WindowState = WindowState.Maximized;
            }
            catch (Exception ex)
            {

                DoError(new Exception("Error initializing API: If API is installed, there should be a round" +
                 " green icon in the task-bar that tells API version when clicked. If version is less than" +
                 " 1.9.1, contact your distributor to request a free API upgrade.", ex));
                //Environment.Exit(0);
            }
        }

        void DoError(Exception ex)
        {
            MessageBox.Show(
                "Error:  \n" + ex.Message + "\n" + ex.StackTrace,
                System.Reflection.Assembly.GetExecutingAssembly().FullName);
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        async Task TaskWatchDelay()
        {

            double state194 = objMVariables.GetCommonVariableValue(194);
            while (true)
            {
                if (state194 != objMVariables.GetCommonVariableValue(194)) 
                { 
                
                }        
            }
        }

        private void GetPrams()
        { 
        
        }

        private void btn_ReadCV_Click(object sender, RoutedEventArgs e)
        {
            int i195 = 195;
            int i196 = 196;
            int i197 = 197;

            double value195 = 1;
            double value196 = 1;
            double value197 = 1;

            try
            {
                value195 = objMVariables.GetCommonVariableValue(i195);
                value196 = objMVariables.GetCommonVariableValue(i196);
                value197 = objMVariables.GetCommonVariableValue(i197);

            }
            catch (Exception ex)
            {
                DoError(new Exception(String.Format("Error Reading Common Variable {0}.", i195), ex));
            }

            txt_VarOut1.Text = value195.ToString();
            txt_VarOut2.Text = value196.ToString();
            txt_VarOut3.Text = value197.ToString();



        }
        
    }
}
