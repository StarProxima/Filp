man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).


parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

% 11
daughter(X,Y):- parent(Y,X),woman(X).
daughter(X) :- daughter(Y,X), write(Y).

% 12 
wife(X,Y) :- parent(X,Z),parent(Y,Z),woman(X),man(Y).
wife(X) :- wife(Y,X), print(Y).

% 13 
grand_da(X,Y):-woman(X),parent(Y,Z),parent(Z,X).
grand_dats(X):-grand_da(Y,X),write(Y),nl,fail.

% 14
grand_ma_and_da(X,Y) :- woman(Y),woman(X),(grand_da(X,Y);grand_da(Y,X)).

% 15
min_digit_up(X,C) :- X < 10, C is X.
min_digit_up(X,Y) :- 
    D is X div 10,
    min_digit_up(D,C),
    M is X mod 10,
    Y is min(M,C).

% 16
min_digit_down(X,Y) :- min_digit_down(X,Y,10).

min_digit_down(X,Y,Digit) :- X < 10, Y is min(X,Digit).
min_digit_down(X,Y,Digit) :- 
    M is X mod 10,
    NewDigit is min(Digit,M),
    D is X div 10,
    min_digit_down(D,Y,NewDigit).

% 17
mult_digits5_up(X,C) :- 
    X < 10,
    (0 is X mod 5, C is 1; C is X).
mult_digits5_up(X,Y) :-
    M is X mod 10,
    D is X div 10,
    (0 is M mod 5, mult_digits5_up(D,Y);(mult_digits5_up(D,C), Y is M * C)).

% 18
mult_digits5_down(X,Y) :- mult_digits5_down(X,Y,1).

mult_digits5_down(X,Y,Mult) :- 
    X < 10,
    (0 is X mod 5, Y is Mult; Y is Mult * X).
mult_digits5_down(X,Y,Mult) :-
    M is X mod 10,
    D is X div 10,
    (0 is M mod 5, NewMult is Mult; NewMult is M * Mult),
    mult_digits5_down(D,Y,NewMult).

% 19
fib_up(N,X) :- N < 3, X is 1.
fib_up(N,X) :- fib_up(N - 2,X2), fib_up(N - 1,X1), X is X2 + X1.

% 20
fib_down(N,X):-fib_down(N,X,1,1,2).
fib_down(N,X,_,X,N):-!.
fib_down(N,X,Fib1,Fib2,K) :- NewFib1 is Fib2, NewFib2 is Fib2+Fib1, NewK is K+1, fib_down(N,X,NewFib1,NewFib2,NewK).