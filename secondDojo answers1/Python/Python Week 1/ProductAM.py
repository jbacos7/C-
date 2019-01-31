class Product:
    def __init__(self, price, item_name, weight, brand):
        self.price = price
        self.item_name = item_name
        self.weight= weight
        self.brand = brand
        self.status = "for sale"
        self.condition= "new"

    def sell(self):
        self.status = "sold"
        print(self.status)
        return self

    def addtax(self):
        tax= self.price * 1.1
        print (tax)
    
    def reasonreturn(self):
        if (self.condition == "defective"):
            self.status = "defective"
            return self

        if (self.condition == "new"):
            self.status = "for sale"
            return self

        if (self.condition == "opened"):
            self.status= "used"
            self.price = price*.8
            return self
    def displayinfo(self):
        print(self.price)
        print(self.item_name)
        print(self.weight)
        print(self.brand)
        return self