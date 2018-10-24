﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShapesUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnChangeShape(object sender, RoutedEventArgs e)
        {
            SetMouth();
        }

        private readonly Point[,] _mouthPoints = new Point[2, 3]
        {
            {
                new Point(40, 74), new Point(57, 95), new Point(80, 74),
            },
            {
                new Point(40, 82), new Point(57, 65), new Point(80, 82),
            }
        };

        private bool _laugh = false;
        public void SetMouth()
        {
            int index = _laugh ? 0 : 1;

            var figure = new PathFigure() { StartPoint = _mouthPoints[index, 0] };
            figure.Segments = new PathSegmentCollection();
            var segment1 = new QuadraticBezierSegment();
            segment1.Point1 = _mouthPoints[index, 1];
            segment1.Point2 = _mouthPoints[index, 2];
            figure.Segments.Add(segment1);
            var geometry = new PathGeometry();
            geometry.Figures = new PathFigureCollection();
            geometry.Figures.Add(figure);

            mouth.Data = geometry;
            _laugh = !_laugh;
        }
    }


}
