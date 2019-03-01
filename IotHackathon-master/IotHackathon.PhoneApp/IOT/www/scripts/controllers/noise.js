myApp.controller('Noise', function ($scope, $rootScope, $location) {

  $scope.init = function () {
      clearInterval($rootScope.interval);
      console.log("noise init");
  };
  $scope.back = function () {

      var Selector = {
          Type: 0
      }

      var urlString = $rootScope.URL + "/api/values";
      var jqxhr = $.ajax({
          method: 'post',
          url: urlString,
          data: Selector,
          //datatype: 'json',
          crossdomain: true,
          jsonp: false
      })
        .done(function () {
            $location.path('/home');
            console.log("succes");
        })
        .fail(function (xhr, textstatus, errorthrown) {
            console.log(xhr.status);
        });

  }

  document.addEventListener("deviceready", function () {
    
  }, false);
});