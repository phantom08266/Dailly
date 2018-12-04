using Dailly.ViewModels.Plan;
using System;

namespace Dailly.ViewModels.Main
{
    public class MainWindowViewModel : ViewModels.Base.ViewModelBase
    {
        private object _planDesign;

        public MainWindowViewModel()
        {
            PlanDesign = new PlanDesignViewModel();
        }

        #region Binding 정의
        public Object PlanDesign
        {
            get
            {
                return _planDesign;
            }
            set
            {
                _planDesign = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
