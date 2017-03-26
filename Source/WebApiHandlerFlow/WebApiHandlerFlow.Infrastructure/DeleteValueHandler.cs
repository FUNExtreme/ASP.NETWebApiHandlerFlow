using System;
using WebApiHandlerFlow.Domain;

namespace WebApiHandlerFlow.Infrastructure
{
    public class DeleteValueHandler : RequestHandler<DeleteValueRequest, DeleteValueResponse, DeleteValueHandlerData>
    {
        internal override void DoDataFetch(DeleteValueRequest request)
        {
            HandlerData.DeleteEntity = new EntityWithId { Id = request.EntityId };
        }

        internal override bool DoRequestValidation(DeleteValueRequest request, DeleteValueHandlerData validationData)
        {
            if (HandlerData.DeleteEntity.Id == 10)
                return true;

            return false;
        }

        internal override DeleteValueResponse DoAction(DeleteValueRequest request)
        {
            //context.Values.Remove(HandlerData.DeleteEntity);
            return new DeleteValueResponse { HasSucceeded = true };
        }

        internal override DeleteValueResponse DoResponseManipulation(DeleteValueResponse response)
        {
            response.HasSucceeded = false;
            return response;
        }
    }

    public class DeleteValueRequest
    {
        public int EntityId { get; set; }
    }

    public class DeleteValueResponse
    {
        public bool HasSucceeded { get; set; }
    }

    public class DeleteValueHandlerData : HandlerData
    {
        public EntityWithId DeleteEntity { get; set; }
    }
}
