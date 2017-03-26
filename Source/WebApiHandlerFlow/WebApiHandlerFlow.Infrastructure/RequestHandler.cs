using WebApiHandlerFlow.Domain;

namespace WebApiHandlerFlow.Infrastructure
{
    public abstract class RequestHandler<TRequest, TResponse, THandlerData>
        where TRequest : class
        where TResponse : class
        where THandlerData : HandlerData, new()
    {
        internal THandlerData HandlerData { get; }

        internal abstract void DoDataFetch(TRequest request);
        internal abstract bool DoRequestValidation(TRequest request);
        internal abstract TResponse DoAction(TRequest request);
        internal abstract TResponse DoResponseManipulation(TResponse response);

        public RequestHandler()
        {
            HandlerData = new THandlerData();
        }

        public TResponse DoHandle(TRequest request)
        {
            DoDataFetch(request);
            if(DoRequestValidation(request))
            {
                var response = DoAction(request);
                response = DoResponseManipulation(response);

                return response;
            }
            else
            {
                return new ValidationErrorResponse() as TResponse;
            }
        }
    }

    public class ValidationErrorResponse { }
}
