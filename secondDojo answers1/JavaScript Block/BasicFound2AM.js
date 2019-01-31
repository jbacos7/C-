1. Biggie Size - Given an array, write a function that changes all positive
numbers in the array to "big".  Example: makeItBig([-1,3,5,-5]) returns that
same array, changed to [-1, "big", "big", -5]. 

function Biggie (){
	for (var i=0; i, arr.length; i++){
		if (arr[i] > 0);{
		arr[i] = "big";
	}
}
return arr [i];
}

2. Print Low, Return High - Create a function that takes array of numbers.
The function should print the lowest value in the array, and return the
highest value in the array.

function Print (){
	var max= 0;
	var min= 0;
	for (var i=0; i< arr.length; i++){
		if (arr[i] < min);{
		min= arr[i];
	console.log min;}

		if (arr[i]> max);{
		max = arr[i];
		return max;}
	}
}

3. Print One, Return Another - Build a function that takes array of numbers.
The function should print second-to-last value in the array, and return first
odd value in the array.

function PR (){
	for (var i=0; i<arr.length; i++){
		console.log (arr.length-1);{
		}
	}
	return arr[0];
}

4. Double Vision - Given array, create a function to return a new array where
each value in the original has been doubled.  Calling double([1,2,3]) should
return [2,4,6] without changing original.

function DV (){
	var arr= 0;
	var double= 0;
	for(var i=0; i<arr.length; i++){
		arr[i]= arr[i]*2;{
		arr[i]*2 = double;
		}
	}
	return arr[i];
}


5. Count Positives - Given array of numbers, create function to replace last
value with number of positive values.  Example, countPositives([-1,1,1,1])
changes array to [-1,1,1,3] and returns it.

function CP(){
	for (var i=o; i< arr.length-1; i++){
		arr(i)-1 = arr [i];{
	}
}
return arr[i];
}

6. Evens and Odds - Create a function that accepts an array.  Every time that
array has three odd values in a row, print "That's odd!".  Every time the
array has three evens in a row, print "Even more so!"

funtion EO(arr){
var even= 0;
var odd= 0;
for (var i=0 ; i<arr.length; i++){
	if (arr [i] % 2 == 0){
		even = even+1;
		odd = 0;
	}
	if (arr[i] % 2 != 0){
		odd == odd+1;
		even= 0;
	}
	if (even>=3){
		console.log("even more so");
	}
	if(odd>=3){
		console.log ("that's odd!");
	}
} } 

7. Increment the Seconds - Given an array of numbers arr, add 1 to every second element, specifically those whose index is odd (arr[1], [3], [5], etc).  Afterward. console.log each array value and return arr.

function b7 (arr){
for (var i=1; i<arr.length; i=i+2) {
		arr[i] = arr[i]+1;
		console.log(arr[i]);
	}
return arr
}


8. Previous Lengths - You are passed an array containing strings.  Working
within that same array, replace each string with a number - the length of the
string at previous array index - and return the array.  For example,
previousLengths(["hello", "dojo", "awesome"]) should return ["hello", 5, 4].

function b8 (arr){
	for(var i = 1; i<arr.length; i++){
		arr[i] = arr[i-1].length
	}
return arr
}

9. Add Seven to Most - Build function that accepts array. Return a new array
with all values except first, adding 7 to each. Do not alter the original
array.

function SM (arr){
	var newarr = [];
	for(var i=1; i<arr.length; i++){
		newarr[i-1]=arr[i]+7;
	}
return newarr


10. Reverse Array - Given an array, write a function that reverses values, in-
place.  Example: reverse([3,1,6,4,2]) return same array, containing
[2,4,6,1,3].  Do this without creating an empty temporary array.  (Hint:
youll need to swap values. 

function B10 (arr){
	var move =0;
	for(var i=0;i<arr.length/2;i = i++){
		move = arr[i];
		arr[i]=arr[arr.length-1-i];
		arr[arr.length-1-i]=move ;
	}
}

11. Outlook: Negative - Given an array, create and return a new one containing
all the values of the provided array, made negative (not simply multiplied by
-1). Given [1,-3,5], return [-1,-3,-5].

	function ON (arr){
	for(var i=0; i<arr.length; i++){
		if(arr[i]>0){
			arr[i] = arr[i]*-1;
		}
	}
return arr
}

12. Always Hungry - Create a function that accepts an array, and prints
"yummy" each time one of the values is equal to "food".  If no array elements
are "food", then print "I'm hungry" once.

function AH(arr){
	for (var i=0; i<arr.length; i++){
		if arr[i]== "food";{
			console.log ("yummy"){
		else arr[i] != "food";
	} }
	console.log ("I'm hungry!");
}

13. Swap Toward the Center - Given array, swap first and last, third and
third-to-last, etc.  Input[true,42,"Ada",2,"pizza"] becomes ["pizza", 42,
"Ada", 2, true].  Change [1,2,3,4,5,6] to [6,2,4,3,5,1].

function STC (arr){
var temp =0;
	for(var i=0;i<arr.length/2;i = i+2){
		temp  = arr[i];
		arr[i]=arr[arr.length-1-i];
		arr[arr.length-1-i]=temp ;
	}

}

14. Scale the Array - Given an array arr and a number num, multiply all values
in arr by num, and return the changed array arr.  For example,
scaleArray([1,2,3],3) should return [3,6,9].

function STA (arr, Z){
	for(var i=0; i<arr.length; i++){
		arr[i] = arr[i]*z;
	}
return arr
}






