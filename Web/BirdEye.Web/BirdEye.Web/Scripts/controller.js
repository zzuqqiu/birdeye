
function PersonInfoCtrl($scope, $http) {
	initialData('InitialBasicData');

	$scope.save = function () {
		alert("hello");
		$http.post('Save', $scope.person).success(function (data) {
			$scope.person = data;
			$scope.successMsg = '';
		}).error(function (msg) {
			$scope.errorMsg = msg;
		});
	};

	function initialData(url) {
		$http.get(url).success(function (data) {
			$scope.person = data;
			$scope.successMsg = '';
		}).error(function (msg) {
			$scope.errorMsg = msg;
		});
	}
};