﻿using EPiServer.Commerce.Order;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;
using Mediachase.Commerce.Orders;

namespace EPiServer.Reference.Commerce.Site.Features.Payment.PaymentMethods
{
    public class CashOnDeliveryPaymentMethod : PaymentMethodBase
    {
        public CashOnDeliveryPaymentMethod()
            : this(LocalizationService.Current, ServiceLocator.Current.GetInstance<IOrderGroupFactory>())
        {
        }

        public CashOnDeliveryPaymentMethod(LocalizationService localizationService, IOrderGroupFactory orderGroupFactory)
            : base(localizationService, orderGroupFactory)
        {
        }

        public override bool ValidateData()
        {
            return true;
        }
        
        public override IPayment CreatePayment(decimal amount, IOrderGroup orderGroup)
        {
            var payment = orderGroup.CreatePayment(_orderGroupFactory);
            payment.PaymentType = PaymentType.Other;
            payment.PaymentMethodId = PaymentMethodId;
            payment.PaymentMethodName = "CashOnDelivery";
            payment.Amount = amount;
            payment.Status = PaymentStatus.Pending.ToString();
            payment.TransactionType = TransactionType.Authorization.ToString();
            return payment;
        }

        public override void PostProcess(IPayment payment)
        {
            payment.Status = PaymentStatus.Processed.ToString();
        }
    }
}