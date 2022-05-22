#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <signal.h>
#include <unistd.h>
#include <sys/stat.h>
#include <sys/mman.h>
#include <sys/types.h>
#include <sys/wait.h>
 
long n = 99999999;
 
int main() {
    
    int *shared_cnt = (int*)mmap(NULL, 4096, PROT_READ | PROT_WRITE, MAP_SHARED | MAP_ANONYMOUS, -1, 0);
 
    *shared_cnt = 0;
    
    int id = fork();
    
    if (id == 0) { // child process
        int cnt = 0;
        for (long i = 1; i <= n / 2; i++) {
            if (i % 6 == 0 && i % 9 == 0) {
               cnt ++;
            }
        }
        *shared_cnt = *shared_cnt + cnt;
    } else { // parent process
        int cnt = 0;
        for (long i = n / 2; i <= n; i++) {
            if (i % 6 == 0 && i % 9 == 0) {
               cnt ++;
            }
        }
        wait(NULL);
        *shared_cnt = *shared_cnt + cnt;
        printf("%d \n", *shared_cnt);
    }
    
    return 0;
}