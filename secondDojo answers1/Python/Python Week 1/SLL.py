class Node:
  def __init__(self, value):
    self.value = value
    self.next = None

class Slist:
  def __init__(self, value):
    node = Node (value)
    self.head = node

  def addNode(self, value):
    runner = self.head
    while runner.next != None:
      runner = runner.next
    node = Node (value)
    runner.next = node

  def printAllValues(self):
    runner = self.head
    while runner.next != None:
      print(runner.value)
      runner= runner.next
    print (runner.value)

list = Slist(6)
list.addNode(20)
list.addNode(22)
list.addNode(30)
list.printAllValues()