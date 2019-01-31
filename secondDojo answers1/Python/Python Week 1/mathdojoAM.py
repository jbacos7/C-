# HINT: To do this exercise, you will probably have to use 'return self'. If the method returns itself (an instance of itself), we can chain methods.

# Create a Python class called MathDojo that has the methods add and subtract. Have these 2 functions take at least 1 parameter.

# # Then create a new instance called md. It should be able to do the following task:
# x = md.add(2).add(2,5,1).subtract(3,2).result
# print(x) # should print 5

# Cant have methods and attributes with the same name!!! 

class MathDojo:
    def __init__(self):
        self.result = 0

    def plus (self, *nums):
        for num in nums:
            self.result= num + self.result
        return self

    def minus (self, *nums):
        for num in nums:
            self.result= self.result - num
        return self

md = MathDojo()
md.plus(2). plus(2,5,1).minus(3,2)
print(md.result)