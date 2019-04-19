using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace DotNetDemoBin.Wpf.PeriodicPropertyBindingUpdateWithBehaviorDemo.Behaviors
{
    public class PeriodicPropertyBindingUpdateBehavior :
        Behavior<DependencyObject>
    {
        private readonly DispatcherTimer _updatePropertyBindingTimer = new DispatcherTimer(DispatcherPriority.DataBind);

        public PeriodicPropertyBindingUpdateBehavior()
        {
            _updatePropertyBindingTimer.Tick += UpdatePropertyBindingTimer_HandleTick;
        }

        public TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(1);
        public DependencyProperty PropertyToUpdate { get; set; }

        protected override void OnAttached()
        {
            if(PropertyToUpdate == null)
            {
                throw new InvalidOperationException($"Property {PropertyToUpdate} must be set.");
            }

            _updatePropertyBindingTimer.Interval = Interval;
            _updatePropertyBindingTimer.Start();

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            _updatePropertyBindingTimer.Stop();

            base.OnDetaching();
        }

        private void UpdatePropertyBindingTimer_HandleTick(object sender, EventArgs e)
        {
            BindingOperations.GetBindingExpression(AssociatedObject, PropertyToUpdate)?.UpdateTarget();
        }
    }
}
