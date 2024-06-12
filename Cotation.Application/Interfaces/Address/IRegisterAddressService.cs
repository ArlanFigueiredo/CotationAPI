﻿using Cotation.Communication.ModelsViews.Requests.Address;
using Cotation.Communication.ModelsViews.Responses.Address;

namespace Cotation.Application.Interfaces.Address {
    public interface IRegisterAddressService {
        public Task<ResponseAddress> Execute(RequestAddress request);
    }
}
