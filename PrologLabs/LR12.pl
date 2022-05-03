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

% 13 
number_right_triangles(P, Ans):- a(P, 1, Ans).

isRight(A,B,C, Inc) :- A2 is A*A, B2 is B*B, C2 is C*C, AB is A2 + B2, AB is C2, Inc is 1.
isRight(_,_,_, Inc) :- Inc is 0.

a(P, Value, Ans) :- Value > P/3, Ans is 0, !.
a(P, Value, Ans) :- 
    NewValue is Value+1,
    b(P, Value, NewValue, Ans1),
    a(P, NewValue, Ans2), 
    Ans is Ans1 + Ans2,!.

b(P, _, Value, Ans) :- Value > P/2, Ans is 0, !. 
b(P, A, Value, Ans) :-
    C is P-A-Value,
    isRight(A,Value,C, Inc),
    NewValue is Value+1,
    b(P, A, NewValue, Ans1),
    Ans is Ans1 + Inc.
    
% 14
list_length([],0).
list_length([_|Tail],Ans) :- list_length(Tail,Count), Ans is Count + 1.

% 15 - 11
different_elem([Elem1|[Elem2|[Elem3|Tail]]], Ans) :- 
    (Elem1 is Elem2, Elem2 is Elem3, different_elem([Elem2,Elem3|Tail], Ans); 
    get_different(Elem1,Elem2,Elem3,Ans)),!.
get_different(X,X,Y,Y).
get_different(X,Y,X,Y).
get_different(Y,X,X,Y).

