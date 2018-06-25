
angular.module('upload-progressbar-module').directive('uploadProgressbar', ['$http', 'Upload', '$rootScope', 'fileCache',
     function ($http, Upload, $rootScope, fileCache) {
         return {
             restrict: 'E',
             templateUrl: 'upload.progressbar.template',
             scope: {
                 item: '=',
                 url:'@',
                 getImageByPropName: "@"
             },

             link: function ($scope, element, attributes, ctrl) {
                 $scope.file = null;
                 $scope.fileLoadingPercent = 0;
                 $scope.fileMaxSize = 10e+7;

                 function getCachekey() {
                     return $scope.getImageByPropName + (($scope.item[$scope.getImageByPropName])? $scope.item[$scope.getImageByPropName]: "new");
                 }

                 $scope.$watch(function () {
                     return $scope.item;
                 }, function (newVal, oldVal) {
                     if ($scope.item && fileCache.get(getCachekey())[0]) {
                         $scope.item.DocFile = fileCache.get(getCachekey())[0];
                         $scope.file = { name: $scope.item.DocFile.DocumentName }
                         $scope.fileLoadingPercent = 100;
                     }
                 });

                 $scope.fileSelected = function (file) {
                     $scope.file = file;
                     if ($scope.file == null) {
                         return;
                     }
                     if ($scope.file.size > $scope.fileMaxSize) {
                         $rootScope.showError("Not available file size");
                         return;
                     }
                     $scope.fileLoading = true;
                     $scope.fileLoadingPercent = 0;
                     Upload.upload({
                         url: $scope.url,
                         data: { file: $scope.file }
                     }).then(function (resp) {
                         $scope.fileOk = true;
                         $scope.item.DocFile = resp.data;
                         fileCache.set(getCachekey(), [$scope.item.DocFile]);
                         $scope.fileLoading = false;
                         $scope.fileLoadingPercent = 100;
                     },
                         function (resp) { },
                         function (evt) {
                             var uploaded = parseInt(100.0 * evt.loaded / evt.total);
                             $scope.fileLoadingPercent = uploaded;
                         });
                 }


             },
             controller: [
               '$scope', function($scope) {

               }]
         }
     }]);
