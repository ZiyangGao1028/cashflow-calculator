var cashflowCalculatorModule = angular.module("cashflowCalculatorApp", []);

cashflowCalculatorModule.controller('LoanController', ['$scope', '$http', function ($scope, $http) {
    var self = this;
    self.loans = [];
    self.loan = {};


    self.addLoan = function () {
        $http.post('http://localhost:55533/api/CashflowCalculator/addLoan', self.loan).then(
            function (response) {
                self.loan.id = response.data;
                self.loans.push(angular.copy(self.loan));
                cosole.log(JSON.stringify(self.loans));
               
            },
            function (error) {
                
                console.log(error);
            }
        );
    }

    self.getLoans = function () {
        $http.get('http://localhost:55533/api/CashflowCalculator/getLoans').then(
            function (response) {
                self.loans = response.data;
            },
            function (error) {                
                console.log(error);
            }
        );
    };

    self.clearText = function () {
        document.getElementById('text1').value = "";
        document.getElementById('text2').value = "";
        document.getElementById('text3').value = "";
    };

    }]
);