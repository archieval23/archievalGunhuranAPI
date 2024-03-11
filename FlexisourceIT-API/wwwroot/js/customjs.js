$(function () {
    $('#explore').click(function () {
        var username = $('#username').val();
        var password = $('#password').val();

        // Set the headers for Swagger requests
        window.swaggerUi.api.clientAuthorizations.add('basicAuth', new SwaggerClient.PasswordAuthorization(username, password));
    });
});