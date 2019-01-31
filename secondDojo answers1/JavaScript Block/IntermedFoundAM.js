1. Sigma - Implement function sigma(num) that given a number, returns the sum
of all positive integers up to number (inclusive).  Ex: sigma(3) = 6 (or
1+2+3); sigma(5) = 15 (or 1+2+3+4+5).

function sigma(num){
	var arr= [];
	var sum= 0;
	for (var i= 0; i<= num; i++){
		arr.push(i);
	}
	for(var j=0; j < arr.length; j++){
		sum += arr[j];
	}
	return sum;
}

2. Factorial - Write a function factorial(num) that, given a number, returns
the product (multiplication) of all positive integers from 1 up to number
(inclusive).  For example, factorial(3) = 6 (or 1*2*3); factorial(5) = 120 (or
1*2*3*4*5).

function factorial(num){
	var arr= [];
	var product= 0;
	for (var i=0; i <= num; i++){
		arr.push(i);
	}
	for (var x=0; x< arr.length; x++){
		product = product * x;
	}
	return product
	}	

3. Fibonacci - Create a function to generate Fibonacci numbers.  In this
famous mathematical sequence, each number is the sum of the previous two,
starting with values 0 and 1.  Your function should accept one argument, an
index into the sequence (where 0 corresponds to the initial value, 4
corresponds to the value four later, etc).  Examples: fibonacci(0) = 0
(given), fibonacci(1) = 1 (given), fibonacci(2) = 1 (fib(0)+fib(1), or 0+1),
fibonacci(3) = 2 (fib(1) + fib(2)3, or 1+1), fibonacci(4) = 3 (1+2),
fibonacci(5) = 5 (2+3), fibonacci(6) = 8 (3+5), fibonacci(7) = 13 (5+8).  Do
this without using recursion first.  

function fibonacci(num){
  var x = 1;
  var y = 0;
  var temp = [];

  while (num >= 0){
    temp = x;{
    var x = (var x + var y);{
    y = temp;
    num--;
  }
}
  return y;
}

4. Array: Second-to-Last: Return the second-to-last element of an array. Given
[42, true, 4, "Liam", 7], return "Liam".  If array is too short, return null.

functionSTL (arr){
	for (var i=0; i< arr.length; i++){
		if (arr[i] >= 2);{
		arr[i] = arr.length-2;}
		
		else if (arr[i]< 2);{
		return null}

return arr[i];

	}

}

5. Array: Nth-to-Last: Return the element that is N-from-arrays end. Given 
([5,2,3,6,4,9,7],3), return 4.  If the array is too short, return null.

function NTL (arr, num){
	if(num > arr.length){
		return null;
	}
	return arr[arr.length - (num-1)]
}


6. Array: Second-Largest: Return the second-largest element of an array. Given
[42,1,4,3.14,7], return 7.  If the array is too short, return null.

1,3.14,4,7,42
function secLarg (arr){
	arr = arr.sort();
	return arr[arr.length - 2];
}


7. Double Trouble: Create a function that changes a given array to list each
existing element twice, retaining original order.  Convert [4, "Ulysses", 42,
false] to [4,4, "Ulysses", "Ulysses", 42, 42, false, false].

function double (arr){
	for(var i = 0; i < arr.length; i + 2){
		arr.insert(i + 1, arr[i]); 
	}
	return arr;
}

_______ 

1.  Create a function Fib(n) where it returns the nth Fibonacci
number.  Use recursion for this.

function Fib (n){
	if (n===1){
		return 0;
	}
	else if (n==2) {
		return 1;
	}
	else {
		var num1 = Fib(n-2);
		var num2 = Fib(n-1);
		return num1 + num2;

	}
}