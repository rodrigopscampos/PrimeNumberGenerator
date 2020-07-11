import subprocess 
import time

p_name = r'FuckingPrime.exe'

results = []
for i in range(5):

    f = open('output.txt', 'w')
    p = subprocess.Popen(p_name, universal_newlines=True, stdout=f)
    time.sleep(2)
    p.kill()
    f.flush()
    f = open('output.txt', 'r')
    results.append(len(f.readlines()))

print(max(results))