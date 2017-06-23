using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Models
{
    public class Events
    {
        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler ValueChanged;

        private object anyValue;
        public object Value
        {
            get { return anyValue; }
            set
            {
                if (anyValue == value)
                    return;
                else
                {
                    anyValue = value;
                    OnChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        public Events()
        {
            ValueChanged += Events_ValueChanged;
        }
        
        private void Events_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"You changed one of my field from null to {anyValue}.");
        }
    }
}
