using PlanShare.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanShare.App.Resources;

namespace PlanShare.App.Extensions;
public static class ApiExceptionExtensions
{
    public static async Task<ResponseErrorJson> GetResponseError(this Refit.ApiException exception)
    {
        var response = await exception.GetContentAsAsync<ResponseErrorJson>();
        
        if (response is null)
            response = new ResponseErrorJson(ResourceTexts.SERVER_COMMUNICATION_ERROR);

        return response;
    }
}
