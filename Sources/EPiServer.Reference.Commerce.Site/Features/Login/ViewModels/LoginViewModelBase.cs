﻿using EPiServer.Reference.Commerce.Site.Infrastructure.Attributes;

namespace EPiServer.Reference.Commerce.Site.Features.Login.ViewModels
{
    public abstract class LoginViewModelBase
    {

        [LocalizedDisplay("/Login/Form/Label/Password")]
        [LocalizedRequired("/Login/Form/Empty/Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [LocalizedDisplay("/Login/Form/Label/RememberMe")]
        public bool RememberMe { get; set; }

    }
}