(function getSampleApiData() {
    $.getJSON('http://localhost:53895/api/helloworld/getsampledata').then(function (data) {
        var $apiData = $('#API-results');
        $apiData.append($('<ul> </ul>'));
        for (var i = 0; i < data.length; i++) {
            $apiData.children('ul').append($('<li>' + data[i].Message + '</li>'));
        }
    });
})();