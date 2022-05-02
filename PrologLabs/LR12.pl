

% 11
prime_internal(X,X).
prime_internal(1,_).
prime_internal(Number, Iter) :- 
    not(0 is Number mod Iter), 
    NewIter is Iter + 1,
    prime_internal(Number, NewIter),!.
prime(X) :- prime_internal(X,2).

max_prime_pivider_down(X,Y,Del) :-
    0 is X mod Del,
    prime(Del),
    Y is Del,!.
max_prime_pivider_down(X,Y,Del) :-
    NewDel is Del - 1,
    max_prime_pivider_down(X,Y,NewDel).
max_prime_divider(X,Y) :- max_prime_pivider_down(X,Y,X).