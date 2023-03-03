namespace Basket.API
{
    internal class TestHttpResponseTrailersFeature : IHttpResponseTrailersFeature
    {
        public IHeaderDictionary Trailers { get; set; }
    }
}
