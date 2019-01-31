1. Get 1 to 255 - Write a function that returns an array with all the numbers from 1 to 255.


function getarr(){
	for (var i=1; i< 256; i++){
		console.log(i);
	}
}

2. Get even 1000 - Write a function that would get the sum of all the even
numbers from 1 to 1000.  You may use a modulus operator for this exercise.

var sum = 0;
function even(){
	for (var i=1; i< 1001; i++){
		if (i %2 == 0){
			sum+= i
		}
	}	
	return sum;
		
	}

3. Sum odd 5000 - Write a function that returns the sum of all the odd numbers
from 1 to 5000. (e.g. 1+3+5+...+4997+4999).

var sum = 0;
function odds(){
	for (var i= 1; i< 5000; i ++){
		if (i %2 != 0){
			sum += i
		}
	}
	return sum;
}

4. Iterate an array - Write a function that returns the sum of all the
values within an array. (e.g. [1,2,5] returns 8. [-5,2,5,12] returns
14).

var sum = 0;
function values(){
	for (var i=-; i<arr.length; i++){
		sum= sum+ arr[i];
	}
	return sum
}


5. Find max - Given an array with multiple values, write a function that
returns the maximum number in the array. (e.g. for [-3,3,5,7] max is 7)

var max= 0;
function max(){
	for (var i= 0; i< arr.length; i++){
		if (max < arr[i]){
			max = arr[i]
		}
	}
	return max;
}

6. Find average - Given an array with multiple values, write a function that
returns the average of the values in the array. (e.g. for [1,3,5,7,20] average
is 7.2)

var sum = 0;
function avg (){
	for (var i=0; i<arr.length< i++){
		sum= sum + arr[i];
	}
return sum/ arr.length;
}

7. Array odd - Write a function that would return an array of all the odd
numbers between 1 to 50. (ex. [1,3,5, .... , 47,49]). Hint: Use 'push' method.


function oddNumbers() {
    var array = [];
    
    for (var i= 1; i <50; i ++) {
        if (i % 2 !== 0) {
            array.push(i);
        }
    }
    return array; 
}

8. Greater than Y - Given value of Y, write a function that takes an array and
returns the number of values that are greater than Y. For example if arr = [1,
3, 5, 7] and Y = 3, your function will return 2. (There are two values in the
array greater than 3, which are 5, 7).

var count=0;
function greater (){
	for (var i=0; i < arr.length; i++){
		if (arr[i] > Y){
			count ++;
		}
	}
return count;
}

9. Squares - Given an array with multiple values, write a function that
replaces each value in the array with the product of the original value
squared by itself. (e.g. [1,5,10,-2] will become [1,25,100,4])

function b9 (){
for (var i=0; i<arr.length; i++){
	arr[i]= arr[i]* arr[i];
}
return arr;
}

10. Negatives - Given an array with multiple values, write a function that
replaces any negative numbers within the array with the value of 0. When the
program is done the array should contain no negative values. (e.g. [1,5,10,-2]
will become [1,5,10,0])

function b10(){
	for (var i=0; i<arr.length; i++){
		if (arr [i] <0);{
		arr[i] = 0;
	}
}	
return arr;
}


11. Max/Min/Avg - Given an array with multiple values, write a function that
returns a new array that only contains the maximum, minimum, and average
values of the original array. (e.g. [1,5,10,-2] will return [10,-2,3.5])

var min= arr[0];
var max= arr[0];
var sum= arr[0];

function b11 (){
	for (var i=0; i<arr.length; i++){
		if (arr[i] > max){
		max = arr[i];
		}
		if (arr[i] < min){
		min= arr[i];
		}
		sum = sum + arr[i];
	}
	var avg= sum/ arr.length;
	var arrnew= [max, min, avg];
	return arrnew;
}

12. Swap Values - Write a function that will swap the first and last values of
any given array. The default minimum length of the array is 2. (e.g.
[1,5,10,-2] will become [-2,5,10,1]).

function swap(arr){
var temp = arr [0]; 
arr [0] = arr [arr.length - 1]; 
arr[arr.length - 1] = temp; 


    return arr; 
}

13. Number to String - Write a function that takes an array of numbers and
replaces any negative values within the array with the string 'Dojo'. For
example if array = [-1,-3,2], your function will return ['Dojo','Dojo',2].

function b13(){
	for (var i=0; i < arr.length; i++){
		if (arr[i] < 0){
		arr[i] = 'Dojo';
	}
}
return arr;
}

