% 11.1
max_prime_divider_down(X,Y) :- max_prime_divider_down(X,Y,X).

prime_internal(X,X).
prime_internal(1,_).
prime_internal(Number, Iter) :- 
    not(0 is Number mod Iter), 
    NewIter is Iter + 1,
    prime_internal(Number, NewIter),!.
prime(X) :- prime_internal(X,2).

max_prime_divider_down(X,Y,Div) :-
    0 is X mod Div,
    prime(Div),
    Y is Div,!.
max_prime_divider_down(X,Y,Div) :-
    NewDiv is Div - 1,
    max_prime_divider_down(X,Y,NewDiv).


% 11.2
max_prime_divider_up(X,Y) :- max_prime_divider_up(X,Y,X+1).

% Или вместо этого просто Y is max(C, NewDiv)
ismax(Y, C, NewDiv) :- NewDiv > C, Y is NewDiv,!.
ismax(Y, C, NewDiv) :- NewDiv < C, Y is C,!.
ismax(Y, C, _) :- Y is C.

max_prime_divider_up(_,Y,Div) :- Div < 2, Y is 1.
max_prime_divider_up(X,Y,Div) :-
    NewDiv is Div - 1,
    (0 is X mod NewDiv, prime(NewDiv), max_prime_divider_up(X,C,NewDiv), ismax(Y, C, NewDiv),! ;  max_prime_divider_up(X,Y,NewDiv)).


% 12
nod_mult_digit_and_max_unprime_uneven_divider(X,Y) :- mult_digit(X,Arg1), max_unprime_uneven_divider(X,Arg2), nod(Arg1,Arg2,Y),!.

mult_digit(X,Y) :- 
    X < 10, 
    Y is X.
mult_digit(X,Y) :- 
    V is X div 10,
    mult_digit(V, Y2),
    N is X mod 10,
    Y is Y2 * N.

max_unprime_uneven_divider(X,Y) :- max_unprime_uneven_divider(X,Y,X).
max_unprime_uneven_divider(X,Y,Div) :-
    0 is X mod Div,
    not(0 is Div mod 2),
    not(prime(Div)),
    Y is Div,!.
max_unprime_uneven_divider(X,Y,Div) :-
    NewDiv is Div - 1,
    max_unprime_uneven_divider(X,Y,NewDiv).


nod(X,0,X) :- !.
nod(_,1,1) :- !.
nod(X,Y,C) :- ModXY is X mod Y, nod(Y, ModXY, C).

