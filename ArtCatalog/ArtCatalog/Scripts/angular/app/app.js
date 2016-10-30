var app = angular.module('app', []);


app.controller('UploadController', function ($scope, fileReader, $http) {

    $scope.getFile = function () {
        $scope.progress = 0;
        fileReader.readAsDataUrl($scope.file, $scope)
            .then(function (result) {
                $scope.imageSrc = result;               
            });
    };

    $scope.uploadFile = function () {

        var fd = new FormData();
        fd.append('uplFile', $scope.file);

        var request = {
            method: 'POST',
            url: '/File/Upload',
            headers: { 'Content-Type': undefined },
            data: fd,
            transformRequest: angular.identity
        };

        $http(request).success(function (responseJSON) {
            $('#ImageOriginalPath').attr('value', responseJSON.data.filePath);
            $('#ImagePreviewPath').attr('value', responseJSON.data.filePreviewPath);
        });
    };

    $scope.$on('fileProgress', function(e, progress) {
        $scope.progress = progress.loaded / progress.total;
    });

});

app.directive('ngFileSelect', function () {
    return {
        link: function($scope,el){     
            el.bind('change', function (e) {
                $scope.file = (e.srcElement || e.target).files[0];
                $scope.getFile();
                $scope.uploadFile();
            })    
        }   
    }  
});

app.factory('fileReader', ['$q', '$log', function ($q, $log) {
 
        var onLoad = function(reader, deferred, scope) {
            return function () {
                scope.$apply(function () {
                    deferred.resolve(reader.result);
                });
            };
        };
 
        var onError = function (reader, deferred, scope) {
            return function () {
                scope.$apply(function () {
                    deferred.reject(reader.result);
                });
            };
        };
 
        var onProgress = function(reader, scope) {
            return function (event) {
                scope.$broadcast('fileProgress',
                    {
                        total: event.total,
                        loaded: event.loaded
                    });
            };
        };
 
        var getReader = function(deferred, scope) {
            var reader = new FileReader();
            reader.onload = onLoad(reader, deferred, scope);
            reader.onerror = onError(reader, deferred, scope);
            reader.onprogress = onProgress(reader, scope);
            return reader;
        };
 
        var readAsDataURL = function (file, scope) {
            var deferred = $q.defer();
             
            var reader = getReader(deferred, scope);         
            reader.readAsDataURL(file);
             
            return deferred.promise;
        };
 
        return {
            readAsDataUrl: readAsDataURL  
        };
    }]);
