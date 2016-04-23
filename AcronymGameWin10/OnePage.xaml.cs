using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AcronymGameWin10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OnePage : Page
    {
        public OnePage()
        {
            this.InitializeComponent();
            minAcronymLengthSlider.ValueChanged += sliderChanged;
            maxAcronymLengthSlider.ValueChanged += sliderChanged;
        }

        private void sliderChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            ClampSliders(sender as Slider);
        }

        private void ClampSliders(Slider last)
        {
            if (last == minAcronymLengthSlider)
            {
                maxAcronymLengthSlider.Value = Math.Max(maxAcronymLengthSlider.Value, minAcronymLengthSlider.Value);
                minAcronymLengthSlider.Value = Math.Min(maxAcronymLengthSlider.Value, minAcronymLengthSlider.Value);
            }
            else
            {
                minAcronymLengthSlider.Value = Math.Min(maxAcronymLengthSlider.Value, minAcronymLengthSlider.Value);
                maxAcronymLengthSlider.Value = Math.Max(maxAcronymLengthSlider.Value, minAcronymLengthSlider.Value);
            }
        }

        private void generateAcronymBtn_Click(object sender, RoutedEventArgs e)
        {
            doGenerate();
        }

        private void doGenerate()
        {
            var min = (int)minAcronymLengthSlider.Value;
            var max = (int)maxAcronymLengthSlider.Value;
            outputBox.Text = AcronymGenerator.GenerateAcronym(min, max);
        }

    }
}
