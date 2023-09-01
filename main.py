import random
print("угадай намбер")
a=random.randint(0,100)
b = 0
while b != a:
    b = (int)(input())
    if (b<a):
        print("мое число больше чем твое IQ")
    elif (b>a):
        print("мое число меньше чем твое IQ")
    elif (b==a):
        print("ты проиграл")
