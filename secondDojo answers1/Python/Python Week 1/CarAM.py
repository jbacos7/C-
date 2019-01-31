class Car:
    def __init__(self, price, speed, fuel, mileage):
        self.price = price
        self.speed = speed
        self.fuel= fuel
        self.mileage = mileage

    def display_all(self):
        print("Price:"+ str(self.price))
        print("Speed:" + str(self.speed))
        print("Fuel:" + str(self.fuel))
        print("Mileage:" + str(self.mileage))

        if self.price <= 10000:
            print("Tax" + str(0.12))
        if self.price > 10000:
            print("Tax" + str(0.15))

carA = Car("$4,000", 100, "empty", 25000)
carB = Car("$8,000", 70, "full", 45000)
carC = Car("$9,000", 650, "half full", 6500)
carD = Car("$91,000", 50, "zero", 7500)
carE = Car("$29,000", 75, "full", 6555)
carF = Car("$50,000", 200, "empty", 8000)

carA.display_all()
carB.display_all()
carC.display_all()
carD.display_all()
carE.display_all()
carF.display_all()