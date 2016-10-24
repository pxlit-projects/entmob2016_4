using EntMob_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Xamarin
{
    public class ViewModelLocator
    {

        private readonly Dictionary<Type, object> viewModels = new Dictionary<Type, object>();

        private T CreateViewModel<T>() where T : new()
        {
            var type = typeof(T);
            object existing;
            if (!viewModels.TryGetValue(type, out existing))
            {
                existing = new T();
                viewModels[type] = existing;
            }
            return (T)existing;
        }

        public RunnerViewModel Main
        {
            get
            {
                return CreateViewModel<RunnerViewModel>();
            }
        }

        public TimerViewModel Timer
        {
            get
            {
                return CreateViewModel<TimerViewModel>();
            }
        }

        public ValuesViewModel Values
        {
            get
            {
                return CreateViewModel<ValuesViewModel>();
            }
        }
    }
}
