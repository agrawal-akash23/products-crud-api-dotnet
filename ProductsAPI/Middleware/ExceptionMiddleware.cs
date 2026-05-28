namespace ProductsAPI.Middleware
{
    public class ExceptionMiddleware
    {
        // _next is the next middleware in the pipeline
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // InvokeAsync is called automatically for every single HTTP request
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // -- Hand off to the next middleware --
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var result = new
                {
                    message = "Something went wrong",
                    detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
