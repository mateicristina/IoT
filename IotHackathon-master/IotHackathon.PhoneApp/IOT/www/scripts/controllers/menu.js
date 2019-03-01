myApp.controller('Menu', function ($scope, $rootScope, $location) {

  var introText = ["What do you want practice?",
                   "Ready for action?",
                   "En garde!",
                  ];

  $scope.init = function () {
    clearInterval($rootScope.interval);
    $scope.intro = introText[Math.floor(Math.random() * 3)];

    $rootScope.lastPage='/menu'
    console.log("init menu");
  };
  // A se schimba in parazi, atacuri:
  $scope.toP3 = function () {
    $location.path('/probaFencing');
  }
  $scope.toP4 = function () {
    $location.path('/probaFencing');
  }
  $scope.toP5 = function () {
    $location.path('/probaFencing');
  }
  $scope.toFAttack = function () {
    $location.path('/probaFencing');
  }
  $scope.toCAttack = function () {
    $location.path('/probaFencing');
  }
  $scope.toHAttack = function () {
    $location.path('/probaFencing');
  }

  document.addEventListener("deviceready", function () {


    //$scope.back = function () {
    //  $rootScope.changingUrl = false;
    //  console.log('uite');
    //  if ($rootScope.registerPage == true) {
    //    $location.path('/register');
    //  }
    //  else {
    //    $location.path('/application');
    //  }
    //}

  }, false);
});