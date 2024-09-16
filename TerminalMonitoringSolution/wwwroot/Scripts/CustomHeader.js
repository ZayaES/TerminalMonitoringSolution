<!-- wwwroot/swagger-custom.js -->
<script>
window.onload = function() {
    const ui = SwaggerUIBundle({
        url: "/swagger/v1/swagger.json",
        dom_id: '#swagger-ui',
        presets: [
            SwaggerUIBundle.presets.apis,
            SwaggerUIBundle.SwaggerUIStandalonePreset
        ],
        layout: "StandaloneLayout",
        requestInterceptor: function(request) {
            request.headers['Authorization'] = 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJoZWF2ZW5waHJpbmNlQGdtYWlsLmNvbSIsImp0aSI6IjU4ZmRjMjU5LTJmZTAtNDNjMS1iNTgzLTNlMTQ4ZjlmODhjNSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImhlYXZlbnBocmluY2VAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IlpheWFCZWxsIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiU3VwZXJBZG1pbiIsImV4cCI6MTcyNjI2ODk4NywiaXNzIjoiaHR0cHM6Ly90ZXJtaW5hbE1vbml0b3JpbmdTb2x1dGlvbi5jb20iLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdCJ9.I4udG2hH0N0OpJA-cjXlc0noDjX0DKUuuk46U3KAMQM';
            return request;
        }
    });
    window.ui = ui;
}
</script>