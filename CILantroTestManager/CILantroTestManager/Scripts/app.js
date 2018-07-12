function addLoggerFunctionsToHub(hub, loggerSelector) {
    hub.client.logInfo = function (message) {
        var logEntry = $("<pre></pre>")
            .addClass('text-info')
            .text(message);
        $(loggerSelector).append(logEntry);
    };

    hub.client.logSuccess = function (message) {
        var logEntry = $("<pre></pre>")
            .addClass('text-success')
            .text(message);
        $(loggerSelector).append(logEntry);
    };

    hub.client.closeLogGroup = function () {
        var br = $("<br />");
        $(loggerSelector).append(br);
    };
}

function addFinishFunctionToHub(hub) {
    hub.client.finish = function () {
        $.connection.hub.stop();
        setTimeout(function () {
            window.location.reload();
        }, 1000);
    };
}