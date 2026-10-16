namespace DiveDeepWebApp.Handlers
{
    public class IdentityCookieHandler : DelegatingHandler
    {
        private string CookieName = ".DiveDeep.Identity";
        private readonly IHttpContextAccessor httpContextAccessor;

        public IdentityCookieHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpContext? context = httpContextAccessor.HttpContext;

            if (context?.Request.Cookies.TryGetValue(CookieName, out string? cookieValue) == true)
            {
                request.Headers.TryAddWithoutValidation("Cookie", $"{CookieName}={cookieValue}");
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}