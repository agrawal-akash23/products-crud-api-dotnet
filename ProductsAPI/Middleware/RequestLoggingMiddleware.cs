namespace ProductsAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        // _next is the next middleware in the pipeline
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // InvokeAsync is called automatically for every single HTTP request
        public async Task InvokeAsync(HttpContext context)
        {
            // -- BEFORE the rest of the pipeline runs --
            var method = context.Request.Method;    // GET, POST, etc.
            var path = context.Request.Path;        // /api/products
            var time = DateTime.UtcNow.ToString("HH:mm:ss");

            Console.WriteLine($"[{time}] -> {method} {path}");

            // -- Hand off to the next middleware --
            await _next(context);

            // --AFTER the rest of the pipeline has run (response is ready) --
            var statusCode = context.Response.StatusCode;   // 200, 404, etc
            Console.WriteLine($"[{time}] -> {method} {path} -> {statusCode}");
        }
    }
}
