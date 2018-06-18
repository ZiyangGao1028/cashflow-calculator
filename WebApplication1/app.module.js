var cashflowCalculatorModule = angular.module("cashflowCalculatorApp", []);

cashflowCalculatorModule.controller('LoanController', ['$scope', '$http', function ($scope, $http) {
    var self = this;
    self.loans = [];
    self.loan = {};
    self.cashflows = [];


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
    };

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


    self.GetCashFlows = function () {
        $http.get('http://localhost:55533/api/CashflowCalculator/GetCashFlows').then(
            function (response) {
                self.cashflows = response.data;
                //for (var i = 1; i < self.cashflows.length; i++) {
                //    cashflowsreal.push(self.cashflows[i].Unit);
                //}
            },
            function (error) {
                console.log(error);
            }
        );
    };

    self.deleteLoans = function () {
        self.loans2BeDeleted = [];
        for (let x = 0; x < self.loans.length; x++) {
            if (self.loans[x].isChecked === true)
                self.loans2BeDeleted.push(self.loans[x].Id);
        }
        $http.post('http://localhost:55533/api/CashflowCalculator/deleteLoans', self.loans2BeDeleted).then(
            function (response) {
                self.getLoans();
            },
            function (error) {
                alert('Delete failed, try again');
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