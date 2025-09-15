/*
I tried to write as much of this as I could on my own to get the best 
understanding of how everything works so sorry if it's maybe done 
in a not very optimal or confusing way haha.

AttackHealOnKey script uses the old input method rather than a assigned key,
lmb attacks and rmb heals

the damage amounts are defined here. changing the health occurs in one place using 
one input so healing is a positive int and damaging is a negitive int.

when a button is pressed the change health method on the health script runs
when change heath frist starts up, it check to see if it has a config file like
the one we made in class, if not, it reverts to the default values

the health changed method checks to see if the incoming number is not 0 and if our current
health is above zero
if both are true we set our current health to whatever our health is plus the incoming
value.
if the value is negitive to check to see if the incoming damage would put our current
health at or below zero, if so we die. 
if we live, an event is called on our Health UI script which controls our
text and out slider in the same way the one in the class does.

I didnt make any feedback effect because I ran out of time :(

when the enemy dies the UI unsubscribes from the event.
*/
