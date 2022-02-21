using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Hellsys.Hell_Controls.Process
{
    /// <summary>
    /// Hell_ProcessLevel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Hell_ProcessLevel : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(Hell_ProcessLevel), new PropertyMetadata(50D, new PropertyChangedCallback(OnValueChanged)));

        public static readonly DependencyProperty FactorProperty =
        DependencyProperty.Register("Factor", typeof(double), typeof(Hell_ProcessLevel), new PropertyMetadata(1D));

        public static readonly DependencyProperty MinimumProperty =
        DependencyProperty.Register("Minimum", typeof(double), typeof(Hell_ProcessLevel), new PropertyMetadata(0D, new PropertyChangedCallback(OnMinimumChanged)));

        public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register("Maximum", typeof(double), typeof(Hell_ProcessLevel), new PropertyMetadata(100D, new PropertyChangedCallback(OnMaximumChanged)));

        public static readonly DependencyProperty OrientationProperty =
        DependencyProperty.Register("Orientation", typeof(Orientation), typeof(Hell_ProcessLevel), new PropertyMetadata(Orientation.Vertical, new PropertyChangedCallback(OnOrientationChanged)));

        public static readonly DependencyProperty BorderSizeProperty =
        DependencyProperty.Register("BorderSize", typeof(double), typeof(Hell_ProcessLevel), new PropertyMetadata(1D, new PropertyChangedCallback(OnBorderSizeChanged)));

        public static readonly DependencyProperty BorderColorProperty =
        DependencyProperty.Register("BorderColor", typeof(Color), typeof(Hell_ProcessLevel), new PropertyMetadata(Colors.White, new PropertyChangedCallback(OnBorderColorChanged)));

        public static readonly DependencyProperty ProcessColorProperty =
        DependencyProperty.Register("ProcessColor", typeof(Color), typeof(Hell_ProcessLevel), new PropertyMetadata(Colors.Lime));
        public Hell_ProcessLevel()
        {
            InitializeComponent();
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("Value")]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("Factor")]
        public double Factor
        {
            get { return (double)GetValue(FactorProperty); }
            set { SetValue(FactorProperty, value); }
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("Minimum")]
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("Maximum")]
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("Orientation")]
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("BorderSize")]
        public double BorderSize
        {
            get { return (double)GetValue(BorderSizeProperty); }
            set { SetValue(BorderSizeProperty, value); }
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("BorderColor")]
        [DefaultValue("Gray")]
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
        [Category("Hellsys Controls")]
        [Browsable(true)]
        [DisplayName("ProcessColor")]
        [DefaultValue("Gray")]
        public Color ProcessColor
        {
            get { return (Color)GetValue(ProcessColorProperty); }
            set { SetValue(ProcessColorProperty, value); }
        }

        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Hell_ProcessLevel objProcessLevel = sender as Hell_ProcessLevel;
            objProcessLevel.OnRender(null);
        }
        private static void OnOrientationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Hell_ProcessLevel objProcessLevel = sender as Hell_ProcessLevel;
            objProcessLevel.OnRender(null);
        }
        private static void OnBorderSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Hell_ProcessLevel objProcessLevel = sender as Hell_ProcessLevel;
            double value = 0D;
            if (e.NewValue != null)
            {
                value = (double)e.NewValue;
            }
            objProcessLevel.BorderThickness = new Thickness(value, value, value, value);
            objProcessLevel.OnRender(null);
        }
        private static void OnBorderColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Hell_ProcessLevel objProcessLevel = sender as Hell_ProcessLevel;
            Color value = Colors.Gray;
            if (e.NewValue != null)
            {
                value = (Color)e.NewValue;
            }
            objProcessLevel.BorderBrush = new SolidColorBrush(value);
            objProcessLevel.OnRender(null);
        }
        private static void OnMinimumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Hell_ProcessLevel objProcessLevel = sender as Hell_ProcessLevel;
            objProcessLevel.OnRender(null);
        }
        private static void OnMaximumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Hell_ProcessLevel objProcessLevel = sender as Hell_ProcessLevel;
            objProcessLevel.OnRender(null);
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            switch (Orientation)
            {
                case Orientation.Horizontal:
                    this.Factor = this.Width / this.Maximum;
                    this.LinearProcessBrush.EndPoint = new Point(0, 0.5);
                    this.ProcessValue.Width = Value * Factor;
                    this.ProcessValue.Height = this.Height;
                    this.ProcessValue.VerticalAlignment = VerticalAlignment.Center;
                    this.ProcessValue.HorizontalAlignment = HorizontalAlignment.Left;
                    break;
                case Orientation.Vertical:
                    this.Factor = this.Height / this.Maximum;
                    this.LinearProcessBrush.EndPoint = new Point(0.5, 0);
                    this.ProcessValue.Width = this.Width;
                    this.ProcessValue.Height = Value * Factor;
                    this.ProcessValue.VerticalAlignment = VerticalAlignment.Bottom;
                    this.ProcessValue.HorizontalAlignment = HorizontalAlignment.Center;
                    break;
            }
        }
    }
}
