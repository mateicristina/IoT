var myApp = angular.module('myApp',
	        ['ngRoute', 'appControllers', 'ngCordova']);

//console.log("deci console.log din app.js merge..")

var appControllers = angular.module('appControllers', []);

myApp.config(['$routeProvider', function ($routeProvider) {
  $routeProvider.
      when('/home', {
          templateUrl: 'views/home.html',
          controller: 'Home'
      }).
      when('/noise', {
        templateUrl: 'views/noise.html',
        controller: 'Noise'
      }).
      otherwise({
          redirectTo: '/home'
      });
}]);