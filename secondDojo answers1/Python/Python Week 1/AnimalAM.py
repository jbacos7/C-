class Animal:
    def __init__(self, name, health):
        self.name = name
        self.health = health

    def walk(self):
        self.health= self.health - 1
        print("Walking lost you one point")
        print("health", str(self.health))
        return self
    def run(self):
        self.health= self.health - 5
        print("health", str(self.health))
        return self

class Dog (Animal):
    def __init__(self, name):
        self.name= name
        self.health= 150
    def walk(self):
        self.health= self.health + 5
        print("You lost 5 health, wah!")
        return self

class Dragon(Animal):
    def __init__(self, name):
        self.name= name
        self.health= 170
    def fly(self):
        self.health= self.health + 10
        print("I am a dragon!!!!!")
        return self

dragon1 = Dragon(Animal)
dragon1.fly()

dog1 = Dog(Animal)
dog1.walk()


    
    
