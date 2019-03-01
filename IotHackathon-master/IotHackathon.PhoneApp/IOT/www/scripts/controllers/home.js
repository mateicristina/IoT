myApp.controller('Home', function ($scope, $rootScope, $location) {

    $scope.init = function () {
        $rootScope.URL='http://iotserviceiteam.azurewebsites.net';
        //$rootScope.URL = 'http://localhost:53857';
        $scope.lastBtn = 0;
        console.log("init Home");
  };

    $scope.sound = [];
  $scope.sound[1] = new Audio("audio/sound1.mp3");
  $scope.sound[2] = new Audio("audio/sound2.mp3");
  $scope.sound[3] = new Audio("audio/sound3.mp3");

  

  $scope.noiseFunction = function (obiect) {
      if (obiect !== $scope.lastBtn) {
          $scope.sound[obiect].play();
          $scope.sound[obiect].currentTime = 0;
          $scope.lastBtn = obiect;
      }

      else {
          
          var Selector = {
              Type: obiect
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
                $location.path('/noise');
            })
            .fail(function (xhr, textstatus, errorthrown) {
                console.log(xhr.status);
            });

      }
  }

  document.addEventListener("deviceready", function () {

  }, false);
});