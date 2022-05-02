% 11.1
prime_internal(X,X).
prime_internal(1,_).
prime_internal(Number, Iter) :- 
    not(0 is Number mod Iter), 
    NewIter is Iter + 1,
    prime_internal(Number, NewIter),!.
prime(X) :- prime_internal(X,2).

max_prime_divider_down(X,Y,Del) :-
    0 is X mod Del,
    prime(Del),
    Y is Del,!.
max_prime_divider_down(X,Y,Del) :-
    NewDel is Del - 1,
    max_prime_divider_down(X,Y,NewDel).
max_prime_divider_down(X,Y) :- max_prime_divider_down(X,Y,X).

% 11.2
% Или вместо этого просто Y is max(C, NewDel)
max(Y, C, NewDel) :- NewDel > C, Y is NewDel,!.
max(Y, C, NewDel) :- NewDel < C, Y is C,!.
max(Y, C, _) :- Y is C.

max_prime_divider_up(_,Y,Del) :- Del < 2, Y is 1.
max_prime_divider_up(X,Y,Del) :-
    NewDel is Del - 1,
    (0 is X mod NewDel, prime(NewDel), max_prime_divider_up(X,C,NewDel), max(Y, C, NewDel),! ;  max_prime_divider_up(X,Y,NewDel)).
max_prime_divider_up(X,Y) :- max_prime_divider_up(X,Y,X+1).

