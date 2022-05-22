#include <stdio.h>
#include <stdlib.h>
 
int main() {
    
    int num,guess;
    num=rand() % 10 +1;
    
    printf("Guess my number game \n");
    do
    {
        
        printf("Please enter a guess between 1 and 10 : ");
        scanf("%d", &guess);}while(guess!=num);
    
    printf("You have guessed the right number ! ");
    return 0;
}