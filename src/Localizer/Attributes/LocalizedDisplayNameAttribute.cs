﻿using System.ComponentModel;
using AspNetCoreLocalizer.Abstraction;
using AspNetCoreLocalizer.Services;

namespace AspNetCoreLocalizer.Attributes
{
    public  class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        #region Fields

        private readonly string _resourceKey;

        private ILocalizerService _localizerService;

        #endregion

        #region C'tor

        private LocalizedDisplayNameAttribute(ILocalizerService localizerService)
        {
            this._localizerService = localizerService;
        }

        internal LocalizedDisplayNameAttribute(ILocalizerService localizerService, string resourceKey) : this(localizerService)
        {
            this._resourceKey = resourceKey;
        }

        public LocalizedDisplayNameAttribute(string resourceKey) : this(new LocalizerService(Configuration.LocalizationProvider))
        {
            this._resourceKey = resourceKey;
        }
       
        #endregion

        #region Public Properties

        public override string DisplayName => _localizerService.GetLocalizedValue(_resourceKey);

        #endregion
    }
}
