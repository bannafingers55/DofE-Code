##Binary Search Code
import random
def binarySearch(min, max, correctNum):
    minVal = min
    maxVal = max
    notGuessed = True
    itterations = 0
    while notGuessed:
        range = maxVal - minVal
        midpoint = int(maxVal - range/2)
        print("Range: %s, midpoint,: %s, minVal: %s, maxVal %s" % (range, midpoint, minVal, maxVal))
        if midpoint == correctNum:
            print("Success, %s is indeed the correct number" % (midpoint))
            notGuessed == False
            print("That took the computer %s attempts" % (itterations))
            break
        elif midpoint > correctNum:
            print("Too high")
            maxVal = midpoint
            itterations += 1

        elif midpoint < correctNum:
            print("Too low")
            minVal = midpoint
            itterations += 1


binarySearch(1, 999999999999, random.randint(1, 999999999999))
