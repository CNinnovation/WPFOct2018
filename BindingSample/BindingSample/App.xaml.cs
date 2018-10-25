﻿using BindingSample.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BindingSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            PresentationTraceSources.DataBindingSource.Listeners.Add(new MyTraceListener());
            PresentationTraceSources.DataBindingSource.Switch = new SourceSwitch("Switch1", "Error");
            base.OnActivated(e);
        }
    }
}
