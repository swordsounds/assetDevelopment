﻿using assetDevelopment.Stores;
using assetDevelopment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assetDevelopment.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
